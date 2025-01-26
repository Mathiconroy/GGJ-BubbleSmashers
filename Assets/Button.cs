using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentButtonPlayer1;
    [SerializeField] TextMeshProUGUI currentButtonPlayer2;
    GameController gameController;
    string currentButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindAnyObjectByType<GameController>();

        if (gameController.IsRandomButtons()) {
            SetCurrentButton();
        } else if (gameController.IsInflateDeflate()) {
            currentButtonPlayer1.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsRandomButtons()) {
            SetCurrentButton();
            currentButtonPlayer1.text = currentButton;
            currentButtonPlayer2.text = currentButton;
        }
    }

    void SetCurrentButton() {
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
}
