using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Método para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectGameScene"); // Reemplaza "GameScene" con el nombre de tu escena de juego
    }

    // Método para mostrar las opciones (puedes implementar más tarde)
    public void ContinueGame()
    {
        SceneManager.LoadScene("SelectGameScene");
    }

    // Método para salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
