using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded=false;
    public static bool levelHasEnded=false;

    private  int  coinsCount=0;
    private  int diamondsCount=0;
    private  int metersCount=0;
    private bool reasonIsDriverDown=true;
    private int addedCoins = 0;

    private void Start()
    {
        //SaveSystem.savePlayer(new PlayerData(coinsCount, diamondsCount, metersCount));
        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null)
        {
         coinsCount = data.coins;
         diamondsCount = data.GEMS;
        
        }
       

    }

    public  void IncreaseCoinsCount(int coins){
        coinsCount +=coins;
        addedCoins+=coins;

        // int hScore = 0;
       
        PlayerData data=SaveSystem.LoadPlayer();
        if (data != null)
        {
            data.coins = coinsCount;
            data.GEMS = diamondsCount;
            
        }
        else
        {
            data = new PlayerData(coins, diamondsCount, 0);
        }
        SaveSystem.savePlayer(data);

        // first game high score equal 0
    }

    public  void IncreaseDismondsCount(int diamonds){
        diamondsCount+=diamonds;
    }
    public  void IncreaseMetersCount(int meters){
        metersCount=meters*2;
    }

    public void setReasonOfOver(bool reason){
        reasonIsDriverDown=reason;
    }

    public int getCoinsCount(){
      return addedCoins;
    }
     public int getGEMSCount(){
      return diamondsCount;
    }
     public int getMetersCount(){
      return metersCount;
    }

    
   
    public bool getReasonOfGameOver(){
      return reasonIsDriverDown;
    }

    
    public static bool IsGameEnded(){
      return gameHasEnded;
    }
    public static void setEndGameFlag(bool end){
      gameHasEnded=end;
    }
    public static bool IsLevelEnded(){
      return levelHasEnded;
    }
    public static void setEndLevelFlag(bool end){
      levelHasEnded=end;
    }
    

  

     public void EndGame(){
        Debug.Log("--------------------------------------------------------------01");
        FindObjectOfType<GameOverController>().endTheGame();
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            int saveHigh = data.highScore;
            if (saveHigh < metersCount)
            {
                data.highScore = metersCount;
                SaveSystem.savePlayer(data);
            }
        }
       
          
     }

     public void RestartGame(){
      GameManager.setEndGameFlag(false);
      GameManager.setEndLevelFlag(false);
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     gameObject.SetActive(false);
   }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
