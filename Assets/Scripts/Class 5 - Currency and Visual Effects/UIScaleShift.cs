using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleShift : MonoBehaviour
{
    [SerializeField] float scaleMagnatude = .35f;
    [SerializeField] float scaleDuration = .5f;
    float timer = 0;
    bool shifting = true;

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunShifting()
    {
        timer += Time.deltaTime / scaleDuration;

        if (scaleDuration == 0)
        {
            timer = Time.deltaTime;
        }
        else timer += Time.deltaTime / scaleDuration;


        // Actual ScaleShift
        transform.localScale = Vector3.one + (Vector3.one * scaleMagnatude * (1 - timer));

        if(timer >= 1)
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
