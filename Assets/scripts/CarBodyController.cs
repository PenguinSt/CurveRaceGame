using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBodyController : MonoBehaviour
{
    public bool isCarInAir = false;

    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector2.up),100);

        // If it hits something...
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
                   
               // Debug.Log(hit.collider.name+ "  distance =" + (distance-1.3f));
            Debug.DrawRay(transform.position,Vector2.down, Color.yellow);
            float d = distance - 1.25f;

            if(d > 1.5f)
            {
                FindObjectOfType<UIController>().showAirTimeText((int)transform.position.y + 20);
                isCarInAir=true;
               // Debug.Log("car on air");
            }
            if (d >= -0.11 && d <= 0.25)
            {
                isCarInAir=false;
               // Debug.Log("car not air");
            }
            
        }
    }
}
