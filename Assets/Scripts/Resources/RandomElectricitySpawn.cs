using UnityEngine;

public class RandomElectricitySpawn : MonoBehaviour
{
    [SerializeField] private float NaturalSpawnHorizontalRange = 0;
    [SerializeField] private float NaturalSpawnVerticalRange = 0;

    [SerializeField] private float RobotSpawnHorizontalRange = 0;
    [SerializeField] private float RobotSpawnVerticalRange = 0;

    [SerializeField] private float ScreenOffsetY = 0;
    [SerializeField] private float ScreenOffsetX = 0;

    private void Awake()
    {
        ScreenOffsetY += (float)Screen.height;
        ScreenOffsetX += (float)Screen.width / 2f;
    }

    public Vector2 RandomSpawnPosition(bool IsRobot)
    {
        Vector3 position = new Vector3(0, 0, 0);
        if (IsRobot)
        {
            position = GetRandomSpawnPosition(RobotSpawnHorizontalRange, RobotSpawnVerticalRange);
        }
        else
        {
            position = GetRandomSpawnPosition(NaturalSpawnHorizontalRange, NaturalSpawnVerticalRange);
            position += Camera.main.ScreenToWorldPoint(new Vector3(ScreenOffsetX, ScreenOffsetY, 0));
        }

        return position;
    }

    private Vector2 GetRandomSpawnPosition(float xRange, float yRange)
    {
        return new Vector2(Random.Range(xRange, -xRange), Random.Range(yRange, 0));
    }
}
