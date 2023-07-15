using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovementController : MonoBehaviour
{
    public int eagleSpeed = 5;
    public float fallValue=-0.2f;
    public Transform camera;
    public AudioSource eagleVoice;
    private bool eagleVoicePlayingLeft = false;
    private bool eagleVoicePlayingRight = false;
    public bool isEagelLeft = true;
    public ParticleSystem featherPS;
   
    // Start is called before the first frame update
    void Start()
    {
     
        
      if(isEagelLeft)  transform.position = new Vector3(camera.transform.position.x-15, camera.transform.position.y+5, 0);
      if (!isEagelLeft) transform.position = new Vector3(camera.transform.position.x + 100, camera.transform.position.y + 5, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        featherPS.transform.position = transform.position;
        if(transform.position.x >=camera.position.x-15&&!eagleVoicePlayingLeft && isEagelLeft)
        {
            eagleVoice.Play();
            eagleVoicePlayingLeft = true;
           
        }
        if (transform.position.x <= camera.position.x + 15 && !eagleVoicePlayingRight && !isEagelLeft)
        {
            eagleVoice.Play();
            eagleVoicePlayingRight = true;
           
        }
        transform.position = new Vector3(transform.position.x + eagleSpeed*Time.fixedDeltaTime,transform.position.y-fallValue*Time.fixedDeltaTime, transform.position.z);
    }
    public void Die()
    {
        
        featherPS.Play();
        Destroy(gameObject);
    }
}
