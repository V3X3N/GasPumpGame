using UnityEngine;

public class NeedleController : MonoBehaviour
{
    public GameObject needle;
    public GameObject Gauge;
    private float speed;
    public DifficultyData difficultyData;
    private INeedleMovement needleMovement;
    private INeedleZone needleZone;
    private INeedleUI needleUI;
    private bool isStarted = false;
    private bool isStopped = false;
    private float remainingTime;
    private float currentMultiplier;

    private void Start()
    {
        needleMovement = needle.GetComponent<INeedleMovement>();
        needleZone = GetComponent<INeedleZone>();
        needleUI = GetComponent<INeedleUI>();

        ApplyDifficultySettings();
        Gauge.SetActive(false);
        needle.SetActive(false);
    }

    private void Update()
    {
        if (isStarted && !isStopped)
        {
            needleMovement.MoveNeedle(speed);
            UpdateTimer();
        }
    }

    private void ApplyDifficultySettings()
    {
        speed = difficultyData.needleSpeed;
        remainingTime = difficultyData.timeLimit;
        needleZone.UpdateZones(
            difficultyData.redZoneSize,
            difficultyData.yellowZoneSizeOne,
            difficultyData.greenZoneSize,
            difficultyData.yellowZoneSizeTwo);
    }

    public void StartNeedle()
    {
        if (!isStarted)
        {
            isStarted = true;
            isStopped = false;
            remainingTime = difficultyData.timeLimit;
            Gauge.SetActive(true);
            needle.SetActive(true);
        }
        else
        {
            StopNeedle();
        }
    }

    private void UpdateTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            needleUI.UpdateTimer(remainingTime);
        }
        else
        {
            StopNeedle();
        }
    }

    public void StopNeedle()
    {
        isStopped = true;
        Debug.Log("Needle stopped at angle: " + needleMovement.GetAngle());
        CheckZone();
    }

    private void CheckZone()
    {
        float angle = needleMovement.GetAngle();
        float zone = needleZone.CheckZone(angle);

        switch (zone)
        {
            case 1f:
                Debug.Log("Needle stopped in Red Zone");
                currentMultiplier = difficultyData.multiplierRedZone;
                break;
            case 2f:
                Debug.Log("Needle stopped in Yellow Zone Two");
                currentMultiplier = difficultyData.multiplierYellowZoneTwo;
                break;
            case 3f:
                Debug.Log("Needle stopped in Green Zone");
                currentMultiplier = difficultyData.multiplierGreenZone;
                break;
            case 4f:
                Debug.Log("Needle stopped in Yellow Zone One");
                currentMultiplier = difficultyData.multiplierYellowZoneOne;
                break;
            default:
                Debug.Log("Needle stopped in Empty Zone");
                currentMultiplier = 0;
                break;
        }

        PlayerPrefs.SetFloat("CurrentMultiplier", currentMultiplier);
        PlayerPrefs.Save();

        needleUI.UpdateMultiplier(currentMultiplier);
    }
}
