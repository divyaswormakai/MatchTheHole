using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Texture empty;
    public GameObject[] lives;
    public TextMeshProUGUI scoreBoard;

    public bool scoreIncreased = true;

    private int score =0;

    private int playerhealth = 5;
    void Start()
    {
        scoreBoard.SetText("Score: " + score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DecreaseHealth()
    {
        string healthString = "h" + playerhealth.ToString();
        playerhealth -= 1;
        if (playerhealth <0) {
            //SceneManager.LoadScene("SampleScene");
            print("DAED");
        }
        lives[playerhealth].GetComponent<RawImage>().texture = empty;
        if (playerhealth <= 0)
        {
            print("GameOver");
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreBoard.SetText("Score: " + score.ToString());
    }

    public int GetScore()
    {
        return score;
    }
}
