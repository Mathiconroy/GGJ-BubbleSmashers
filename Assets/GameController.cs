using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState {
        GameStarted = 0,
        GameNonStarted = 1,
    }

    public GameState currentGameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameState = GameState.GameNonStarted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        currentGameState = GameState.GameStarted;
    }

    public bool IsGameStarted() {
        return currentGameState == GameState.GameStarted;
    }
}
