using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleController : MonoBehaviour
{

    public GameObject bubble;
    public Vector3 upscalingChange;
    public Vector3 downscalingChange;
    public Vector3 scalingChangeInflateDeflate;
    private Vector3 minimumScale;
    public Vector3 maximumScale;
    public GameController gameController;
    public PlayerInput playerInput;
    public int playerScore = 0;
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    public Sprite inflateDeflateObjectiveSprite;

    void Awake() {
        gameController = FindAnyObjectByType<GameController>();
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (playerInput.playerIndex == 0) {
            spriteRenderer.sprite = gameController.playerOneSprite;
        } else if (playerInput.playerIndex == 1) {
            spriteRenderer.sprite = gameController.playerTwoSprite;
        }
        scalingChangeInflateDeflate = new(0.25f, 0.25f, 0);
        maximumScale = new(4, 4, 0);
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
        if (gameController.IsRandomButtons()) {
            if (gameController.HasGameStarted() == true && bubble.transform.localScale.x > 0 && bubble.transform.localScale.y > 0) {
                bubble.transform.localScale += downscalingChange;
            }
        }
    }

    public void OnInflateA() {
        if (gameController.IsRandomButtons()) {
            if (gameController.HasGameStarted() == true && gameController.IsAButtonEnabled() == true && HasReachedMaxScale() == false) {
                UpdateScore();
                bubble.transform.localScale += upscalingChange;
            }
        }
        if (gameController.HasGameStarted() && gameController.IsInflateDeflate() && HasReachedMaxScale() == false) {
            bubble.transform.localScale += scalingChangeInflateDeflate;
            CheckAndUpdateScoreInflateDeflate();
        }
    }

    public void OnInflateB() {
        if (gameController.IsRandomButtons()) {
            if (gameController.HasGameStarted() == true && gameController.IsBButtonEnabled() == true && HasReachedMaxScale() == false) {
                UpdateScore();
                bubble.transform.localScale += upscalingChange;
            }
        }
        if (gameController.HasGameStarted() && gameController.IsInflateDeflate() && HasReachedMinScale() == false) {
            bubble.transform.localScale -= scalingChangeInflateDeflate;
            CheckAndUpdateScoreInflateDeflate();
        }
    }

    public void OnInflateX() {
        if (gameController.IsRandomButtons()) {
            if (gameController.HasGameStarted() == true && gameController.IsXButtonEnabled() == true && HasReachedMaxScale() == false) {
                UpdateScore();
                bubble.transform.localScale += upscalingChange;
            }
        }
    }

    public void OnInflateY() {
        if (gameController.IsRandomButtons()) {
            if (gameController.HasGameStarted() == true && gameController.IsYButtonEnabled() == true && HasReachedMaxScale() == false) {
                UpdateScore();
                bubble.transform.localScale += upscalingChange;
            }
        }
    }

    public bool HasReachedMaxScale() {
        if (bubble.transform.localScale.x >= maximumScale.x && bubble.transform.localScale.y >= maximumScale.y) {
            return true;
        } else {
            return false;
        }
    }

    public bool HasReachedMinScale() {
        if (bubble.transform.localScale.x <= 1 && bubble.transform.localScale.y <= 1) {
            return true;
        } else {
            return false;
        }
    }

    void UpdateScore() {
        gameController.UpdatePlayerScore(playerInput.playerIndex);
    }

    void CheckAndUpdateScoreInflateDeflate() {
        if (bubble.transform.localScale.x == gameController.GetObjectiveScale().x && bubble.transform.localScale.y == gameController.GetObjectiveScale().y) {
            Debug.Log("Got to objective scaling");
            gameController.UpdatePlayerScore(playerInput.playerIndex);
        }   
    }
}
