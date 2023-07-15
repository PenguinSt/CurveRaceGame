using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowPSController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FindObjectOfType<VehicleSelectionController>().vehicles[FindObjectOfType<VehicleSelectionController>().currentVehicleIndex].transform.position+new Vector3(0,+12,0);
    }
}
