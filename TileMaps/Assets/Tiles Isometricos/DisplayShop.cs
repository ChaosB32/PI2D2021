using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayShop : MonoBehaviour
{
    public ShopObject shop;

    public int X_START;
    public int Y_START;
    public int X_ESPACO_ENTRE_ITENS;
    public int NUMERO_DE_COLUNAS;
    public int Y_ESPACO_ENTRE_ITENS;

    public TMP_Text textoPrabotar;

    Dictionary<InventorySlot, GameObject> itensDisplayed = new Dictionary<InventorySlot, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < shop.Container.Count; i++)
        {
            if (itensDisplayed.ContainsKey(shop.Container[i]))
            {
                itensDisplayed[shop.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = shop.Container[i].amount.ToString("n0");

            }
            else
            {
                var obj = Instantiate(shop.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = shop.Container[i].amount.ToString("n0");
                obj.GetComponent<UI_Script>().coinUI = textoPrabotar;
                itensDisplayed.Add(shop.Container[i], obj);
            }
        }
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < shop.Container.Count; i++)
        {
            var obj = Instantiate(shop.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = shop.Container[i].amount.ToString("n0");
            obj.GetComponent<UI_Script>().coinUI = textoPrabotar;
            itensDisplayed.Add(shop.Container[i], obj);
        }
    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_ESPACO_ENTRE_ITENS * (i % NUMERO_DE_COLUNAS)), Y_START + (-Y_ESPACO_ENTRE_ITENS * (i / NUMERO_DE_COLUNAS)), 0f);
    }
}
