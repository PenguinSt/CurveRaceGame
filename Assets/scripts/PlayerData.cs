using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int coins;
    public int GEMS;
    public int highScore;

    
    public bool isMusicOn = true;
    public bool isSoundOn = true;
    public string currentLanguage = "English";
    public int netrogenValue = 0;
    public List<string> vehicleNames= new List<string>();

    public PlayerData(int coins, int gEMS, int highScore)
    {
        this.coins = coins;
        GEMS = gEMS;
        this.highScore = highScore;

        isSoundOn = true;
        isMusicOn = true;
        
    }
    public void addVehicleName(string name)
    {
        this.vehicleNames.Add(name);
    }
   
}
