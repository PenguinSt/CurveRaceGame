using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class SettingsController : MonoBehaviour
{

    [SerializeField]
    private Button musicToggleImg;

    [SerializeField]
    private Button soundToggleImg;

    [SerializeField]
    private Sprite toggleOnSprt;

    [SerializeField]
    private Sprite toggleOffSprt;

    private PlayerData data;

    public List<LanguageModel> languages;

    [SerializeField]
    private Image currentLangImg;

    private int currentLangIndex=0;


    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = SaveSystem.LoadPlayer();
        data = SaveSystem.LoadPlayer();
        Debug.Log("music =" + data.isMusicOn);
        Debug.Log("sound =" + data.isSoundOn);

        checkMusic();

        checkSound();

        currentLangImg.sprite = getCurrentLangSpriteFromStoredData();
       


    }

    Sprite getCurrentLangSpriteFromStoredData()
    {
        string lan = data.currentLanguage;
        Sprite sprt = languages[0].langSprt;
        languages.ForEach(lang =>
        {
            if (lang.langText.ToUpper().Contains(lan.ToUpper()))
            {
                sprt= lang.langSprt;
            }

        });
        return sprt;
    }


    

    public void checkMusic()
    {
        if (data.isMusicOn)
        {
            musicToggleImg.image.sprite = toggleOnSprt;
        }
        else
        {
            musicToggleImg.image.sprite = toggleOffSprt;
        }
    } 
    
    public void checkSound()
    {
        if (data.isSoundOn)
        {
            soundToggleImg.image.sprite = toggleOnSprt;
        }
        else
        {
            soundToggleImg.image.sprite = toggleOffSprt;
        }
    }

    public void toggleMusic()
    {

        //GameData.setMusic(!data.isMusicOn);
        if(data != null)
        {
            data.isMusicOn = !data.isMusicOn;
            SaveSystem.savePlayer(data);
            checkMusic();
            FindObjectOfType<MainMenuController>().setBgMusic(data.isMusicOn);
        }
       
    }

    public void GoToPrivacyPolicy()
    {
        Application.OpenURL("https://doc-hosting.flycricket.io/curves-race-privacy-policy/7b811a0a-ccd4-47d6-8851-12b0ce924b63/privacy");
    }

    public void toggleSound()
    {
      //  GameData.setSound(value);

        if (data != null)
        {
            data.isSoundOn = !data.isSoundOn;
            SaveSystem.savePlayer(data);
            checkSound();
        }
    }
    public void switchLanguage(int arrowDir)
    {
         
            currentLangIndex = currentLangIndex + arrowDir;
            if(currentLangIndex < 0) currentLangIndex = languages.Count-1;
            if (currentLangIndex > languages.Count - 1) currentLangIndex = 0;
        
       
       
        currentLangImg.sprite = languages[currentLangIndex].langSprt;
        LocalizationManager.Language = languages[currentLangIndex].langText;

        playerData.currentLanguage = languages[currentLangIndex].langText;
        SaveSystem.savePlayer(playerData);

       
    }
   

    
}
