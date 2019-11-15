using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject ball;
    public GameObject box;

    public string active = "box";
    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
    }

    public void SetBallActive()
    {
        ball.SetActive(true);
        box.SetActive(false);
        active = "ball";
    }

    public void SetBoxActive()
    {
        box.SetActive(true);
        ball.SetActive(false);
        active = "box";
    }

    public void UpdatePosition(Vector3 position)
    {
        box.transform.position = position;
        ball.transform.position = position;
    }
}
