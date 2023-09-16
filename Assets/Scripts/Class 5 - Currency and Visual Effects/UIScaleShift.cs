using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleShift : MonoBehaviour
{
    [SerializeField] float scaleMagnitude = .35f;
    [SerializeField] float scaleDuration = .5f;
    float timer = 0;
    bool shifting = true;


    // Update is called once per frame
    void Update()
    {
        if (shifting) RunShifting();
    }

    void RunShifting()
    {
        if (scaleDuration == 0)
        {
            timer += Time.deltaTime;
        }
        else timer += Time.deltaTime / scaleDuration;

        // Actual ScaleShift
        transform.localScale = Vector3.one + (Vector3.one * scaleMagnitude * (1 - timer));

        if (timer >= 1)
        {
            transform.localScale = Vector3.one;
            shifting = false;
        }
    }

    public void TriggerScaleShift()
    {
        timer = 0;
        shifting = true;
    }
}
