using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickMatchButton : MonoBehaviour
{
    public void StartMatch()
    {
        SceneManager.LoadScene(1);
    }
}
