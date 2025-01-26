using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class onClickSmashButton : MonoBehaviour
{
    public void StartSmash()
    {
        PlayerPrefs.SetInt("play_mode", 0);
        SceneManager.LoadScene(1);
    }
}
