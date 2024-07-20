using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "ScriptableObjects/DifficultyData", order = 1)]
public class DifficultyData : ScriptableObject
{
    public float needleSpeed;
    public float timeLimit;
    public float redZoneSize;
    public float yellowZoneSizeOne;
    public float greenZoneSize;
    public float yellowZoneSizeTwo;
}
