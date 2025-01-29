using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject currentButtonImage;
    GameController gameController;
    public Sprite aButtonSprite;
    public Sprite bButtonSprite;
    public Sprite xButtonSprite;
    public Sprite yButtonSprite;
    [SerializeField] Sprite currentButtonSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindAnyObjectByType<GameController>();

        if (gameController.IsRandomButtons()) {
            SetCurrentButton();
        } else if (gameController.IsInflateDeflate()) {
            currentButtonImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsRandomButtons()) {
            SetCurrentButton();
            currentButtonImage.GetComponent<Image>().sprite = currentButtonSprite;
        }
    }

    void SetCurrentButton() {
        if (gameController.IsAButtonEnabled() == true)
        {
            currentButtonSprite = aButtonSprite;
        }
        if (gameController.IsBButtonEnabled() == true)
        {
            currentButtonSprite = bButtonSprite;
        }
        if (gameController.IsYButtonEnabled() == true)
        {
            currentButtonSprite = yButtonSprite;
        }
        if (gameController.IsXButtonEnabled() == true)
        {
            currentButtonSprite = xButtonSprite;
        }
    }
}
