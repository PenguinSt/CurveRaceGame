using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Net;

public class ShopItemController : MonoBehaviour

{

   

    [SerializeField] 
    private TMP_Text nameTxt;

    [SerializeField] 
    private TMP_Text priceTxt;

    [SerializeField] 
    private Image image;

     [SerializeField] 
    private AudioSource selectSound;
    [SerializeField]
    public GameObject selectDialog;

    [SerializeField]
    private GameObject pricingCarBGObj;

    private static GameObject selectedPricingObj;

    public bool priceInCoins = true;



    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            data.vehicleNames.ForEach(name => {
                if (name == gameObject.name)
                {
                    pricingCarBGObj.SetActive(false);
                   
                }
            });
        }
    }



    public void finishBuyingPrrocess()
    {
        selectedPricingObj.SetActive(false);

    }

    public void OnShopItemClicked(bool isVehiclesShop)
    {
        selectedPricingObj = pricingCarBGObj;
        image=gameObject.GetComponent<Image>();

        if (selectDialog.activeInHierarchy == false)
        {
            selectSound.Play();

            if (pricingCarBGObj.activeInHierarchy) // item is locked !!
            { // lock
                selectDialog.GetComponent<SelectCarDialogUI>().enabled = true;
                selectDialog.SetActive(true);
                selectDialog.transform.localScale = new Vector3(0, 0, 0);
                selectDialog.GetComponent<SelectCarDialogUI>().setDialogUiParamers(image.sprite, priceTxt.text, nameTxt.text, gameObject.name,priceInCoins);


                LeanTween.scale(selectDialog, new Vector3(1, 1, 1), 1.5f).setEase(LeanTweenType.easeOutElastic);
            }
            else
            {
                if (isVehiclesShop)
                {
                    MainMenuController.currentVehicleName= gameObject.name;
                    FindObjectOfType<MainMenuController>().setSelectedCarImg(image.sprite);
                    Debug.Log("isVehicleshop************************  " + gameObject.name);
                    VehicleSelectionController.currentVehicleIdStr = gameObject.name;
                }
                // here we will take stage OR vehicle .. but in the next work hours (-:
                else
                {
                    FindObjectOfType<MainMenuController>().setSelectedStageImg(image.sprite);
                    Debug.Log("isGroundshop  " + gameObject.name);
                    GroundHolderController.currentGroundNameStr = gameObject.name;
                }
            }
            transform.localScale = new Vector3(1.6f, 1.4f, 1f);
        }
    }


    public void CloseSelectDialog()
    {
        selectDialog.GetComponent<SelectCarDialogUI>().enabled = false;
        Debug.Log("Close doaog");
        selectDialog.SetActive(false);

    }

}
