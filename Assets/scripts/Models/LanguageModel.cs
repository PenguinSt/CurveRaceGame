using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageModel : MonoBehaviour
{
    public string langText;
    public Sprite langSprt;
    public string txtLangKey;

    public LanguageModel(string langText,Sprite sprt)
    {
        this.langText = langText;
        this.langSprt = sprt;
    }
    public LanguageModel(string langText, string key)
    {
        this.langText = langText;
        this.txtLangKey = key;
    }

}
