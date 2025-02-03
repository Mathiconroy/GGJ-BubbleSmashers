using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public enum Screens {
        MainMenu,
        Credits,
        GameSelect,
    }

    public Screens currentScreen = Screens.MainMenu;
    public Button continueButton;
    public GameObject mainMenuObject;
    public GameObject creditsObject;

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
        Application.Quit();
    }

    public void ToCredits() {
        currentScreen = Screens.Credits;
        mainMenuObject.SetActive(false);
        creditsObject.SetActive(true);
    }

    public void ToMainMenu() {
        currentScreen = Screens.MainMenu;
        mainMenuObject.SetActive(true);
        creditsObject.SetActive(false);
    }
}
