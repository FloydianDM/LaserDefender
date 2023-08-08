using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "WaveConfig", fileName = "New Wave Config")]
public class WaveConfigSo : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeBetweenEnemySpawns;
    [SerializeField] private float spawnTimeVariance;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private int waypointCount = 4;

    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    public Vector3 GetStartingWaypoint()
    {
        Transform startingPoint =  pathPrefab.GetChild(0);
        return startingPoint.position;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in GetRandomWayPoints())
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    private List<Transform> GetRandomWayPoints()
    {
        List<Transform> randomWaypoints = new List<Transform>(waypointCount);

        Transform firstWaypoint = pathPrefab.GetChild(0);
        randomWaypoints.Add(firstWaypoint);
        
        for (int i = 1; i < waypointCount; i++)
        {
            Camera mainCamera = Camera.main;
            _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
            
            Transform nextWaypoint = pathPrefab.GetChild(i);
            Vector2 delta = new Vector3(Random.Range(-10f, 10f), Random.Range(-2f, 0));
            
            Vector2 newEnemyPos = new Vector2();
            newEnemyPos.x = Mathf.Clamp((randomWaypoints[i - 1].position.x + delta.x), _minBounds.x, _maxBounds.x);
            newEnemyPos.y = Mathf.Clamp((randomWaypoints[i - 1].position.y + delta.y), _minBounds.y, _maxBounds.y);

            nextWaypoint.position = newEnemyPos;
            
            randomWaypoints.Add(nextWaypoint);
        }

        Transform lastWaypoint = pathPrefab.GetChild(4);
        randomWaypoints.Add(lastWaypoint);

        return randomWaypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
            timeBetweenEnemySpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
