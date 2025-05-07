using UnityEngine;

public class ScriptFlipEnemy : MonoBehaviour
{
    private SpriteRenderer spritePerso;
    public GameObject referencia; // El GameObject con el que se compara la posición del personaje

    // Start is called before the first frame update
    void Start()
    {
        spritePerso = GetComponentInChildren<SpriteRenderer>(); // Acceder al SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        if (referencia == null)
            return; // Si no hay una referencia asignada, no hacer nada

        // Compara la posición en el eje X del personaje con la del objeto de referencia
        if (transform.position.x > referencia.transform.position.x) // Si el personaje está a la izquierda de la referencia
        {
            // Voltea el sprite hacia la izquierda
            spritePerso.flipX = true;
            // Asegúrate de que no está rotado en el eje Z (opcional, dependiendo de tu configuración)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x < referencia.transform.position.x) // Si el personaje está a la derecha de la referencia
        {
            // Voltea el sprite hacia la derecha (sin invertir en el eje X)
            spritePerso.flipX = false;
            // Asegúrate de que no está rotado en el eje Z (opcional, dependiendo de tu configuración)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}