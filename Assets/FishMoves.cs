using UnityEngine;

public class FishMoves : MonoBehaviour
{

    private Vector3 movementDirection;
    private float speed;

    public void setMovementParameters(Vector3 direction, float fishSpeed)
    {
        movementDirection = direction.normalized;
        speed = fishSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);

        if (Random.value < 0.01f)
        {
            movementDirection = Random.insideUnitSphere.normalized;
        }
    }
}
