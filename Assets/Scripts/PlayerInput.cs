using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public NeedleController needleController;
    public RectTransform gasPump;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 localMousePosition = Input.mousePosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(gasPump, localMousePosition))
            {
                Debug.Log("Gas pump clicked");
                needleController.StartNeedle();
            }
        }
    }
}
