using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame_1()
    { 
        SceneManager.LoadScene(1); 
    }

    public void StartGame_2()
    {
        SceneManager.LoadScene(1);
    }

}
