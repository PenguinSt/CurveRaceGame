using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TuneOptionsController : MonoBehaviour
{
    public List<Button> itemsList;
    public int minimumTunePrice=4000;
    


    private void Start()
    {
       
        Debug.Log("OnStartToneOpCntl");


    }
    private void OnEnable()
    {
        Debug.Log("OnEnableToneOpCntl");
        itemsList.ForEach(v => {
            v.onClick.AddListener(() => OnItemButtonClicked(v));

            setTunesListValues(v);

        });
    }

    private void setTunesListValues(Button v)
    {
        TuneItemController itemController = v.GetComponent<TuneItemController>();

        VehicleData data = SaveSystem.LoadVehicle(MainMenuController.currentVehicleName);
        if (data != null)
        {
            int savedAWD = data.AWDValue;
            int savedTires = data.tireValue;
            int savedSuspension = data.suspensionValue;
            int savedEngine = data.engineValue;

            if (v.name.ToUpper().Equals("AWDBTN") && savedAWD <= 10)
            {
                itemController.priceTxt.text = (savedAWD * minimumTunePrice).ToString();
                itemController.percentSlider.value = savedAWD / 10.0f;
                itemController.upgradeNumberTxt.text = savedAWD + "/10";
            }
            else if (v.name.ToUpper().Equals("TIRESBTN") && savedTires <= 10)
            {
                itemController.priceTxt.text = (savedTires * minimumTunePrice).ToString();
                itemController.percentSlider.value = savedTires / 10.0f;
                itemController.upgradeNumberTxt.text = savedTires + "/10";
            }
            else if (v.name.ToUpper().Equals("ENGINEBTN") && savedEngine <= 10)
            {
                itemController.priceTxt.text = (savedEngine * minimumTunePrice).ToString();
                itemController.percentSlider.value = savedEngine / 10.0f;
                itemController.upgradeNumberTxt.text = savedEngine + "/10";
            }
            else if (v.name.ToUpper().Equals("SUSPENSIONBTN") && savedSuspension <= 10)
            {
                itemController.priceTxt.text = (savedSuspension * minimumTunePrice).ToString();
                itemController.percentSlider.value = savedSuspension / 10.0f;
                itemController.upgradeNumberTxt.text = savedSuspension + "/10";
            }

        }


    }

    private void OnItemButtonClicked(Button v)
    {

            itemsList.ForEach(t => {
                t.transform.localScale = Vector3.one;
                t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y, 0);

            });
           // v.transform.position = new Vector3(v.transform.position.x, 350, 0);
            v.transform.localScale = new Vector3(1.25f, 1.25f, 1.2f);

       
    }

    public void upgradeIsFinished(int newVal, string currentTuneName)
    {
        FindObjectOfType<MainMenuController>().PlayBuySound();
       // Debug.Log("upgradeIsFinished - new val = " + newVal + " and current  currentTuneName = " + currentTuneName);
        itemsList.ForEach(t => {
            //Debug.Log("tune name i n list " +  t);
           if(t.name.ToUpper().Equals(currentTuneName))
            {
                TuneItemController scrpt = t.GetComponent<TuneItemController>();
                Debug.Log("Equaaaaallllll and new val=" + newVal);
                scrpt.priceTxt.text = (int.Parse(scrpt.priceTxt.text.Replace(" ", "").ToString()) * 2).ToString();
                scrpt.upgradeNumberTxt.text = newVal.ToString() + "/10";
                scrpt. percentSlider.value = newVal / 10.0f;

                return;

            }

        });


       

    }



}
