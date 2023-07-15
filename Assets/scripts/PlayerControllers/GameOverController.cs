using UnityEngine;
using  TMPro;

public class GameOverController : MonoBehaviour
{
   
    public TMP_Text coinTxt;
    public TMP_Text diamondTxt;
    public TMP_Text metersTxt;
    private string gameOverResonStr="DRIVER DOWN";
    public TMP_Text overResonTitleTxt;
    public AudioSource gameOverSound;

    private GameManager gameManager;
    public bool uiIsSetted=false;
    public GameObject gameOverDialog;

    

    // Start is called before the first frame update
    void Start()
    {
          gameManager=FindObjectOfType<GameManager>();
          
    }

    void Update(){
       
    }

    public void endTheGame()
    {

        Debug.Log("--------------------------------------------------------------02");
        gameOverSound.Play();
            gameOverDialog.SetActive(true);
            LeanTween.scale(gameOverDialog, new Vector3(0.75f, 0.7f, 1), 1.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
            if (!gameManager.getReasonOfGameOver()) gameOverResonStr = "FUEL RAN OUT";

            overResonTitleTxt.text = gameOverResonStr;
            coinTxt.text = "+" + gameManager.getCoinsCount() + " COINS";
            diamondTxt.text = "+" + gameManager.getGEMSCount() + " GEMS";
            metersTxt.text = gameManager.getMetersCount() + " m";
            uiIsSetted = true;

        
    }
   
}


