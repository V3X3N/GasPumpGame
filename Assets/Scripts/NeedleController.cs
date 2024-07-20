using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NeedleController : MonoBehaviour
{
    public GameObject needle;
    public GameObject speedometerUI;
    public float speed = 20.0f;
    public TextMeshProUGUI countdownText;
    public DifficultyData difficultyData;
    public Image yellowZoneOne;
    public Image greenZone;
    public Image yellowZoneTwo;
    public Image redZone;
    private bool movingRight = true;
    private bool isStopped = false;
    private bool isStarted = false;
    private float remainingTime;

    void Start()
    {
        ApplyDifficultySettings();
        speedometerUI.SetActive(false);
        needle.SetActive(false);
    }

    void Update()
    {
        if (isStarted && !isStopped)
        {
            MoveNeedle();
            UpdateTimer();
        }
    }

    void ApplyDifficultySettings()
    {
        speed = difficultyData.needleSpeed;
        remainingTime = difficultyData.timeLimit;
        UpdateZoneSizes();
    }

    void UpdateZoneSizes()
    {
        float totalSize = difficultyData.redZoneSize + difficultyData.yellowZoneSizeOne + difficultyData.greenZoneSize + difficultyData.yellowZoneSizeTwo;

        redZone.fillAmount = difficultyData.redZoneSize / totalSize;
        yellowZoneOne.fillAmount = difficultyData.yellowZoneSizeOne / totalSize;
        greenZone.fillAmount = difficultyData.greenZoneSize / totalSize;
        yellowZoneTwo.fillAmount = difficultyData.yellowZoneSizeTwo / totalSize;


        yellowZoneOne.transform.localEulerAngles = Vector3.zero;
        greenZone.transform.localEulerAngles = Vector3.zero;
        yellowZoneTwo.transform.localEulerAngles = Vector3.zero;

    }

    public void StartNeedle()
    {
        if (!isStarted)
        {
            isStarted = true;
            isStopped = false;
            remainingTime = difficultyData.timeLimit;
            speedometerUI.SetActive(true);
            needle.SetActive(true);
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
        float angle = needle.transform.localEulerAngles.z;
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
            needle.transform.Rotate(0, 0, -step);
            if (GetNeedleAngle() <= -90)
            {
                movingRight = false;
                needle.transform.localEulerAngles = new Vector3(0, 0, -90);
            }
        }
        else
        {
            needle.transform.Rotate(0, 0, step);
            if (GetNeedleAngle() >= 90)
            {
                movingRight = true;
                needle.transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
    }
}
