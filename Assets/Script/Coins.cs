using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    public int collectedItems;
    public int totalItems;
    public TMPro.TextMeshProUGUI scoreText;
    private int pointsToAdd;

    public AudioSource audioSource; //lamo para el audio
    void Start()
    {

            collectedItems = 0;
            scoreText.text = collectedItems + " ";
    }



    // Update is called once per frame

    private void UpdateScore()
    {
        // Update score in screen
        scoreText.text = collectedItems + " ";
    }


    private void CollectItem(string tag)
    {

        switch (tag)
        {
            case "Coin1":
                pointsToAdd = 1;
                break;
            case "Coin2":
                pointsToAdd = 3;
                break;
            case "Coin3":
                pointsToAdd = 5;
                break;
        }
        collectedItems += pointsToAdd;
        PlayerPrefs.SetInt("CollectedCoins", collectedItems);  // Guardar el número de monedas en PlayerPrefs
        PlayerPrefs.Save();  // Guardar los cambios
        UpdateScore();


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tocando el objeto: " + other.gameObject.name);

        //verificacion de etiqueta
        if (other.CompareTag("Coin1") || other.CompareTag("Coin2") || other.CompareTag("Coin3"))
        {
            CollectItem(other.tag);  //lamamo funcion con el objeto y su etiqueta
            if (audioSource != null)
            {
                // Reproduce el sonido solo si el AudioSource anda prueba pq no me andaba. arreglado.
                audioSource.Play();
                Debug.Log("Reproduciendo sonido");
            }
            else
            {
                Debug.LogError("AudioSource no está asignado correctamente.");
            }

            Destroy(other.gameObject);
        }

    }
}
