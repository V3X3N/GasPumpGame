using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public NeedleController needleController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button clicked");
            needleController.StopNeedle();
        }
    }
}
