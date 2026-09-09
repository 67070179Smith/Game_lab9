using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    public Transform car;
    public GameObject obstaclePrefab;
    [Header("Spawn Area")]
    public float spawnRadius = 8f;
    public float spawnHeight = 15f;
    [Header("Timing")]
    public float spawnInterval = 1.5f;
    private float timer;
    [Header("Difficulty Scaling")]
    public float minSpawnInterval = 0.4f;
    public float difficultyRampRate = 0.02f;
    void Update()
    {
        spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval -
        difficultyRampRate * Time.deltaTime);
        timer += Time.deltaTime; if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObstacle();
        }
    }
    void SpawnObstacle()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = car.position + new Vector3(randomCircle.x, spawnHeight,
        randomCircle.y);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}