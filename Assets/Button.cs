using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentButtonPlayer1;
    [SerializeField] TextMeshProUGUI currentButtonPlayer2;
    string currentButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController gameController = FindAnyObjectByType<GameController>();

        if (gameController.IsAButtonEnabled() == true)
        {
            currentButton = "A";
        }
        if (gameController.IsBButtonEnabled() == true)
        {
            currentButton = "B";
        }
        if (gameController.IsYButtonEnabled() == true)
        {
            currentButton = "Y";
        }
        if (gameController.IsXButtonEnabled() == true)
        {
            currentButton = "X";
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameController gameController = FindAnyObjectByType<GameController>();
        if (gameController.IsAButtonEnabled() == true)
        {
            currentButton = "A";
        }
        if (gameController.IsBButtonEnabled() == true)
        {
            currentButton = "B";
        }
        if (gameController.IsYButtonEnabled() == true)
        {
            currentButton = "Y";
        }
        if (gameController.IsXButtonEnabled() == true)
        {
            currentButton = "X";
        }
        currentButtonPlayer1.text = currentButton;
        currentButtonPlayer2.text = currentButton;
    }
}
