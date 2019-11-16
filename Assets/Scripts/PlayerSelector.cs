using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public GameObject ball;
    public GameObject box;

    GameObject currShape;

    public Button ballBtn, boxBtn;

    bool change = false;
    bool goUp = false;

    public string active = "box";
    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
        currShape = box.gameObject;
    }

    private void Update()
    {
        if (change)
        {
            Vector3 pos = currShape.GetComponentInChildren<Rigidbody>().gameObject.transform.position;

            ballBtn.interactable = false;
            boxBtn.interactable = false;
            if (goUp)
            {
                pos.y += Time.deltaTime * 5f;
                if(pos.y >= 1.6f)
                {
                    goUp = false;
                    if(active == "ball")
                    {
                        box.SetActive(true);
                        ball.SetActive(false);
                        active = "box";
                        currShape = box.gameObject;
                    }
                    else
                    {
                        ball.SetActive(true);
                        box.SetActive(false);
                        active = "ball";
                        currShape = ball.gameObject;
                    }
                }
            }
            else
            {
                pos.y -= Time.deltaTime * 5f;
                if (pos.y <= 0.59f)
                {
                    change = false;
                    ballBtn.interactable = true;
                    boxBtn.interactable = true;
                }
            }
            currShape.GetComponentInChildren<Rigidbody>().gameObject.transform.position = pos;
        }
    }

    public void SetBallActive()
    {
        change = true;
        goUp = true;
        active = "ball";
    }

    public void SetBoxActive()
    {
        change = true;
        goUp = true;
        active = "box";
    }

    public void UpdatePosition(Vector3 position)
    {
        box.transform.position = position;
        ball.transform.position = position;
    }
}
