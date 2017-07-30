using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject birdObstacle;

    [SerializeField]
    private Transform birdSpawnTransform;

    [SerializeField]
    private GameObject trafficConeObstacle;

    [SerializeField]
    private Transform trafficConeSpawnTransform;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(SpawnCoroutine());
	}

    private IEnumerator SpawnCoroutine()
    {
        float spawnTime;

        while (true)
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            if (Random.Range(0, 2) == 0)
            {
                //Spawn traffic cone
                Instantiate(trafficConeObstacle, trafficConeSpawnTransform.position,
                            trafficConeSpawnTransform.rotation);
            }
            else
            {
                //Spawn bird
                Instantiate(birdObstacle, birdSpawnTransform.position, birdSpawnTransform.rotation);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
	
}
