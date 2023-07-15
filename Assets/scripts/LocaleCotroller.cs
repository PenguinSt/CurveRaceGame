using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization;
using UnityEngine;

public class LocaleCotroller : MonoBehaviour
{
   public void Awake()
    {
       
        LocalizationManager.Read();
        LocalizationManager.Language = "English";
        PlayerData data = SaveSystem.LoadPlayer();
        if (data.currentLanguage != null)
            LocalizationManager.Language = data.currentLanguage;
    }
}
