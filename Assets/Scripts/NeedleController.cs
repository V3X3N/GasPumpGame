using UnityEngine;
using TMPro;

public class NeedleController : MonoBehaviour
{
    public RectTransform needle;
    public GameObject speedometerUI;
    public float speed = 20.0f;
    public float timeLimit = 5.0f;
    public TextMeshProUGUI countdownText;
    private bool movingRight = true;
    private bool isStopped = false;
    private bool isStarted = false;
    private float remainingTime;

    void Start()
    {
        remainingTime = timeLimit;
        speedometerUI.SetActive(false);
    }

    void Update()
    {
        if (isStarted && !isStopped)
        {
            MoveNeedle();
            UpdateTimer();
        }
    }

    public void StartNeedle()
    {
        if (!isStarted)
        {
            isStarted = true;
            isStopped = false;
            remainingTime = timeLimit;
            speedometerUI.SetActive(true);
        }
        else
        {
            StopNeedle();
        }
    }

    void UpdateTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(remainingTime).ToString();
        }
        else
        {
            StopNeedle();
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
