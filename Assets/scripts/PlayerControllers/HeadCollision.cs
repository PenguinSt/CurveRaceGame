using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{

    
   
    public bool startingCollision = true;
   float timer = 0;
   readonly float duration = 1.5f; //one second
   
    private void Start()
    {
        Debug.Log("Start HeadCollision");
    }
    void OnTriggerEnter2D(Collider2D col){
      if(GameManager.IsLevelEnded()==false&&GameManager.IsGameEnded()==false){
         if(col.CompareTag("EndLevel0")){
                // Debug.Log("Head Collide -EndLevel0");
                GameManager.setEndLevelFlag(true);
                FindObjectOfType<EndLevelController>().endLevel();
          
            return;
       }

       if( col.CompareTag("Ground")&&startingCollision)
        {
                Debug.Log("*********************************************** collide");
                FindObjectOfType<GameManager>().setReasonOfOver(true);
                Debug.Log("--------------------------------------------------------------00");
                FindObjectOfType<GameManager>().EndGame();
                GameManager.setEndGameFlag(true);
               
          timer = 0;
        }
      }
      
     }


 }
  

