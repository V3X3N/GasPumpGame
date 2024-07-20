using TMPro;
using UnityEngine;

public class NeedleUI : MonoBehaviour, INeedleUI
{
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI multiplierText;

    public void UpdateTimer(float remainingTime)
    {
        countdownText.text = Mathf.Ceil(remainingTime).ToString();
    }

    public void UpdateMultiplier(float currentMultiplier)
    {
        multiplierText.text = currentMultiplier.ToString("F1");
    }
}
