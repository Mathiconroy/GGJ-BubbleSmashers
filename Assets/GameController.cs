using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public enum GameModes {
        RandomButtons,
        DoublePress,
        InflateDeflate,
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
    float timeToChange = 2.0f;
    public float gameDuration = 20.0f;
    public int scorePerPress = 200;
    public int scoreSubstractionPerFrame = 2;
    public int[] playerScores;
    public Sprite playerOneSprite;
    public Sprite playerTwoSprite;
    public Vector3 objectiveScaleInflateDeflate;
    public GameObject playerOneShadow;
    public GameObject playerTwoShadow;
    public int playerOneWonRounds;
    public int playerTwoWonRounds;
    public GameObject playerOneWinSprite;
    public GameObject playerTwoWinSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomGameMode = PlayerPrefs.GetInt("play_mode");
        if (randomGameMode == 0) {
            gameMode = GameModes.RandomButtons;
        } else if (randomGameMode == 1) {
            gameMode = GameModes.InflateDeflate;
        }
        playerScores[0] = 0;
        playerScores[1] = 0;
        currentGameState = GameState.GameNotStarted;
        if (IsInflateDeflate()) {
            GenerateObjectiveInflateDeflate();
        }
        if (IsRandomButtons()) {
            playerOneShadow.SetActive(false);
            playerTwoShadow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HasGameStarted()) {
            gameDuration -= Time.deltaTime;
            
            if (IsRandomButtons()) {
                timeToChange -= Time.deltaTime;
                if (timeToChange <= 0) {
                    System.Random random = new();
                    float newNumber = random.Next(1, 3);
                    timeToChange = newNumber;
                    ChangeEnabledButton();
                }
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
        if (playerScores[0] > playerScores[1]) {
            playerOneWinSprite.SetActive(true);
        } else if (playerScores[0] < playerScores[1]) {
            playerTwoWinSprite.SetActive(true);
        } else {
            playerOneWinSprite.SetActive(true);
            playerTwoWinSprite.SetActive(true);
        }
    }

    public void ResetGame() {

    }

    public void UpdatePlayerScore(int playerIndex) {
        playerScores[playerIndex] += scorePerPress;
        if (IsInflateDeflate()) {
            GenerateObjectiveInflateDeflate();
        }
    }

    public void SubstractFromScore() {
        playerScores[0] -= scoreSubstractionPerFrame;
        playerScores[1] -= scoreSubstractionPerFrame;
    }

    public bool IsDoublePress() {
        return gameMode == GameModes.DoublePress;
    }

    public bool IsInflateDeflate() {
        return gameMode == GameModes.InflateDeflate;
    }

    public bool IsRandomButtons() {
        return gameMode == GameModes.RandomButtons;
    }

    public Vector3 GetObjectiveScale() {
        return objectiveScaleInflateDeflate;
    }

    public void GenerateObjectiveInflateDeflate() {
        System.Random random = new();
        float newScalingObjectiveValue = 1 + 0.25f * random.Next(1, 12);
        objectiveScaleInflateDeflate = new(newScalingObjectiveValue, newScalingObjectiveValue, 0);
        playerOneShadow.transform.localScale = objectiveScaleInflateDeflate;
        playerTwoShadow.transform.localScale = objectiveScaleInflateDeflate;
    }
}
