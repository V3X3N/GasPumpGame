using UnityEngine;
using UnityEngine.UI;

public class NeedleZone : MonoBehaviour, INeedleZone
{
    public Image yellowZoneOne;
    public Image greenZone;
    public Image yellowZoneTwo;
    public Image redZone;

    public void UpdateZones(float redZoneSize, float yellowZoneSizeOne, float greenZoneSize, float yellowZoneSizeTwo)
    {
        redZone.fillAmount = redZoneSize;
        yellowZoneOne.fillAmount = yellowZoneSizeOne;
        greenZone.fillAmount = greenZoneSize;
        yellowZoneTwo.fillAmount = yellowZoneSizeTwo;

        yellowZoneOne.transform.localEulerAngles = Vector3.zero;
        greenZone.transform.localEulerAngles = Vector3.zero;
        yellowZoneTwo.transform.localEulerAngles = Vector3.zero;
    }

    public float CheckZone(float angle)
    {
        float fillAmount = (angle + 90) / 180;

        if (fillAmount <= redZone.fillAmount)
        {
            return 1f;
        }
        else if (fillAmount <= yellowZoneTwo.fillAmount)
        {
            return 2f;
        }
        else if (fillAmount <= greenZone.fillAmount)
        {
            return 3f;
        }
        else if (fillAmount <= yellowZoneOne.fillAmount)
        {
            return 4f;
        }
        return 0f;
    }
}
