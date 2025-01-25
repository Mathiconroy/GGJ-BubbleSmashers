using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // M�todo para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectGameScene"); // Reemplaza "GameScene" con el nombre de tu escena de juego
    }

    // M�todo para mostrar las opciones (puedes implementar m�s tarde)
    public void ContinueGame()
    {
        SceneManager.LoadScene("SelectGameScene");
    }

    // M�todo para salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
