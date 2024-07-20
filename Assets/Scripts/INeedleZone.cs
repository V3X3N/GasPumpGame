public interface INeedleZone
{
    void UpdateZones(float redZoneSize, float yellowZoneSizeOne, float greenZoneSize, float yellowZoneSizeTwo);
    float CheckZone(float angle);
}
