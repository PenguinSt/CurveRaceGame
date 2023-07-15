using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndLevelController : MonoBehaviour
{
    public AudioSource endMusic;
    public ParticleSystem endLevelPS;
    public GameObject successLevelDialog,star1,star2,star3,menuBtn,restartBtn;
    public TMP_Text coinsCountTxt,GEMSCountTxt,metersCountTxt;
    
    

    private UITween uiTueen;
    private GameManager gameManager;

    void Start(){
      uiTueen=FindObjectOfType<UITween>();
      gameManager = FindObjectOfType<GameManager>();
    }


    public void endLevel(){
        Debug.Log(gameManager.getCoinsCount().ToString() + " COINS");
      coinsCountTxt.text="+"+gameManager.getCoinsCount().ToString()+ " COINS";
      GEMSCountTxt.text=" +"+gameManager.getGEMSCount().ToString()+" GEMS";
      metersCountTxt.text=gameManager.getMetersCount().ToString()+" m";

      endMusic.Play();
      endLevelPS.Play();
      uiTueen.ShowEndLevel(successLevelDialog,star1,star2,star3);
      GameManager.setEndLevelFlag(true);

    



    }
    public void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
