using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleController : MonoBehaviour
{

    public GameObject bubble;
    public Vector3 upscalingChange;
    public Vector3 downsclaingChange;
    private Vector3 minimumScale;
    public Vector3 maximumScale;
    public GameController gameController;
    public PlayerInput playerInput;
    public int playerScore = 0;
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        gameController = FindAnyObjectByType<GameController>();
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (playerInput.playerIndex == 0) {
            spriteRenderer.sprite = gameController.playerOneSprite;
        } else if (playerInput.playerIndex == 1) {
            spriteRenderer.sprite = gameController.playerTwoSprite;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minimumScale = new Vector3(0, 0, 0);
        maximumScale = new Vector3(4, 4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.HasGameStarted() == true && bubble.transform.localScale.x > 0 && bubble.transform.localScale.y > 0) {
            bubble.transform.localScale += downsclaingChange;
        }
    }

    public void OnInflateA() {
        if (gameController.IsDoublePress()) {

        }
        if (gameController.HasGameStarted() == true && gameController.IsAButtonEnabled() == true && HasReachedMaxScale() == false) {
            UpdateScore();
            bubble.transform.localScale += upscalingChange;
        }
    }

    public void OnInflateB() {
        if (gameController.HasGameStarted() == true && gameController.IsBButtonEnabled() == true && HasReachedMaxScale() == false) {
            UpdateScore();
            bubble.transform.localScale += upscalingChange;
        }
    }

    public void OnInflateX() {
        if (gameController.HasGameStarted() == true && gameController.IsXButtonEnabled() == true && HasReachedMaxScale() == false) {
            UpdateScore();
            bubble.transform.localScale += upscalingChange;
        }
    }

    public void OnInflateY() {
        if (gameController.HasGameStarted() == true && gameController.IsYButtonEnabled() == true && HasReachedMaxScale() == false) {
            UpdateScore();
            bubble.transform.localScale += upscalingChange;
        }
    }

    public bool HasReachedMaxScale() {
        if (bubble.transform.localScale.x >= maximumScale.x && bubble.transform.localScale.y >= maximumScale.y) {
            return true;
        } else {
            return false;
        }
    }

    void UpdateScore() {
        gameController.UpdatePlayerScore(playerInput.playerIndex);
    }
}
