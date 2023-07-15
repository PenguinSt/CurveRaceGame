using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VehicleData 
{
   
    public int AWDValue=1;
    public int engineValue=1;
    public int suspensionValue = 1;
    public int tireValue = 1;

    
    public VehicleData(int awd, int engine, int suspension,int tire)
    {
        AWDValue = awd;
        engineValue = engine;
        tireValue = tire;
    }
    
   
}
