using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    public float Jumpforce;
    public UnityEngine.Vector3 imputVector;
    public Rigidbody rigidBody;
    public bool isGrounded;
    public Collision contraLoQueChoque;

    public GameObject goal;

    public int collectedItems;
    public int totalItems;

    public TMPro.TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        totalItems = GameObject.FindGameObjectsWithTag("Point").Length;

        rigidBody = GetComponent<Rigidbody>();
        isGrounded = true;

        UpdateScore();

    }

    private void UpdateScore()
    {
        // Update score in screen
        scoreText.text = collectedItems + " / " + totalItems;
    }

    // Update is called once per frame
    void Update()
    {
        imputVector.x = Input.GetAxis("Horizontal");
        imputVector.y = Input.GetAxis("Vertical");

        rigidBody.AddForce(imputVector.x * speed, 0f, imputVector.y * speed, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rigidBody.AddForce(0f, Jumpforce, 0f, ForceMode.Impulse); //si no esta el forcemode.impulse lo toma automatico
            isGrounded = false;                                                          //como .force  (recomendado para motores, aceleracion gradual, etc) que hara que
                                                                                         //cada vez que toque incremente la velocidad de salto en cambio con este (impulse) la velocidad es de una.
        }

    }
    private void OnCollisionEnter(Collision contraLoQueChoque)
    {
        Debug.Log("choque contra " + contraLoQueChoque.gameObject.name);
        if (contraLoQueChoque.gameObject.CompareTag("pizo"))
        {
            isGrounded = true;
        }
        if (contraLoQueChoque.gameObject.CompareTag("KillZone"))

        {
            Debug.Log("Kill me");

            SceneManager.LoadScene(0);

        }
        if (contraLoQueChoque.gameObject.CompareTag("Dead"))

        {
            Debug.Log("Dead");
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                NextLevel();
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                NextLevel1();
            }


        }
        if (contraLoQueChoque.gameObject.CompareTag("Gold"))
        {
            victory();
        }

    }

    private void collectionItem(Collider contraLoQueChoque)
    {
        Destroy(contraLoQueChoque.gameObject);
        collectedItems++;
        UpdateScore();

        if (collectedItems == totalItems)
        {

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                NextLevel1();
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                victory();
            }



        }
    }

    private static void victory()
    {
        SceneManager.LoadScene("Victory");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tocando el objeto" + other.gameObject.name);

        if (other.gameObject.CompareTag("Point"))
        {
            collectionItem(other);

        }

    }
    void NextLevel1()

    {
        SceneManager.LoadScene("level2");


    }
    void NextLevel()

    {
        SceneManager.LoadScene("level1");


    }

}

