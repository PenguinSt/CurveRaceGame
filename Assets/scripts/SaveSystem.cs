using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public static class SaveSystem 
{

   

    public static void savePlayer(PlayerData playerData)
    {

        string playerDataPath = Application.persistentDataPath + "/player01.player";
        BinaryFormatter formatter = new BinaryFormatter();        
        FileStream fileStream = new FileStream(playerDataPath, FileMode.OpenOrCreate);
        formatter.Serialize(fileStream, playerData);
       
        fileStream.Close();
    }
    public static void saveVehicle(VehicleData vehicleData,string vName)
    {

        string vehiclePath = Application.persistentDataPath + "/"+vName+".car";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(vehiclePath, FileMode.OpenOrCreate);
        formatter.Serialize(fileStream, vehicleData);

        fileStream.Close();
    }
    public static VehicleData LoadVehicle(string vName)
    {
        string vehiclePath = Application.persistentDataPath + "/" + vName + ".car";
        try
        {
            if (File.Exists(vehiclePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(vehiclePath, FileMode.OpenOrCreate);
                VehicleData vehicleData = formatter.Deserialize(fileStream) as VehicleData;
                fileStream.Close();
                return vehicleData;
            }
            return new VehicleData(1,1,1,1);
        }
        catch
        {
            return new VehicleData(1, 1, 1, 1);
        }

    }

    public static PlayerData LoadPlayer()
    {
        string playerDataPath = Application.persistentDataPath + "/player01.player";
        try
        {
            if (File.Exists(playerDataPath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(playerDataPath, FileMode.OpenOrCreate);
                PlayerData playerData = formatter.Deserialize(fileStream) as PlayerData;
                fileStream.Close();
                return playerData;
            }
            return new PlayerData(0,0,0);
        }
        catch
        {
            return new PlayerData(0, 0, 0);
        }
       
    }
    
}
