using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationAnimal : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //    if(gameObject.name == "Sparrow")
    //    {
    //        gameObject.GetComponent<Animator>().Play("Run");
    //    }
    //    if(gameObject.name == "Rabbit")
    //    {
    //        gameObject.GetComponent<Animator>().Play("Run");
    //    }
    //    if (gameObject.name == "Pudu")
    //    {
    //        gameObject.GetComponent<Animator>().Play("Walk");
    //    }
    //    Offset = new Vector2(transform.position.x - 1, transform.position.x + 1);
    //}

    //// Update is called once per frame
    ////void Update()
    ////{
    ////    transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);

    ////}
    //public float Vitesse = 1;
    //public Vector2 Offset = new Vector2(-1, 1);
    //private float direction = 1;
    //// Update is called once per frame
    //void Update()
    //{
    //    if (transform.position.x > Offset.y) {
    //        // première condition "Si ..."
    //        direction = -1;
    //        transform.Rotate(new Vector3(0, 180, 0));
    //    }
    //    else if (transform.position.x < Offset.x) { // seconde si la première n'est pas vrai "Sinon si..."
    //        direction = 1;
    //        transform.Rotate(new Vector3(0, 180, 0));
    //    }


    //    transform.position = transform.position + new Vector3(Vitesse * direction * Time.deltaTime, 0, 0);  // Toujours multiplier par le temps

    //}

    //public float wanderRadius;
    //public float wanderTimer;

    //private Transform target;
    //private NavMeshAgent agent;
    //private float timer;

    //// Use this for initialization
    //void OnEnable()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    timer = wanderTimer;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;

    //    if (timer >= wanderTimer)
    //    {
    //        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
    //        agent.SetDestination(newPos);
    //        timer = 0;
    //    }
    //}

    //public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    //{
    //    Vector3 randDirection = Random.insideUnitSphere * dist;

    //    randDirection += origin;

    //    NavMeshHit navHit;

    //    NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

    //    return navHit.position;
    //}

    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameObject.GetComponent<Animator>().Play("Run");
    }


    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
