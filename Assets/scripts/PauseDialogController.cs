using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseDialogController : MonoBehaviour

{


    [SerializeField]
    private AudioSource pauseSound;
    // Start is called before the first frame update
    

    public void OnExitClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnPauseBtnClicked()
    {
        FindObjectOfType<PlayerMovementController>().enabled = false;
        pauseSound.Play();
    }
    public void OnResumeButtonClicked()
    {
        FindObjectOfType<PlayerMovementController>().enabled = true;
        gameObject.SetActive(false);

    }
    public void OnRestartBtnClicked()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
