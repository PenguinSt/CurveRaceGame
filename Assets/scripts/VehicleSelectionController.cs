using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSelectionController : MonoBehaviour
{

    public List<VehicleModel> vehicles;
    public CinemachineVirtualCamera virtualCamera;
    public  int currentVehicleIndex = 0;



    public static string currentVehicleIdStr="";



    // Start is called before the first frame update
    void Start()
    {
 
        for (int i = 0; i < vehicles.Count; i++)
        {
            if (currentVehicleIdStr.Equals( vehicles[i].name))
            {
               // Debug.Log("Equals--------------------------------------");
                currentVehicleIndex = i;
                break;
            }
        }
        for (int i = 0; i < vehicles.Count; i++)
        {
            vehicles[i].vehicle.gameObject.SetActive(false);
            vehicles[currentVehicleIndex].vehicle.gameObject.SetActive(true);
        }
        virtualCamera.Follow = vehicles[currentVehicleIndex].vehicle.transform;
    }


    public void idleVehicle()
    {
        vehicles[currentVehicleIndex].vehicle.GetComponent<PlayerMovementController>().idlePlayer();
    }
    public void moveForwardVehicle()
    {
        vehicles[currentVehicleIndex].vehicle.GetComponent<PlayerMovementController>().moveForward();
    }
    public void brakeVehicle()
    {
        vehicles[currentVehicleIndex].vehicle.GetComponent<PlayerMovementController>().brakePlayer();
    }

    public void MoveNetrogen()
    {
        vehicles[currentVehicleIndex].vehicle.GetComponent<PlayerMovementController>().NetrogenMove();
    }
    public void Shoot()
    {
        vehicles[currentVehicleIndex].vehicle.GetComponent<ShootingController>().Shoot();
    }
    public bool HasCurrentCarWeapon()
    {
      return  vehicles[currentVehicleIndex].hasWeapon;
    }

}
