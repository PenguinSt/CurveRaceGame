using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSoundPlayer : MonoBehaviour
{

    private PlayerData data;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        data = SaveSystem.LoadPlayer();

        if(data != null)
        {
            if(!data.isMusicOn)
                audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
