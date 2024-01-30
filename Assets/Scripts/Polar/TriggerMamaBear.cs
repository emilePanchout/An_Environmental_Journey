using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMamaBear : MonoBehaviour
{
    public CatchManager catchManager;
    public GameObject babyBear;
    public GameObject arrow;
    public GameObject hellicoArrow;
    public bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MamaBearCollider"))
        {
            isTriggered = true;
            catchManager.playerHasBear = false;

            catchManager.bearSlot.SetActive(false);
            babyBear.SetActive(true);

            arrow.SetActive(false);
            hellicoArrow.SetActive(true);
        }
    }
}
