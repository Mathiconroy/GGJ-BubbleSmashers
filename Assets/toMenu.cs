using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Return))
        {
            LoadMainMenu();
        }
    }

    private int currentSceneIndex;

    public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);

    }
}
