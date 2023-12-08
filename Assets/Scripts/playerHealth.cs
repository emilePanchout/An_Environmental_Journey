using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private bool healthDisplayed = false;
    public static float currentHealth = 100f;
    public TMP_Text healthText;
    public AudioSource lowHealth;
    public float decreaseSpeed;
    public GameObject eatObject;
    public GameObject teleportObject;

    [SerializeField]
    private readonly DeleteScript deleteScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !healthDisplayed) {
            InvokeRepeating("DecreaseHealth", 0f, decreaseSpeed);

            healthDisplayed = true;
            UpdateHealthText();
        }

        if (currentHealth > 0f && currentHealth <= 10f)
        {
            PlayLowHealthSound();
            healthText.color = Color.red;
        }
        else
        {
            healthText.color = Color.white;
            StopLowHealthSound();
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("End Scene");
        }
    }

    private void DecreaseHealth()
    {
        currentHealth--;

        UpdateHealthText();

        if (currentHealth <= 0) {
            CancelInvoke("DecreaseHealth");
        }
    }

    public void onEat(string type)
    {

        if (type == "Eatable")
        {
            StartCoroutine(HealthFeedback(Color.green));

            if (currentHealth < 91)
            {
                currentHealth += 10;
                UpdateHealthText();
            }
            else
            {
                currentHealth = 100;
                UpdateHealthText();
            }
        }
        else if (type == "Trash")
        {
            StartCoroutine(HealthFeedback(Color.red));
            
            if (currentHealth > 10)
            {
                currentHealth -= 10;
                UpdateHealthText();
            }
            else
            {
                currentHealth = 0;
                UpdateHealthText();
            }
        }

    }

    public void UpdateHealthText()
    {
        healthText.text = "Santé: " + currentHealth;
        //if (currentHealth == 0)
        //{
        //    healthText.text = "Votre vie aquatique virtuelle s'est éteinte en rasion de la pollution plastique. " +
        //        "La réalité est tout aussi grave. Agissons ensemble pour préserver nos océans et protéger la diversité marine!";
        //}
    }

    void PlayLowHealthSound()
    {
        if (lowHealth != null && !lowHealth.isPlaying)
        {
            lowHealth.Play();
        }
    }

    void StopLowHealthSound()
    {
        if (lowHealth != null && lowHealth.isPlaying)
        {
            lowHealth.Stop();
        }
    }

    IEnumerator HealthFeedback(Color color)
    {
        healthText.color = color;
        yield return new WaitForSeconds(1f);

        //    if (currentHealth > 11)
        //    {
        //        healthText.color = Color.white;
        //    }
        //    else healthText.color = Color.red;
    }

}
