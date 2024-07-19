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
        Debug.Log("Needle stopped at angle: " + GetNeedleAngle());
        CheckZone();
    }

    void CheckZone()
    {
        float angle = GetNeedleAngle();
        Debug.Log("Checking zone at angle: " + angle);
    }

    float GetNeedleAngle()
    {
        float angle = needle.localEulerAngles.z;
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }

    void MoveNeedle()
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
        {
            needle.Rotate(0, 0, -step);
            if (GetNeedleAngle() <= -90)
            {
                movingRight = false;
                needle.localEulerAngles = new Vector3(0, 0, -90);
            }
        }
        else
        {
            needle.Rotate(0, 0, step);
            if (GetNeedleAngle() >= 90)
            {
                movingRight = true;
                needle.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
    }
}
