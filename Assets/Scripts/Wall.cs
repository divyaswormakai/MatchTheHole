using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    float speed = 5f;
    bool moveStatus = false;
    PlayerSelector plselector;
    WallSpawner wallSpawner;
    bool checkStatus = true;

    void Start()
    {
        wallSpawner = FindObjectOfType<WallSpawner>();
        plselector = FindObjectOfType<PlayerSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;

        if (moveStatus)
        {
            pos.x -= speed * Time.deltaTime;
            GetComponent<Transform>().position = pos;
            if (checkStatus && pos.x < 0.2f)
            {
                CheckPassage();
                checkStatus = false;
            }
            if (pos.x <= -10f)
            {
                moveStatus = false;
                checkStatus = true;
                FindObjectOfType<WallSpawner>().RemoveWall();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            print("WOOHOO");
        }
    }

    public void ActivateWall()
    {
        moveStatus = true;
        Vector3 pos = GetComponent<Transform>().position;
        pos.y = 2f;
        pos.x = 24f;
        GetComponent<Transform>().position = pos;
    }

    void CheckPassage()
    {
        if (wallSpawner.activeWallType != "any" && wallSpawner.activeWallType != plselector.active)
        {
            print("Game Over");
        }
    }
}
