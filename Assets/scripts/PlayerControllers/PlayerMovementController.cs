using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;
using Cinemachine;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{
   
    public Rigidbody2D fTire;  // suspension
    public Rigidbody2D bTire;
   


    public float speed; // engine
    private float currentSpeed;
    public Rigidbody2D car; // awd
                            //public PhysicMaterial vehivlePMaterial;

    // public GameObject frontWheelObj,backWheelObj;

  
    public AudioSource brakeSound;
    public AudioSource wheelDriftSound;

    public WheelJoint2D fWheel;
    public WheelJoint2D bWheel;


   
    bool isMoveFprward;
    bool isBrake;
    bool isMoveBackWard;
    bool isMoveNetrogen = false;
    public ParticleSystem backSmokeParticle;
    public ParticleSystem frontSmokeParticle;
     public ParticleSystem frontSmokeParticle2;
    public ParticleSystem backSmokeParticle2;
    public ParticleSystem netrogenPS;



    public CinemachineVirtualCamera camera;

    

  

    private float gas = 1f;
    private float netrogenVal =0f;
    private float currentNetroVal = 0;
    private PlayerData data;
    private VehicleData vehicleData;

    private Transform currentPlayerPos;

   
    private MeterScaleManager meterController;
    // public float movement;

    private GameManager gameManager;

    LensSettings lensSettings = new LensSettings();


    // Start is called before the first frame update
    void Update(){
        FindObjectOfType<UIController>().updateGasAmount(gas);
        currentPlayerPos = transform;
   
    }
    public Transform getCurrentPlayerPosition()
    {
        return currentPlayerPos;
    }
    public void fillGas(){
        gas=1.0f;
    }

    public void conitinue()
    {

       
        GameManager.setEndGameFlag(false);
        GameManager.setEndLevelFlag(false);
        transform.position = transform.position + new Vector3(0, 2f, 0);
        gas = 1;
        gameObject.transform.rotation = Quaternion.identity;
        FindObjectOfType<HeadCollision>().startingCollision = true;
       

    }
    void Start(){



        lensSettings.OrthographicSize = 6;
        lensSettings.NearClipPlane = 0.1f;
        lensSettings.FarClipPlane = 1000;

        camera.m_Lens = lensSettings;
       

        data = SaveSystem.LoadPlayer();
        vehicleData = SaveSystem.LoadVehicle(MainMenuController.currentVehicleName);

        GameManager.gameHasEnded = false;
        GameManager.levelHasEnded = false;
        gameManager = FindObjectOfType<GameManager>();
        meterController = FindObjectOfType<MeterScaleManager>();
       
        isMoveFprward = false;
        isBrake=false;
        //normalGasSprt=FindObjectOfType<UIController>(). normalGasBtn.image.sprite;
        //normalBrakeSprt= FindObjectOfType<UIController>().normalBrakeBtn.image.sprite;
        setTuneCar();
        if(data!=null) netrogenVal = data.netrogenValue;

    }

    public void setTuneCar()
    {

        if (vehicleData != null)
        {
            fTire.GetComponent<CircleCollider2D>().sharedMaterial.friction =0.3f+ 0.2f* vehicleData.tireValue;
            bTire.GetComponent<CircleCollider2D>().sharedMaterial.friction =0.3f+ 0.2f * vehicleData.tireValue;

            currentSpeed =speed+ (float)vehicleData.engineValue*25;


            JointSuspension2D suspension2D = new JointSuspension2D{ frequency = vehicleData.suspensionValue*4+2, dampingRatio = vehicleData.suspensionValue *0.25f + 0.1f };
            fWheel.suspension = suspension2D;
            bWheel.suspension = suspension2D;

            
  
        }
       
    }
     
     void updateMetersPointers(){
      
      if(transform.position.x<=751)
      {
        float xPos=transform.position.x;
        int xPosInt=(int)xPos;

        gameManager.IncreaseMetersCount(xPosInt);
       // meterPointer.transform.position=new Vector3(meterPointer.transform.position.x+12*Time.fixedDeltaTime,meterPointer.transform.position.y,meterPointer.transform.position.z);
        meterController.updateCurrentMeters(xPosInt,isMoveBackWard);
      }
     }

    
    // Update is called once per frame
    void FixedUpdate()
    {
       
        float velX = car.velocity.x;

        if (velX <= 3.5f && lensSettings.OrthographicSize>=5.5f)
        {
            lensSettings.OrthographicSize -= 1.2f*Time.fixedDeltaTime;


        }
        else if (velX > 3.5f && lensSettings.OrthographicSize <= 7.5f)
        {
            lensSettings.OrthographicSize += 1.2f * Time.fixedDeltaTime;
        }
        if (GameManager.gameHasEnded&& lensSettings.OrthographicSize >= 3.5f)
        {
            lensSettings.OrthographicSize -= 3f * Time.fixedDeltaTime;
        }
        camera.m_Lens = lensSettings;

        
        
        
        CheckNetrogen();

        if (GameManager.IsLevelEnded()==false&&GameManager.IsGameEnded()==false){
            if(gas<=0&&Math.Abs(car.velocity.x)<=0.2f){  // game over reason is fuel
            gameManager.setReasonOfOver(false);
            gameManager.EndGame();
            GameManager.setEndGameFlag(true);
            return;
           }
            if(!isBrake){
              updateMetersPointers();
            }
        
          if(isMoveFprward&&gas>0f){ // forward
            gas = gas-0.06f*Time.fixedDeltaTime;

                car.AddTorque(-currentSpeed * Time.fixedDeltaTime);
                bTire.AddTorque(-currentSpeed * Time.fixedDeltaTime);
                fTire.AddTorque(-currentSpeed * Time.fixedDeltaTime);
                // increase Meters

                meterController.increaseRMPMeter();
        }
        else  if(isMoveBackWard){ // back
                car.AddTorque(+currentSpeed * Time.fixedDeltaTime);
                bTire.AddTorque(+currentSpeed * Time.fixedDeltaTime);
                fTire.AddTorque(+currentSpeed * Time.fixedDeltaTime);
               // increase Meters


        }
        else if(isMoveBackWard==false&&isBrake==false){ // idle
            // SlowMeters
            meterController.slowMeters();
               
              

            }
          // brake
        if(isBrake&&car.velocity != Vector2.zero&&FindObjectOfType<CarBodyController>().isCarInAir==false&&!isMoveBackWard&&!isMoveFprward){
                //car.velocity = new Vector2(0.75f, 0);
                bTire.velocity = new Vector2(0, 0);
                fTire.velocity = new Vector2(0, 0);
                // car.velocity = Vector2.zero;



                // decreaseMeters
                meterController.decreaseMeters();
             
        }

      }

        
      

    
    }

    public void increseNetrogen()
    {
        netrogenVal = netrogenVal + 1;
        int nV = (int)netrogenVal;
        FindObjectOfType<NetrogenController>().setNetroTxt((nV / 1).ToString());
        data.netrogenValue = data.netrogenValue + 1;
        SaveSystem.savePlayer(data);
    }
    private void CheckNetrogen()
    {

        if (isMoveNetrogen && currentNetroVal > 0)
        {

            car.AddTorque(-400 * Time.fixedDeltaTime);
            bTire.AddTorque(-400 * Time.fixedDeltaTime);
            fTire.AddTorque(-400 * Time.fixedDeltaTime);
            car.mass = 4;
            fTire.mass = 1.5f;
            currentNetroVal = currentNetroVal - 0.0075f;
            if (currentNetroVal <= 0.01)
            {
                if(!netrogenPS.IsDestroyed())
                   netrogenPS.Stop();
            }

            int nV = (int)netrogenVal;
            FindObjectOfType<NetrogenController>().setNetroTxt((nV/1).ToString());
        }
        if (currentNetroVal <= 0)
        {
            currentNetroVal = 0;
        }
    }
    public void NetrogenMove()
    {
       
        if(netrogenVal> 0)
        {
            isMoveNetrogen = true;
            netrogenPS.Play();
            currentNetroVal = 1;
            netrogenVal = netrogenVal - 1;
            data.netrogenValue = data.netrogenValue - 1;
            SaveSystem.savePlayer(data);
        }


    }
   public void moveForward(){

    if(!GameManager.IsGameEnded()&&!GameManager.IsLevelEnded()&&FindObjectOfType<CarBodyController>().isCarInAir == false)
        {
      if(isMoveFprward==false&&gas>0f){ // here we check if car is not moivng forward >> showing smoke // 
        backSmokeParticle.Play();
        backSmokeParticle2.Play();

    }
     FindObjectOfType<UIController>().setGasRotation(30);
     isMoveBackWard=false; 
     isMoveFprward=true;
     isBrake=false;
    }
    
         
    }
    public void brakePlayer(){
      if(!GameManager.IsGameEnded()&&!GameManager.IsLevelEnded()&& FindObjectOfType<CarBodyController>().isCarInAir == false)
        {
       if(isBrake)
       { // backward
            isMoveBackWard=true;
            isBrake=false;
            frontSmokeParticle.Play();
            frontSmokeParticle2.Play();
            }
        else if(FindObjectOfType<CarBodyController>().isCarInAir==false){ 
               isBrake=true;
               
                meterController.resetNeddleZTMax();
               brakeSound.Play();
        
        }

            FindObjectOfType<UIController>().setBrakeRotation(30);
        
        isMoveFprward=false;
      }
        
         
    }
    public void idlePlayer(){
        if(!GameManager.IsGameEnded()&&!GameManager.IsLevelEnded()){
// isBrake=false;
        isMoveFprward=false;
        isMoveBackWard=false;
            FindObjectOfType<UIController>().setBrakeRotation(0);
            FindObjectOfType<UIController>().setGasRotation(0);
        }
       
    }
    public void playWheelDrift(){
       if(isMoveFprward) wheelDriftSound.Play();
    }
}
