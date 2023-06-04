using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject sprite;

    Timer spawnTimer;

    public ObjectPool pool;

    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;
    // Start is called before the first frame update
    void Start()
    {
        
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        //create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 2;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnSprite();

            //change spawn timer duration and start
            spawnTimer.Duration = 3;
            spawnTimer.Run();
        }
    }

    private void SpawnSprite()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);


        GameObject ball;

        //ball = Instantiate<GameObject>(sprite, worldLocation, Quaternion.identity);
        //ball = ObjectPool.instance.GetObjectFromPool();
        ball = pool.GetObjectFromPool();

        if (ball != null)
        {
            ball.transform.position = worldLocation;
        }

    }
}
