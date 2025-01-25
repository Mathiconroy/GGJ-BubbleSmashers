using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerController : MonoBehaviour
{
    public GameObject[] playerSpawnPoints;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayerJoined(PlayerInput playerInput) {
        Debug.Log(playerInput);
        playerInput.gameObject.transform.position = playerSpawnPoints[playerInput.playerIndex].transform.position;
        Debug.Log("Player joined");
    }
}
