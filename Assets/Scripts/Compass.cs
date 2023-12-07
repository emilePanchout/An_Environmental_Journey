using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{

    public Transform player;
    public RawImage compass;

    // Update is called once per frame
    void Update()
    {
        float uvX = player.localEulerAngles.y / 360f; 
        compass.uvRect = new Rect(uvX, 0, 1, 1);
    }
}
