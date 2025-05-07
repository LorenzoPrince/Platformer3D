using UnityEngine;

public class ScriptFloor : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 5f;

    private Vector3 direction;
    void Start()
    {
        direction = pointA.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, direction) < 0.1f)
        {
            if (direction == pointA.position)
            {
                direction = pointB.position;

            }
            else
            {
                direction = pointA.position;

            }
        }
    }

}
