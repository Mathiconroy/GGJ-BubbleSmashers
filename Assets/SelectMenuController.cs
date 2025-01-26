using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenuController : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
