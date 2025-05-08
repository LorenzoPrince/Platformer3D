using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip musicaDeFondo;  // Asignar la música desde el Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Si no existe un AudioSource, crea uno en este GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicaDeFondo;
        audioSource.loop = true; // Repetir la música
        audioSource.Play();

        // Evitar que el GameObject de música se destruya al cargar la siguiente escena IMPORTANTE
        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        Debug.Log("Iniciandote juego...");
        SceneManager.LoadScene("PlataformMap");
    }
    public void Exit()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
