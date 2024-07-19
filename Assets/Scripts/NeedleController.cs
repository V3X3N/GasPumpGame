using UnityEngine;

public class NeedleController : MonoBehaviour
{
    public RectTransform needle;
    public float speed = 20.0f;
    private bool movingRight = true;
    private bool isStopped = false;

    void Update()
    {
        if (!isStopped)
        {
            MoveNeedle();
        }
    }

    public void StopNeedle()
    {
        isStopped = true;
        Debug.Log("Needle stopped at angle: " + needle.localEulerAngles.z);
        CheckZone();
    }

    void CheckZone()
    {
        float angle = needle.localEulerAngles.z;
        Debug.Log("Checking zone at angle: " + angle);
    }

    void MoveNeedle()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
        {
            needle.Rotate(0, 0, -step);
            if (needle.localEulerAngles.z <= 270 && needle.localEulerAngles.z > 180)
            {
                movingRight = false;
                needle.localEulerAngles = new Vector3(0, 0, -90);
            }
        }
        else
        {
            needle.Rotate(0, 0, step);
            if (needle.localEulerAngles.z >= 90 && needle.localEulerAngles.z < 180)
            {
                movingRight = true;
                needle.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
    }
}
