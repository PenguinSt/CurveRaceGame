using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource fireVoice;

    // Start is called before the first frame update
    void Start()
    {
        fireVoice.Play();
        rb.velocity = transform.right * 18;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        EagleMovementController eagleMovementController = collision.GetComponent<EagleMovementController>();
        if (eagleMovementController != null)
        {
            FindObjectOfType<UIController>().ShowEaglePizeText(500);
            eagleMovementController.Die();
        }
        Destroy(gameObject);
    }
    private void Update()
    {
           //Destroy(gameObject);
        
    }


}
