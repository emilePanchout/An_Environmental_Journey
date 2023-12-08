using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour
{
    private static RestartHandler instance;
    public TextMeshProUGUI infoText;
    public AudioSource countdownSound;
    public InputActionReference startRef;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (startRef.action.triggered) {
            if (TextNav.allowRestart)
            {
                if ((SceneManager.GetActiveScene().name).Equals("Home")){
                    StartCoroutine(Countdown());
                }
            }
        }
    }

    IEnumerator Countdown()
    {
        countdownSound.Play();
        TextNav.allowRestart = false;

        for (int i = 3; i > 0; i--)
        {
            infoText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        playerHealth.currentHealth = 100;
        SceneManager.LoadScene("Ocean");
    }


}
