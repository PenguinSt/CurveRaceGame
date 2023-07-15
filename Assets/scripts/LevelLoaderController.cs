using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderController : MonoBehaviour
{
    public Slider slider;
    private float counter=0;
    public AudioSource bgSound;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(loadAsyncly());

        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null)
        {
            if (data.isMusicOn) bgSound.Play();
            else bgSound.Stop();
        }
        
    }

    

    IEnumerator loadAsyncly()
    {

        Debug.Log(Time.deltaTime);
        yield return new WaitForSecondsRealtime(3.5f);
        SceneManager.LoadScene(1);

    }
    private void FixedUpdate()
    {
        counter = counter + Time.fixedDeltaTime*0.5f;
        slider.value = counter+0.25f;
        Debug.Log(counter);
    }


}
