using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickMatchButton : MonoBehaviour
{
    public void StartMatch()
    {
        PlayerPrefs.SetInt("play_mode", 1);
        SceneManager.LoadScene(1);
    }
}
