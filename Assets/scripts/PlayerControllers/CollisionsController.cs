using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CollisionsController : MonoBehaviour
{
    bool moveCoin=false;
    public AudioSource collectSound;
    public AudioSource fuelSound;
    private PlayerData playerData;
    public GameObject eagleLeft;
    public GameObject eagleRight;




    private GameObject collObj;

    private PlayerMovementController movementController;
   
   
   
   
   void Start(){
      
    movementController=FindObjectOfType<PlayerMovementController>();
        playerData = SaveSystem.LoadPlayer();
        if(playerData.isSoundOn)
        {
            collectSound.enabled = true;
            fuelSound.enabled = true;
        }
        else
        {
            collectSound.enabled = false;
            fuelSound.enabled = false;
        }
       


    }

    

    void OnTriggerEnter2D(Collider2D col){
       
      if(!GameManager.IsLevelEnded()&&!GameManager.IsGameEnded()){
        collObj=col.gameObject;


            if (collObj.CompareTag("Netrogen"))
            {
                Destroy(collObj);
                fuelSound.Play();
                FindObjectOfType<PlayerMovementController>().increseNetrogen();
               
               
            }
            if (collObj.CompareTag("EagleTrigger"))
            {
                if (eagleLeft != null)
                {
                    eagleLeft.SetActive(true);
                }
                if (eagleRight != null)
                {
                    eagleRight.SetActive(true);
                }

                Debug.Log("EagleTrigger");
            }
            if (collObj.CompareTag("Eagle"))
            {
                FindObjectOfType<GameManager>().setReasonOfOver(true);
                FindObjectOfType<GameManager>().EndGame();
                GameManager.setEndGameFlag(true);
            }

            if (collObj.tag.ToString().Contains("Coin")){
                Debug.Log("hit coin");
                if (collObj.CompareTag("Coin5")){
            //  Debug.Log("hit coin");
               FindObjectOfType<UIController>().increaseCoins(5);
            }
            if(collObj.CompareTag("Coin25")){
                    //  Debug.Log("hit coin");
                    FindObjectOfType<UIController>().increaseCoins(25);
            }
            if(collObj.CompareTag("Coin100")){
                    FindObjectOfType<UIController>(). increaseCoins(100);
            }
            if(collObj.CompareTag("Coin500")){
                    FindObjectOfType<UIController>().increaseCoins(500);
            }
              collectSound.Play();
              collObj.GetComponent<Collider2D>().enabled=false;
             moveCoin = true;
            Destroy(collObj,0.5f);}

       else if(col.CompareTag("gasContainer")) {
         moveCoin = false;
                Debug.Log("gasContainer");
         fuelSound.Play();
         movementController.fillGas();
         Destroy(collObj);
       }
      else if(col.CompareTag("Diamond")){
        Debug.Log("hit Diamond");
                FindObjectOfType<UIController>().increaseDiamonds();
       }
        }
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveCoin&&collObj!=null){
          collObj.transform.Translate(new Vector3(0,10*Time.fixedDeltaTime,0));
        }
    }
   
}
