using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class UpgradeDialogController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text priceTxt;

    [SerializeField]
    private TMP_Text descriptionTxt;

    [SerializeField]
    private TMP_Text titleTxt;

    private bool isGetCoinsBtnClicked=false;
    public Button shopBtn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void upgradeCarButtonClicked()
    {
        if (isGetCoinsBtnClicked)
        {
          shopBtn.onClick.Invoke();
            return;
        }
        int restCoins = Mathf.Abs(Utils.getCurrentCoins()- int.Parse(priceTxt.text.Replace(" ",""))) ;
        if (!Utils.isCoinsSufficient(priceTxt.text))
        {
            descriptionTxt.text = "You need  " + Utils.getSeparatedNumberStr(double.Parse(restCoins.ToString())) + "  more coins";
            priceTxt.text = "GET COINS";
            isGetCoinsBtnClicked = true;
            return;
        }

        Utils.decreaseCoins(int.Parse(priceTxt.text.Replace(" ","")));
        FindObjectOfType<MainMenuController>().setCoinsText(restCoins.ToString());
        gameObject.SetActive(false);
        int newV= saveTuneInfo(titleTxt.text);

        FindObjectOfType<TuneOptionsController>().enabled = false;
        FindObjectOfType<TuneOptionsController>().enabled = true;
        FindObjectOfType<TuneOptionsController>().upgradeIsFinished(newV,titleTxt.text);


    }
    public void setUpgradeDialogTexts(int price  , string desc,string title)
    {
        priceTxt.text = Utils.getSeparatedNumberStr(double.Parse(price.ToString()));
        descriptionTxt.text = desc.ToString();
        titleTxt.text = title.ToString();
    }

    private int saveTuneInfo(string tuneName)
    {
        int newVal=0;
        VehicleData data = SaveSystem.LoadVehicle(MainMenuController.currentVehicleName);
        
        if (tuneName.ToUpper().Contains("AWD"))
        {
            if (data.AWDValue >= 10)
            {
                return data.AWDValue;
            }
            Debug.Log("Contains AWD )");
            newVal = data.AWDValue+1;
            data.AWDValue = newVal;
            
        }
        else if (tuneName.ToUpper().Contains("Tiresbtn".ToUpper()))
        {
            if (data.tireValue >= 10)
            {
                return data.tireValue;
            }
            Debug.Log("tirees ");
            data.tireValue = data.tireValue+1;
            newVal= data.tireValue;
        }
        else if (tuneName.ToUpper().Contains("Suspensionbtn".ToUpper()))
        {
            if (data.suspensionValue >= 10)
            {
                return data.suspensionValue;
            }
            data.suspensionValue = data.suspensionValue+1;
            newVal= data.suspensionValue;
        }
        else if (tuneName.ToUpper().Contains("Enginebtn".ToUpper()))
        {
            if (data.engineValue >= 10)
            {
                return data.engineValue;
            }
            data.engineValue = data.engineValue+1;
            newVal= data.engineValue;
        }
        Debug.Log("newVal=" + newVal);
        SaveSystem.saveVehicle(data,MainMenuController.currentVehicleName);
        return newVal;


    }
    
}
