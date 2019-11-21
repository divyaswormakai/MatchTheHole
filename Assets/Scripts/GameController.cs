using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Texture empty;
    public GameObject[] lives;

    private int playerhealth = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("ASDF");
            DecreaseHealth();
        } 
    }

    public void DecreaseHealth()
    {
        string healthString = "h" + playerhealth.ToString();
        print(healthString);
        playerhealth -= 1;
        lives[playerhealth].GetComponent<RawImage>().texture = empty;
        if (playerhealth <= 0)
        {
            print("GameOver");
        }
    }
}
