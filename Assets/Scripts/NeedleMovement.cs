using UnityEngine;

public class NeedleMovement : MonoBehaviour, INeedleMovement
{
    private bool movingRight = true;

    public void MoveNeedle(float speed)
    {
        float step = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.Rotate(0, 0, -step);
            if (GetAngle() <= -90)
            {
                SetDirection(false);
                transform.localEulerAngles = new Vector3(0, 0, -90);
            }
        }
        else
        {
            transform.Rotate(0, 0, step);
            if (GetAngle() >= 90)
            {
                SetDirection(true);
                transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
    }

    public void SetDirection(bool movingRight)
    {
        this.movingRight = movingRight;
    }

    public float GetAngle()
    {
        float angle = transform.localEulerAngles.z;
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }
}
