using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSo> waveConfigs;
    private WaveConfigSo _currentWave;
    [SerializeField] private float timeBetweenWaves;
    private bool _isLooping = true;

    public WaveConfigSo GetCurrentWave()
    {
        return _currentWave;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSo wave in waveConfigs)
            {
                _currentWave = wave;

                for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(i), _currentWave.GetStartingWaypoint(),
                        Quaternion.Euler(0,0,180), transform);

                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (_isLooping);
    }
}
