using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void StartGame()
    {
        Debug.Log("Iniciandote juego...");
        //SceneManager.LoadScene("PlataformMap");
        SceneManager.LoadScene("PlataformMap");
    }
    public void Exit()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
