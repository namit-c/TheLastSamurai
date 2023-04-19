using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs; // an array of prefabs to spawn
    public float spawnInterval = 20f; // how often to spawn a prefab
    private float timeUntilNextSpawn; // how much time until the next spawn

    void Start()
    {
        timeUntilNextSpawn = spawnInterval; // set the initial time until the next spawn
    }

    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime; // subtract the elapsed time since the last frame from the time until the next spawn

        if (timeUntilNextSpawn <= 0) // if it's time to spawn
        {
            timeUntilNextSpawn = spawnInterval; // reset the time until the next spawn

            // choose a random prefab to spawn from the array
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            // spawn the prefab at a random position within a specified area
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-2f, 3.5f), 0f);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
