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
        redZone.fillAmount = difficultyData.redZoneSize;
        yellowZoneOne.fillAmount = difficultyData.yellowZoneSizeOne;
        greenZone.fillAmount = difficultyData.greenZoneSize;
        yellowZoneTwo.fillAmount = difficultyData.yellowZoneSizeTwo;

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
        float fillAmount = (angle + 90) / 180;

        if (fillAmount <= difficultyData.redZoneSize)
        {
            Debug.Log("Needle stopped in Red Zone");
        }
        else if (fillAmount <= difficultyData.yellowZoneSizeTwo)
        {
            Debug.Log("Needle stopped in Yellow Zone Two");
        }
        else if (fillAmount <= difficultyData.greenZoneSize)
        {
            Debug.Log("Needle stopped in Green Zone");
        }
        else if (fillAmount <= difficultyData.yellowZoneSizeOne)
        {
            Debug.Log("Needle stopped in Yellow Zone One");
        }
        else
        {
            Debug.Log("Needle stopped in Empty Zone");
        }
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