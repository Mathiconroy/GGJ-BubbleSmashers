using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public enum GameModes {
        Normal,
        DoublePress,
    }

    public enum GameState {
        GameStarted = 0,
        GameNotStarted = 1,
    }

    public enum GameButtons {
        A,
        B,
        X,
        Y,
        None,
    }

    public GameModes gameMode;
    public GameButtons enabledButton;
    public GameState currentGameState;
    public InputActionAsset inputActions;
    float timeToChange = 3.0f;
    public float gameDuration = 20.0f;
    public int scorePerPress = 200;
    public int scoreSubstractionPerFrame = 2;
    public int[] playerScores;
    public Sprite playerOneSprite;
    public Sprite playerTwoSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // enabledButton = GameButtons.A;
        playerScores[0] = 0;
        playerScores[1] = 0;
        currentGameState = GameState.GameNotStarted;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasGameStarted()) {
            gameDuration -= Time.deltaTime;
            timeToChange -= Time.deltaTime;
            if (timeToChange <= 0) {
                System.Random random = new();
                float newNumber = random.Next(1, 3);
                timeToChange = newNumber;
                ChangeEnabledButton();
                Debug.Log("Input changed.");
            }
            if (gameDuration <= 0) {
                EndGame();
            }
            SubstractFromScore();
        }
    }

    public void StartGame() {
        currentGameState = GameState.GameStarted;
    }

    public bool HasGameStarted() {
        return currentGameState == GameState.GameStarted;
    }

    public void DisableInput() {
        enabledButton = GameButtons.None;
    }

    public bool IsAButtonEnabled() {
        return enabledButton == GameButtons.A;
    }

    public bool IsBButtonEnabled() {
        return enabledButton == GameButtons.B;
    }

    public bool IsXButtonEnabled() {
        return enabledButton == GameButtons.X;
    }

    public bool IsYButtonEnabled() {
        return enabledButton == GameButtons.Y;
    }

    public void ChangeEnabledButton() {
        GameButtons[] buttons = {GameButtons.A, GameButtons.B, GameButtons.X, GameButtons.Y};
        System.Random random = new();
        int randomIndex = random.Next(0, buttons.Length);
        enabledButton = buttons[randomIndex];
    }

    public void EndGame() {
        currentGameState = GameState.GameNotStarted;
    }

    public void UpdatePlayerScore(int playerIndex) {
        playerScores[playerIndex] += scorePerPress;
    }

    public void SubstractFromScore() {
        playerScores[0] -= scoreSubstractionPerFrame;
        playerScores[1] -= scoreSubstractionPerFrame;
    }
}
