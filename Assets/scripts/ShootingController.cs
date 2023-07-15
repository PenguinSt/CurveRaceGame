using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPref;
    
  

    public void Shoot()
    {
       
        Instantiate(bulletPref,firePoint.position,firePoint.rotation);

    }
}
