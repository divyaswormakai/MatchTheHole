using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    float speed = 5f;
    bool moveStatus = false;
    PlayerSelector plselector;
    WallSpawner wallSpawner;
    GameController gameController;
    bool checkStatus = true;

    void Start()
    {
        wallSpawner = FindObjectOfType<WallSpawner>();
        plselector = FindObjectOfType<PlayerSelector>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;

        if (moveStatus)
        {
            pos.x -= speed * Time.deltaTime;
            GetComponent<Transform>().position = pos;
            if(!gameController.scoreIncreased && pos.x < 1f)
            {
                print("No score increaseddd");
                FindObjectOfType<CameraShake>().GameOverShake();
                FindObjectOfType<GameController>().DecreaseHealth();
            }
            if (checkStatus && pos.x < 0.2f)
            {
                CheckPassage();
                checkStatus = false;
                GetComponent<BoxCollider>().enabled = false;
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
        GetComponent<BoxCollider>().enabled = false;
        gameController.IncreaseScore();
        gameController.scoreIncreased = true;
        print(gameController.GetScore());
    }

    public void ActivateWall()
    {
        moveStatus = true;
        Vector3 pos = GetComponent<Transform>().position;
        pos.y = 2f;
        pos.x = 24f;
        GetComponent<Transform>().position = pos;
        GetComponent<BoxCollider>().enabled = true;
    }

    //see if the player matches the wall type
    void CheckPassage()
    {
        if (wallSpawner.activeWallType != "any" && wallSpawner.activeWallType != plselector.active)
        {
            print("WAll not matched");
            FindObjectOfType<CameraShake>().GameOverShake();
            FindObjectOfType<GameController>().DecreaseHealth();
        }
        else
        {
            if (!gameController.scoreIncreased)
            {
                print("Scored how do i nknow");
                gameController.IncreaseScore();
            }
        }
    }
}
