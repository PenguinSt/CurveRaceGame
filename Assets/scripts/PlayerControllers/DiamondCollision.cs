using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollision : MonoBehaviour
{
    
 bool moveDiamond=false;


    void OnTriggerEnter2D(Collider2D col){
       Debug.Log("Hit Diamond");
        if(col.CompareTag("vehicle")){
            gameObject.GetComponent<Collider2D>().enabled=false;
             moveDiamond = true;
            Destroy(gameObject,0.75f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveDiamond){
          transform.Translate(new Vector3(0,5*Time.fixedDeltaTime,0));
        }
    }
}
