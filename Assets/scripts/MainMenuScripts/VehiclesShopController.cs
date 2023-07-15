using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class VehiclesShopController : MonoBehaviour
{
    public List<Button> vehiclesList;
    



    private void Start()
    {

        Debug.Log("OnStartToneOpCntl");
        vehiclesList.ForEach(v => {
            v.onClick.AddListener(() => OnItemButtonClicked(v));

            // setTunesListValues(v);

        });


    }
    

   

    private void OnItemButtonClicked(Button v)
    {
        Debug.Log("OnVehicleButtonClicked " + v.name);
        vehiclesList.ForEach(t => {
            t.transform.localScale = Vector3.one;
            t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y, 0);

        });
        // v.transform.position = new Vector3(v.transform.position.x, 350, 0);
        v.transform.localScale = new Vector3(1.25f, 1.25f, 1.2f);


    }



}
