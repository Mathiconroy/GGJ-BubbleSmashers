using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleController : MonoBehaviour
{

    public GameObject bubble;
    public Vector3 upscalingChange;
    public Vector3 downsclaingChange;
    private Vector3 minimumScale;
    InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minimumScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble.transform.localScale.x > 0 && bubble.transform.localScale.y > 0) {
            bubble.transform.localScale += downsclaingChange;
        }
    }

    public void OnInflate() {
        bubble.transform.localScale += upscalingChange;
    }
}
