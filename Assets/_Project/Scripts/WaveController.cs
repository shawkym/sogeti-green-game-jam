using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveController : MonoBehaviour
{
    [SerializeField] private Wave[] wavePrefabs;
    [SerializeField] private List<Wave> wavesAlive;
    [SerializeField] private float MIN_WAVE_SPEED = 5f;
    [SerializeField] private float MAX_WAVE_SPEED = 65f;

    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float currentTimeBetweenWaves = 1f;

    private void OnEnable()
    {
        Wave.waveOutOfView += ClearMissingReferences;
    }

    private void OnDisable()
    {
        Wave.waveOutOfView -= ClearMissingReferences;
    }

    private void Update()
    {
        currentTimeBetweenWaves -= Time.deltaTime;
        if (currentTimeBetweenWaves <= 0)
        {
            SpawnWave();
            timeBetweenWaves = Random.Range(10f, 20f);
            currentTimeBetweenWaves = timeBetweenWaves;
        }
    }

    private void ClearMissingReferences()
    {
        for (int i = 0; i < wavesAlive.Count; i++)
        {
            if (wavesAlive[i] == null)
            {
                wavesAlive.RemoveAt(i);
            }
        }
    }

    private void SpawnWave()
    {
        int randomWaveIndex = Random.Range(0, wavePrefabs.Length);
        Wave randomWavePrefab = wavePrefabs[randomWaveIndex];
        if (randomWavePrefab){
        Vector2 waveRandomSpawnPos = new Vector2(-10, Random.Range(0.1f, 0.5f));

        Wave waveInstance = Instantiate(randomWavePrefab, waveRandomSpawnPos, Quaternion.identity);
        float randomLocalScale = Random.Range(.3f, 1f);
        waveInstance.transform.localScale = new Vector3(randomLocalScale, randomLocalScale, randomLocalScale);
        waveInstance.waveSpeed = Random.Range(MIN_WAVE_SPEED, MAX_WAVE_SPEED);
        wavesAlive.Add(waveInstance);
        }
    }
}
