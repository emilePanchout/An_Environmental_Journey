using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAnimal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Sparrow")
        {
            gameObject.GetComponent<Animator>().Play("Run");
        }
        if(gameObject.name == "Rabbit")
        {
            gameObject.GetComponent<Animator>().Play("Run");
        }
        if (gameObject.name == "Pudu")
        {
            gameObject.GetComponent<Animator>().Play("Run");
        }
        Offset = new Vector2(transform.position.x - 1, transform.position.x + 1);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);

    //}
    public float Vitesse = 1;
    public Vector2 Offset = new Vector2(-1, 1);
    private float direction = 1;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > Offset.y) {
            // première condition "Si ..."
            direction = -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (transform.position.x < Offset.x) { // seconde si la première n'est pas vrai "Sinon si..."
            direction = 1;
            transform.Rotate(new Vector3(0, 180, 0));
        }


        transform.position = transform.position + new Vector3(Vitesse * direction * Time.deltaTime, 0, 0);  // Toujours multiplier par le temps
        
    }
}
