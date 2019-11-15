using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] walls;
    List<int> activeWalls;
    public string activeWallType;

    private float spawnTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        activeWalls = new List<int>();

        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            spawnTime = 5f;
            SpawnWall();
        }
    }

    public void SpawnWall()
    {
        int rand = 10;
        while (true)
        {
            rand = Random.Range(0, walls.Length);
            if (!activeWalls.Contains(rand))
            {
                break;
            }
        }
        walls[rand].GetComponent<Wall>().ActivateWall();
        activeWalls.Add(rand);

        if (rand < 3)
        {
            activeWallType = "box";
        }
        else if (rand < 6)
        {
            activeWallType = "ball";
        }
        else
        {
            activeWallType = "any";
        }
    }

    public void RemoveWall()
    {
        activeWalls.RemoveAt(0);
    }
}
