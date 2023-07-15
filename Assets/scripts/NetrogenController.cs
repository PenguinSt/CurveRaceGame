using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NetrogenController : MonoBehaviour
{
    public TMP_Text netroValTxt;

    public void setNetroTxt(string netroStr)
    {
        netroValTxt.text = netroStr;
    }
    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null) 
        netroValTxt.text = data.netrogenValue.ToString();
    }
}
