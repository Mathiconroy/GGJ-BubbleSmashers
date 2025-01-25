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
        jumpAction = InputSystem.actions.FindAction("Inflate");
        // scaleChange = new Vector3(0.0005f, 0.0005f , 0);
        minimumScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.WasPressedThisFrame()) {
            bubble.transform.localScale += upscalingChange;
        } else if (bubble.transform.localScale.x > 0 && bubble.transform.localScale.y > 0) {
            bubble.transform.localScale += downsclaingChange;
        }
    }
}
