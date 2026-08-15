using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawns the obstacle.

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float delayStart = 1.5f;
    private PlayerController playerControllerScript;
    private float delaySpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnObstacle", delayStart);
}

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        // With this the obstacles won't spawn after the collision of player with the obstacle.
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            delaySpawn = Random.Range(1.5f, 2);
            Invoke("SpawnObstacle", delaySpawn);
        }
    }
}
