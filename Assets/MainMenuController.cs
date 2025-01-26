using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button continueButton;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)  || Input.GetKeyUp(KeyCode.Return))
        {
            ExitGame();
        }
    }
    // Método para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectGameScene"); 
    }

    // Método para mostrar las opciones (puedes implementar más tarde)
    public void ContinueGame()
    {
        SceneManager.LoadScene("SelectGameScene");
    }

    public void SaveGame(string sceneName)
    {
        PlayerPrefs.SetString("SavedScene", sceneName);
        PlayerPrefs.Save();
        Debug.Log("Partida guardada: " + sceneName);
    }

    // Método para salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
