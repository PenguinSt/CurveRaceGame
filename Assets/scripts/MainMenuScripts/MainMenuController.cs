using UnityEngine.SceneManagement; 
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Coinstext;

    [SerializeField]
    private TMP_Text GemsText;

    public List<GameObject> optionsButtons;

    [SerializeField]
    private AudioSource buyCarSound;

    [SerializeField]
    private Image selectedStageImg;

    [SerializeField]
    private Image selectedVehicleImg;

    [SerializeField]
    private AudioSource bgMusic;

    public static PlayerData playerData;

    public static string currentVehicleName = "HillClimber";



    public void StartGame(){
  

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
         

    }
    private void Start()
    {
        playerData = SaveSystem.LoadPlayer();

            setBgMusic(playerData.isMusicOn);
        GameManager.gameHasEnded = false;
        GameManager.levelHasEnded=false;
    }

    public int getCurrentCoinsCoint()
    {
        return int.Parse(Coinstext.text.Replace(" ",""));
    }
    public int getCurrentGemsCoint()
    {
        return int.Parse(GemsText.text.Replace(" ", ""));
    }

    public void ExitGame()
    {
         Application.Quit();
        
    }
    public void setScoreTexts(string coins , string gems)
    {
        Coinstext.text = Utils.getSeparatedNumberStr(double.Parse(coins));
        GemsText.text = Utils.getSeparatedNumberStr(double.Parse(gems));

    }
    public void setCoinsText(string coins)
    {
        Coinstext.text = Utils.getSeparatedNumberStr(double.Parse(coins));

    }
   
    public void setGemsText( string gems)
    {
        GemsText.text = Utils.getSeparatedNumberStr(double.Parse(gems));

    }

    public void PlayBuySound()
    {
        buyCarSound.Play();
    }

    public void OnOptionButtonSelect(GameObject btn)
    {
        Debug.Log("pooooos=  "+btn.transform.position.y.ToString());
        //optionsButtons.ForEach(o => {
        //    o.transform.localScale = Vector3.one;
        //    o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, 0);
        //});

        for(int i = 0; i < optionsButtons.Count; i++)
        {
            GameObject o = optionsButtons[i];
            o.transform.localScale = Vector3.one;
            o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, 0);
            //if(i==1||i==3)
            //{
            //    FindObjectOfType<IniterstitialAdsController>().ShowAd();
            //}
        }
        btn.transform.localScale=new Vector3(1.3f, 1.3f, 1.3f);
       // btn.transform.position = new Vector3(btn.transform.position.x, 60, 0);
    }

    public void setSelectedStageImg(Sprite sprt)
    {
        selectedStageImg.sprite=sprt;
    }

    public void setSelectedCarImg(Sprite sprt)
    {
        selectedVehicleImg.sprite = sprt;
    }

    public void setBgMusic(bool val)
    {
        if (val)
        {
            bgMusic.Play();
            return;
        }
        bgMusic.Stop();
    }


}

