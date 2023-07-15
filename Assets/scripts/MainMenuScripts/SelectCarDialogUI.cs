using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;


public class SelectCarDialogUI : MonoBehaviour
{
     [SerializeField] 
     private TMP_Text priceTxt;

    [SerializeField]
    private Image image;

    [SerializeField]
    private TMP_Text titleTxt;

    [SerializeField]
    private TMP_Text buyBtnText;

    [SerializeField]
    private GameObject shopUIObj;

    [SerializeField]
    private Button shopBtn;


    private string boughtObjIdName;
    bool getCoinsBtnClicked = false;

    bool priceInCoin = true;



    public void setDialogUiParamers(Sprite sprite,string price,string title,string vIdName,bool priceInCoins)
    {
        priceTxt.text = price;
        if(sprite != null)
         image.sprite = sprite;
        titleTxt.text = title;

        boughtObjIdName= vIdName;
        priceInCoin = priceInCoins;
    }

    public void OnBuyBtnClicked()
    {
        if(getCoinsBtnClicked)
        {
           shopBtn.onClick.Invoke();
            gameObject.SetActive(false);
            getCoinsBtnClicked = false;
            return;
        }
        if (priceInCoin)
        {
            int restCoins = Mathf.Abs(Utils.getCurrentCoins() - int.Parse(priceTxt.text.Replace(" ", "")));

            if (!Utils.isCoinsSufficient(priceTxt.text))
            {
                titleTxt.text = "You need  " + Utils.getSeparatedNumberStr(double.Parse(restCoins.ToString())) + "  more coins";
                buyBtnText.text = "GET COINS";
                getCoinsBtnClicked = true;
            }
            else // buying has done
            {
                PlayerData playerData = SaveSystem.LoadPlayer();

                playerData.coins = restCoins;
                playerData.addVehicleName(boughtObjIdName);



                FindObjectOfType<ShopItemController>().finishBuyingPrrocess();
                SaveSystem.savePlayer(playerData);
                FindObjectOfType<MainMenuController>().setCoinsText(restCoins.ToString());
                FindObjectOfType<MainMenuController>().PlayBuySound();
                gameObject.SetActive(false);
            }
        }
        else
        {
            int restGems = Mathf.Abs(Utils.getCurrentGems() - int.Parse(priceTxt.text.Replace(" ", "")));

            if (!Utils.isGemsSufficient(priceTxt.text))
            {
                titleTxt.text = "You need  " + Utils.getSeparatedNumberStr(double.Parse(restGems.ToString())) + "  more gems";
                buyBtnText.text = "GET GEMS";
                getCoinsBtnClicked = true;
            }
            else // buying has done
            {
                PlayerData playerData = SaveSystem.LoadPlayer();

                playerData.GEMS = restGems;
                playerData.addVehicleName(boughtObjIdName);



                FindObjectOfType<ShopItemController>().finishBuyingPrrocess();
                SaveSystem.savePlayer(playerData);
                FindObjectOfType<MainMenuController>().setGemsText(restGems.ToString());
                FindObjectOfType<MainMenuController>().PlayBuySound();
                gameObject.SetActive(false);
            }
        }
       

    }


}
