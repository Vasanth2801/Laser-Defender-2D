using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WavesConfigurationSO> wavesConfiguration;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
     WavesConfigurationSO currentWave;
    
    
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WavesConfigurationSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WavesConfigurationSO wave in wavesConfiguration)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {

                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(isLooping);
    }

}
