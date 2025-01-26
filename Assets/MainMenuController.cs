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
    // M�todo para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectGameScene"); 
    }

    // M�todo para mostrar las opciones (puedes implementar m�s tarde)
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

    // M�todo para salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
