using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour
{

    private int currentSceneIndex;

    public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);

    }
}
