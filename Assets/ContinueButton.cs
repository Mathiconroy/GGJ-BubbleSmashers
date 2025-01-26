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
            disabled = false; // Habilita el botón si hay una partida guardada.
        }
        else
        {
            disabled = true; // Deshabilita el botón si no hay datos de guardado.
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
