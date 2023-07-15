using UnityEngine;

public class VehicleModel : MonoBehaviour 
{
   public string id;
   public  GameObject vehicle;
   public bool hasWeapon=false;


    private void Start()
    {
        id= gameObject.name;
        FindObjectOfType<UIController>().showShootingObj(hasWeapon);
       
    }
}

