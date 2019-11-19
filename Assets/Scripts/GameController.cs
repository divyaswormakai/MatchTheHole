using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Texture empty;

    private int playerhealth = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void DecreaseHealth()
    {
        string healthString = "h" + playerhealth.ToString();
        print(healthString);
        playerhealth -= 1;
        GameObject.FindObjectOfType<Renderer>().material.mainTexture = empty;
        if (playerhealth <= 0)
        {
            print("GameOver");
        }
    }
}
