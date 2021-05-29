using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    const float phaseLenght = 28800f; // 8hrs

    

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve; 
    [SerializeField] Color dayLightColor = Color.white;
    
    float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f; //8horas da manha
    [SerializeField] AudioClip sfxDayPass;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;

    List<TimeAgent> agents;

    //quests
    public QuestGiver questGiver;

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
            NextDay();
            AudioManager.instance.Play(sfxDayPass);
            RemoveCoins();
        }

        TimeAgents();
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
    public void RemoveCoins()
    {

        ItemDragAndDropController.instance.coins--;
        ItemDragAndDropController.instance.coinUI.text = "x " + ItemDragAndDropController.instance.coins.ToString();

        //PlayerPrefs.SetInt("Pontuação", coins);
        //PlayerPrefs.Save();
    }
}
