using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public enum GameState {
        GameStarted = 0,
        GameNonStarted = 1,
    }

    public enum GameButtons {
        A,
        B,
        X,
        Y,
        None,
    }

    public GameButtons enabledButton;
    public GameState currentGameState;
    public InputActionAsset inputActions;
    float timeToChange = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // enabledButton = GameButtons.A;
        currentGameState = GameState.GameNonStarted;
    }

    // Update is called once per frame
    void Update()
    {
        timeToChange -= Time.deltaTime;
        if (timeToChange <= 0) {
            timeToChange = 5.0f;
            ChangeEnabledButton();
            Debug.Log("Input changed.");
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
        string[] buttons = {"A", "B", "X", "Y"};
        System.Random random = new();
        int randomIndex = random.Next(0, buttons.Length);
        string randomButton = buttons[randomIndex];
        Debug.Log(randomButton);
        if (randomButton == "A") {
            enabledButton = GameButtons.A;
        } else if (randomButton == "B") {
            enabledButton = GameButtons.B;
        } else if (randomButton == "X") {
            enabledButton = GameButtons.X;
        } else if (randomButton == "Y") {
            enabledButton = GameButtons.Y;
        }
    }
}
