using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image gasAmountImg;
    [SerializeField]
    private Sprite fullGasAmountSprt;
    [SerializeField]
    private Sprite emptyGasAmountSprt;

    [SerializeField]
    private GameObject emptyGasWarning;


    public AudioSource fuelEmptSound;

    public GameObject gasBtnObj;
    public GameObject brakeBtnObj;
    public GameObject weaponPref;

    public GameObject weaponShooterObj;


    public TMP_Text score;
    public TMP_Text diamondScoreTxt;

    public GameObject pauseDialog;

    int scoreNum = 0;
    int diamondNum = 0;

    private GameManager gameManager;

    private bool fuelSoundPlaying = false;

    public GameObject scoreObj;

    public GameObject eagleHitPrizeTxt;

    public GameObject airTimeTxt;

    private bool isCarJumping = false;


    // Start is called before the first frame update
    void Start()
    {

       
        gameManager = FindObjectOfType<GameManager>();

        PlayerData data = SaveSystem.LoadPlayer();
        scoreNum = data.coins;
        if (data != null)
        {
            score.text = Utils.getSeparatedNumberStr(double.Parse(SaveSystem.LoadPlayer().coins.ToString()));
            diamondScoreTxt.text = SaveSystem.LoadPlayer().GEMS.ToString();
        }

        
            
        

    }



    public void showAirTimeText(int time)
    {
        if (!isCarJumping)
        {
            isCarJumping = true;
            LeanTween.moveLocal(airTimeTxt, new Vector3(480, +100, 0), 1.25f);
            LeanTween.scale(airTimeTxt, new Vector3(1.5f, 1.5f, 1.5f), 1.5f);


            TMP_Text r = airTimeTxt.GetComponent<TMP_Text>();
            r.text = "AIR TIME \n +" + time.ToString();
            LeanTween.value(airTimeTxt, 1, 0, 2f).setOnUpdate((float val) =>
            {
                Color c = r.color;
                c.a = val;
                r.color = c;

            }).setOnComplete(onCompleteAirTime);

            airTimeTxt.SetActive(true);
        }
    }

    void onCompleteAirTime()
    {
        isCarJumping = false;// prevent showing immdiatily
        airTimeTxt.transform.position = new Vector3(3 * 480, 320, 0);  // return obj to origin position  

    }


    public void ShowEaglePizeText(int coins)
    {
             increaseCoins(coins);
;            LeanTween.moveLocal(eagleHitPrizeTxt, new Vector3(100, +100, 0), 1.5f);
            LeanTween.scale(eagleHitPrizeTxt, new Vector3(1.5f, 1.5f, 1.5f), 1.5f);


            TMP_Text r = eagleHitPrizeTxt.GetComponent<TMP_Text>();
            r.text = "+" + coins.ToString();
            LeanTween.value(eagleHitPrizeTxt, 1, 0, 2f).setOnUpdate((float val) =>
            {
                Color c = r.color;
                c.a = val;
                r.color = c;

            }).setOnComplete(onCompletePrizeShowing);

            eagleHitPrizeTxt.SetActive(true);
        
    }

    void onCompletePrizeShowing()
    {
        eagleHitPrizeTxt.transform.position = new Vector3(eagleHitPrizeTxt.transform.position.x-100, eagleHitPrizeTxt.transform.position.y - 100, 0);  // return obj to origin position  

    }

    public void showShootingObj(bool hasWeapon)
    {
        weaponShooterObj.SetActive(hasWeapon);
    }

    public void setGasRotation(float value)
    {
        if (value == 0) gasBtnObj.transform.rotation = Quaternion.identity;
        else gasBtnObj.transform.Rotate(new Vector3(value, 0, 0));
    }

    public void setBrakeRotation(float value)
    {
        if(value==0) brakeBtnObj.transform.rotation=Quaternion.identity;
        else brakeBtnObj.transform.Rotate(new Vector3(value, 0, 0));
    }

    public void increaseCoins(int coinCount)
    {
        scoreNum += coinCount;
        gameManager.IncreaseCoinsCount(coinCount);
        LeanTween.scale(scoreObj, new Vector3(1.2f, 1.2f, 1), 0.1f).setOnComplete(() => {
            LeanTween.scale(scoreObj, new Vector3(1f, 1f, 0), 0.1f);
        });
        score.text = Utils.getSeparatedNumberStr(scoreNum);
    }

    public void increaseDiamonds()
    {
        diamondNum += 1;
        gameManager.IncreaseDismondsCount(1);
        diamondScoreTxt.text = Utils.getSeparatedNumberStr(gameManager.getGEMSCount());

    }

   public void ShowPauseDialog()
    {
        pauseDialog.SetActive(true);
        Utils.ShowScaleObj(pauseDialog);
    }
    public void updateGasAmount(float gas)
    {
        
        gasAmountImg.fillAmount = gas;
        if (gas <=0.25f)
        {
            
            gasAmountImg.sprite = emptyGasAmountSprt;
            if (fuelSoundPlaying == false)
            {
                LeanTween.scale(emptyGasWarning, new Vector3(1, 1, 1), 0.25f);
                fuelEmptSound.Play();
                fuelSoundPlaying = true;
            }
        }
        else if(emptyGasWarning!=null)
        {
            emptyGasWarning.transform.localScale = new Vector3(0, 0, 0);
            gasAmountImg.sprite = fullGasAmountSprt;
            fuelEmptSound.Stop();
            fuelSoundPlaying=false;
        }
        if (gas <= 0)
        {
            fuelSoundPlaying = false;
            fuelEmptSound.Stop();
        }
        
    }
}
