using TMPro;
using UnityEngine;

public class MeterScaleManager : MonoBehaviour
{
    private int currentMeters;
    public TMP_Text currentMetersTxt;
    public GameObject meterPointer;

    public GameObject meterNeedle;
    private float needleZRitation=0;
    private float maxMeterNeedleValue = 0.925f;

    public GameObject meterNeedleBoost;
    private float needleZRitationBoost=0;
    private float maxMeterNeedleValueBoost = 0.925f;

     // Start is called before the first frame update
    void Start()
    {
         needleZRitation = meterNeedle.transform.rotation.z;
         needleZRitationBoost = meterNeedleBoost.transform.rotation.z;
    }
    void Update(){
        needleZRitation=meterNeedle.transform.rotation.z;
        needleZRitationBoost=meterNeedleBoost.transform.rotation.z;
    }

    public void updateCurrentMeters(int m,bool isCarMovingBack){
        currentMeters = m*2;
        currentMetersTxt.text = currentMeters.ToString()+"m";

         if(!isCarMovingBack&&meterPointer.transform.position.x<=1600&&m>2)
       // Debug.Log("Current pos pointer meter x ="+meterPointer.transform.position.x );
        meterPointer.transform.position=new Vector3(meterPointer.transform.position.x+7.5f*Time.fixedDeltaTime,meterPointer.transform.position.y,meterPointer.transform.position.z);

    
    }
    public int getCurrentMeters(){
        return currentMeters;
    }

      public void increaseRMPMeter(){
        if(needleZRitation >= -1*maxMeterNeedleValue) meterNeedle.transform.Rotate(new Vector3(0,0,-25)*Time.fixedDeltaTime);
        if(needleZRitationBoost >= -1*maxMeterNeedleValueBoost) meterNeedleBoost.transform.Rotate(new Vector3(0,0,-10)*Time.fixedDeltaTime);
    }
    public void decreaseMeters(){
        if(needleZRitation <= maxMeterNeedleValue) meterNeedle.transform.Rotate(new Vector3(0,0,40)*Time.fixedDeltaTime);
        if(needleZRitationBoost <= maxMeterNeedleValueBoost) meterNeedleBoost.transform.Rotate(new Vector3(0,0,40)*Time.fixedDeltaTime);
    
    }
    public void slowMeters(){
          if(needleZRitation <= maxMeterNeedleValue) meterNeedle.transform.Rotate(new Vector3(0,0,8)*Time.fixedDeltaTime);
          if(needleZRitationBoost <= maxMeterNeedleValueBoost) meterNeedleBoost.transform.Rotate(new Vector3(0,0,8)*Time.fixedDeltaTime);
    }
   public void resetNeddleZTMax(){
         needleZRitation=maxMeterNeedleValue;
    }
}
