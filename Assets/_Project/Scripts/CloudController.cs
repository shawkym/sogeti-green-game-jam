using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudController : MonoBehaviour
{
    [SerializeField] private Cloud[] cloudPrefabs;
    [SerializeField] private List<Cloud> cloudsAlive;
    [SerializeField] private float MIN_CLOUD_SPEED = 5f;
    [SerializeField] private float MAX_CLOUD_SPEED = 25f;

    [SerializeField] private float timeBetweenClouds = 50f;
    [SerializeField] private float currentTimeBetweenClouds = 1f;

    private void OnEnable()
    {
        Cloud.cloudOutOfView += ClearMissingReferences;
    }

    private void OnDisable()
    {
        Cloud.cloudOutOfView -= ClearMissingReferences;
    }

    private void Update()
    {
        currentTimeBetweenClouds -= Time.deltaTime;
        if (currentTimeBetweenClouds <= 0)
        {
            SpawnCloud();
            timeBetweenClouds = Random.Range(10f, 20f);
            currentTimeBetweenClouds = timeBetweenClouds;
        }
    }

    private void ClearMissingReferences()
    {
        for (int i = 0; i < cloudsAlive.Count; i++)
        {
            if (cloudsAlive[i] == null)
            {
                cloudsAlive.RemoveAt(i);
            }
        }
    }

    private void SpawnCloud()
    {
        int randomCloudIndex = Random.Range(0, cloudPrefabs.Length);
        Cloud randomCloudPrefab = cloudPrefabs[randomCloudIndex];
        Vector2 cloudRandomSpawnPos = new Vector2(-14, Random.Range(2.8f, 4.5f));
        if (randomCloudPrefab){
        Cloud cloudInstance = Instantiate(randomCloudPrefab, cloudRandomSpawnPos, Quaternion.identity);
        float randomLocalScale = Random.Range(.3f, 1f);
        cloudInstance.transform.localScale = new Vector3(randomLocalScale, randomLocalScale, randomLocalScale);
        cloudInstance.cloudSpeed = Random.Range(MIN_CLOUD_SPEED, MAX_CLOUD_SPEED);
        cloudsAlive.Add(cloudInstance);
        }
    }
}
