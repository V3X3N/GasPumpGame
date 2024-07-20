using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "ScriptableObjects/DifficultyData", order = 1)]
public class DifficultyData : ScriptableObject
{
    public float needleSpeed;
    public float timeLimit;
    public float yellowZoneSizeOne;
    public float greenZoneSize;
    public float yellowZoneSizeTwo;
    public float redZoneSize;
}
