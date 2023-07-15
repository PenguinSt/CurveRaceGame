using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleItemData : MonoBehaviour
{
    public string name;
    public Image img;
    public int price;
    public bool isLocked;
    public int id;
    public GameObject pricingUIObj;

 //   public List<VehicleItemData> vehicles=new List<VehicleItemData>();

    public  VehicleItemData(string n , Image i, int p , bool l,int pId,GameObject pricingObj ){
        name = n;
        img = i;
        price = p;
        isLocked=l;
        id = pId;
        pricingUIObj=pricingObj;
    }


}
