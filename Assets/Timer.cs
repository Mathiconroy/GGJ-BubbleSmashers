using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    GameController gameController;

    private void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
        elapsedTime = gameController.gameDuration;
    }
    
    // Update is called once per frame
    void Update()
    {
        elapsedTime = gameController.gameDuration;
        int seconds = Mathf.FloorToInt(elapsedTime);
        if (seconds > 0)
        {
            timerText.text = seconds.ToString();
        } else
        {
            timerText.text = "0";
        }
    }
}
