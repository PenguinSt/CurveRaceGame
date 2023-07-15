using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TuneItemController : MonoBehaviour
{

    [SerializeField]
    public TMP_Text priceTxt;

    [SerializeField]
    public TMP_Text upgradeNumberTxt;

    [SerializeField]
    public Slider percentSlider;

    [SerializeField]
    private GameObject dialog;

    [SerializeField]
    private Image img;


    public string desc;


    private void Start()
    {
        
    }
    public void OnTuneItemClicked()
    {
        if (percentSlider.value < 1)
        {
            dialog.GetComponent<UpgradeDialogController>().setUpgradeDialogTexts(int.Parse(priceTxt.text.ToString().Replace(" ", "")), desc, gameObject.name.ToUpper());
            dialog.SetActive(true);

            Utils.ShowScaleObj(dialog);
        }
       

    }

    


    
}
