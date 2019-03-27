using UnityEngine;

public class RandomElectricitySpawn : MonoBehaviour
{
    [SerializeField] private float NaturalSpawnHorizontalRange;
    [SerializeField] private float NaturalSpawnVerticalRange;

    [SerializeField] private float RobotSpawnHorizontalRange;
    [SerializeField] private float RobotSpawnVerticalRange;

    [SerializeField] private float ScreenOffset = 0;

    private void Awake()
    {
        ScreenOffset += (float)Screen.height / 2f;
    }

    public Vector2 RandomSpawnPosition(bool IsRobot)
    {
        Vector2 position = new Vector2(0, 0);
        if (IsRobot)
        {
            position = GetRandomSpawnPosition(RobotSpawnHorizontalRange, RobotSpawnVerticalRange);
        }
        else
        {
            position = GetRandomSpawnPosition(NaturalSpawnHorizontalRange, NaturalSpawnVerticalRange);
            position += new Vector2(0, ScreenOffset);
        }

        return position;
    }

    private Vector2 GetRandomSpawnPosition(float xRange, float yRange)
    {
        return new Vector2(Random.Range(xRange, -xRange), Random.Range(yRange, 0));
    }
}
