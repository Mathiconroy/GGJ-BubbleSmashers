using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private int sceneToContinue;
    public bool disabled = false;

    void Start()
    {
        // Comprueba si hay datos de guardado
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            disabled = false;
            this.gameObject.SetActive(true);
        }
        else
        {
            disabled = true;
            this.gameObject.SetActive(false);
        }
    }

    public void ContinueGame ()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneToContinue != 0)
        { 
            SceneManager.LoadScene(sceneToContinue);
        } else
        {
            return;
        }
    }
}
