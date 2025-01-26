using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour
{
    GameController gameController;
    bool disabled = false;
    private void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
        disabled = Convert.ToBoolean(gameController.currentGameState);
    }

    void Update()
    {
        disabled = Convert.ToBoolean(gameController.currentGameState);

        if (!disabled)
        {
            this.gameObject.SetActive(false);
        } else
        {
            this.gameObject.SetActive(true);
        }

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
