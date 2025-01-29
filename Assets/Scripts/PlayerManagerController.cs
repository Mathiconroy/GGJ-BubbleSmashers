using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerController : MonoBehaviour
{
    public GameObject[] playerSpawnPoints;
    public GameController gameController;
    public int minimumPlayerCount = 2;
    public GameObject playerOneShadow;
    public GameObject playerTwoShadow;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /** Puedo crear los game objects y ponerles aca la posicion, y en */
    void OnPlayerJoined(PlayerInput playerInput) {
        playerInput.gameObject.transform.position = playerSpawnPoints[playerInput.playerIndex].transform.position;
        if (playerInput.playerIndex == 0) {
            playerOneShadow.transform.position = playerSpawnPoints[playerInput.playerIndex].transform.position;
        }
        if (playerInput.playerIndex == 1) {
            playerTwoShadow.transform.position = playerSpawnPoints[playerInput.playerIndex].transform.position;
        }
        if (playerInput.playerIndex >= minimumPlayerCount - 1) {
            gameController.StartGame();
        }
    }
}
