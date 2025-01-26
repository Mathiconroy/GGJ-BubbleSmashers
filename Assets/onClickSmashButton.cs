using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickSmashButton : MonoBehaviour
{
    public void StartSmash()
    {
        SceneManager.LoadScene(1);
    }
}
