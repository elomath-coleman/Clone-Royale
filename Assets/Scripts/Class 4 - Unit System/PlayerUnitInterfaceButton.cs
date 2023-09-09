using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerUnitInterfaceButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] PlayerUnitInterfaceController controller;
    [SerializeField] Image thisImage;
    [SerializeField] GameObject unitPrefab;
    [SerializeField] float cost = 0;
    bool mouseDown = false;

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
        mouseDown = true;
        thisImage.color = Color.yellow;
        controller.PrepareUnitForSpawn(unitPrefab, cost);
    }
}
