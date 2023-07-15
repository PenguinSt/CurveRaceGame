using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsShopItemController : MonoBehaviour
{
    public TMP_Text priceTxt,countTxt;
    public string priceStr,countStr;
    public Image img1, img2, img3;
    public Sprite imgSprt1, imgSprt2, imgSprt3;
    public bool isGems=false;
    // Start is called before the first frame update
    void Start()
    {
        priceTxt.text = priceStr;
        img1.sprite = imgSprt1;
        img2.sprite = imgSprt2;
        img3.sprite = imgSprt3;
        string type = "COINS";
        if (isGems) type = "GEMS";
        countTxt.text= Utils.getSeparatedNumberStr(double.Parse(countStr)) +  " " + type ;

    }
    public void OnPurchaseCoinsCompleted(int coins)
    {
       
        FindObjectOfType<MainMenuController>().setCoinsText((FindObjectOfType<MainMenuController>().getCurrentCoinsCoint() + coins).ToString());
      Utils.increaseCoins(coins);
    }

    public void OnPurchaseGemssCompleted(int gems)
    {
        Debug.Log("OnPurchaseGemssCompleted:" + gems);
        Debug.Log("OnPurchaseGemssCompleted:current gms" + (FindObjectOfType<MainMenuController>().getCurrentGemsCoint()));
        FindObjectOfType<MainMenuController>().setGemsText((FindObjectOfType<MainMenuController>().getCurrentGemsCoint() + gems).ToString());
       Utils.increaseGemss(gems);

    }


}
