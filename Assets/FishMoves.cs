using UnityEngine;

public class FishMoves : MonoBehaviour
{

    private Vector3 movementDirection;
    private float speed;
    private float minY = -2.0f;
    private float maxHeight = 15;

    public void setMovementParameters(Vector3 direction, float fishSpeed)
    {
        movementDirection = direction.normalized;
        speed = fishSpeed;
        transform.forward = movementDirection * 180;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Don't go through the floor please
        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxHeight);
        transform.position = currentPosition;

        // Fish movement
        transform.Translate(movementDirection * speed * Time.deltaTime);

        // Random direction change
        if (Random.value < 0.01f)
        {
            movementDirection = Random.insideUnitSphere.normalized;
        }
    }
}
