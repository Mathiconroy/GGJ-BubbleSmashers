using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerController : MonoBehaviour
{
    public GameObject[] playerSpawnPoints;
    public GameController gameController;
    public int minimumPlayerCount = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerJoined(PlayerInput playerInput) {
        playerInput.gameObject.transform.position = playerSpawnPoints[playerInput.playerIndex].transform.position;
        Debug.Log(playerInput.playerIndex);
        if (playerInput.playerIndex >= minimumPlayerCount) {
            gameController.StartGame();
        }
    }
}
