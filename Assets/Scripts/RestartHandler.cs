using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour
{
    private static RestartHandler instance;
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
            playerHealth.currentHealth = 100;
            SceneManager.LoadScene("Ocean");
        }
    }

}
