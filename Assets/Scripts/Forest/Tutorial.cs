using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<Fire> fire;
    public GameObject teleportArea;
    public GameObject UI;
    public GameObject Teleport;

    private void Start()
    {
        teleportArea.SetActive(false);
    }
    public void StartGame()
    {
        Teleport.SetActive(false);
        UI.SetActive(false);
        foreach(Fire script in fire)
        {
            script.StartFire();
        }
        teleportArea.SetActive(true);
        gameObject.SetActive(false);
    }
}
