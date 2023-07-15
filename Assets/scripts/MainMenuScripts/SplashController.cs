using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null )
        FindObjectOfType<MainMenuController>().setScoreTexts(data.coins.ToString(), data.GEMS.ToString());

    }

    // Update is called once per frame
    
}
