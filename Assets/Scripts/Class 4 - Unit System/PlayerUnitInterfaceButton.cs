using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerUnitInterfaceButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] PlayerUnitInterfaceController controller;
    [SerializeField] Image thisImage;
    [SerializeField] GameObject unitPrefab;
    [SerializeField] float cost = 0;
    bool mouseDown = false;
    [SerializeField] CurrencyManager currencyManager;
    [SerializeField] TextMeshProUGUI costText;

    void Start()
    {
        if (costText != null) costText.text = cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown) RunWaitForMouseUp();
    }
    void RunWaitForMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            thisImage.color = Color.white;
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (currencyManager.GetCurrentCurrency() < cost) return;

        mouseDown = true;
        thisImage.color = Color.yellow;
        controller.PrepareUnitForSpawn(unitPrefab, cost);
    }
}
