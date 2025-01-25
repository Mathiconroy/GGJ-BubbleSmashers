using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    // Update is called once per frame

    private void Start()
    {
        GameController gameController = FindAnyObjectByType<GameController>();
        elapsedTime = gameController.gameDuration;
    }
    void Update()
    {
        GameController gameController = FindAnyObjectByType<GameController>();
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
