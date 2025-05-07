using UnityEngine;

public class EnemyPatron : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform puntoDeRotacion; // El objeto que contiene el SkinnedMeshRenderer
    public float velocidadRotacion = 30f;
    private Vector3 direction;
    void Start()
    {
        direction = pointA.position;
        transform.RotateAround(puntoDeRotacion.position, Vector3.up, 180f);
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
                transform.RotateAround(puntoDeRotacion.position, Vector3.up, 180f);
            }
            else
            {
                direction = pointA.position;
                transform.RotateAround(puntoDeRotacion.position, Vector3.up, 180f);
            }
        }
    }

}