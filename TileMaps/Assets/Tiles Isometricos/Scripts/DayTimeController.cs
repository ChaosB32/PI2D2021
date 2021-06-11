using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    const float phaseLenght = 14400f; // 8hrs

    //28800 até 68400 é dia

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve; 
    [SerializeField] Color dayLightColor = Color.white;
    
    float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 14400f; //8horas da manha
    [SerializeField] AudioClip sfxDayPass;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;

    List<TimeAgent> agents;

    //quests
    public QuestGiver questGiver;
    //imposto
    public Text imposto;

    [SerializeField] AudioClip audioPassaros;
    [SerializeField] AudioClip audioNoite;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        //iniciar quests
        questGiver.OpenQuestWindow();
        //aceitar quests
        questGiver.AcceptQuest();
        time = startAtTime;
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }
    public void UnSubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    float Horas
    {
        get { return time / 3600f; }
    }
    float Minutos
    {
        get { return time % 3600f / 60f; }
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;

        TimeValueCalculation();
        DayLight();
        

        if (time > secondsInDay)
        {

            if (days <= 3)
            {
                NextDay();
                imposto.gameObject.SetActive(false);
                AudioManager.instance.Play(sfxDayPass);
                RemoveCoins(2);
                imposto.text = "Hoje você pagou 2 moedas de imposto!";
                imposto.gameObject.SetActive(true);
            }

            if (days > 3 && days < 8)
            {
                NextDay();
                imposto.gameObject.SetActive(false);
                AudioManager.instance.Play(sfxDayPass);
                RemoveCoins(5);
                imposto.text = "Hoje você pagou 5 moedas de imposto!";
                imposto.gameObject.SetActive(true);
            }

            if (days >= 8 && days <15)
            {
                NextDay();
                imposto.gameObject.SetActive(false);
                AudioManager.instance.Play(sfxDayPass);
                RemoveCoins(20);
                imposto.text = "Hoje você pagou 20 moedas de imposto!";
                imposto.gameObject.SetActive(true);
            }
            if (days >= 15)
            {
                NextDay();
                imposto.gameObject.SetActive(false);
                AudioManager.instance.Play(sfxDayPass);
                RemoveCoins(50);
                imposto.text = "Hoje você pagou 50 moedas de imposto!";
                imposto.gameObject.SetActive(true);
            }
        }

        TimeAgents();
    }

    private void UpdateImpostoTxt()
    {
        imposto.text = "Hoje você pagou 1 moeda de imposto!";
    }

    private void TimeValueCalculation()
    {
        int hh = (int)Horas;
        int mm = (int)Minutos;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
    }

    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Horas);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if(time>= 25200f && time<=25300f)
        {
            MusicManager.instance.PlayP(audioPassaros);
        }
        if (time >= 71000f && time <= 71100f)
        {
            MusicManager.instance.PlayP(audioNoite);
            
        }
    }

    int oldPhase = 0;

    private void TimeAgents()
    {
        int phase = (int)(time / phaseLenght);

        if (oldPhase != phase)
        {
            oldPhase = phase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
    public void RemoveCoins(int value)
    {

        ItemDragAndDropController.instance.coins-=value;
        ItemDragAndDropController.instance.coinUI.text =  ItemDragAndDropController.instance.coins.ToString();

        //PlayerPrefs.SetInt("Pontuação", coins);
        //PlayerPrefs.Save();
    }
}
