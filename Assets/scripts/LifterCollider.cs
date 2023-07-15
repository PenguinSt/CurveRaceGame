using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifterCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject lifter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("vehicle"))
        {
            LeanTween.moveLocalY(lifter, 3.6f, 1.5f);
        }
    }

}
