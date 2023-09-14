using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    [SerializeField] float maxCurrency = 10;
    float currentCurrency = 0;
    [SerializeField] float baseIncomeRate = 1;
    float incomeRateModifier = 1.0f;
    [SerializeField] GameObject currencyBarFill;
    [SerializeField] TextMeshProUGUI currencyBarText;
    float oldTimerValue = 0;
    [SerializeField] UIScaleShift currencyBarTextScaleShift;

    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = maxCurrency / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AccumulateCurrency();
        UpdateCurrencyUI();
    }

    void AccumulateCurrency()
    {
        currentCurrency += (baseIncomeRate*incomeRateModifier) * Time.deltaTime;

        if (currentCurrency > maxCurrency) currentCurrency = maxCurrency;
    }

    void UpdateCurrencyUI()
    {
        if (currencyBarFill != null) UpdateUIFillbar();
        if (currencyBarText != null) UpdateUIText();
    }
    void UpdateUIFillbar()
    {
        currencyBarFill.transform.localScale = new Vector3(currentCurrency / maxCurrency, 1, 1);
    }
    void UpdateUIText()
    {
        currencyBarText.text = currentCurrency.ToString("0");

        if (currentCurrency == maxCurrency)
        {
            oldTimerValue = 0;
        }
        else
        {
            oldTimerValue += (baseIncomeRate * incomeRateModifier) * Time.deltaTime;

            if (oldTimerValue >= -1)
            {
                oldTimerValue = -1;
                currencyBarTextScaleShift.TriggerScaleShift();
            }
        }
    }

    #region External
    public float GetCurrentCurrency()
    {
        return currentCurrency;
    }

    public void SpendCurrency(float amount)
    {
        if (currentCurrency > amount) currentCurrency -= amount;
        UpdateCurrencyUI();
    }
    #endregion

}
