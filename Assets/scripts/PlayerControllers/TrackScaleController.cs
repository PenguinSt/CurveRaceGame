
using UnityEngine;
using TMPro;

public class TrackScaleController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text highScroeTxt;


    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
         highScroeTxt.text=  data.highScore.ToString();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
