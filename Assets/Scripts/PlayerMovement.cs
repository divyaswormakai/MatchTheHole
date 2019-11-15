using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerSelector plselector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        plselector = FindObjectOfType<PlayerSelector>();
        plselector.UpdatePosition(rb.transform.position);
    }


    public void MoveLeft()
    {
        Vector3 pos = rb.transform.position;
        pos.z += 1.4f;
        pos.z = Mathf.Clamp(pos.z, -1.4f, 1.4f);
        plselector.UpdatePosition(pos);

        rb.transform.position = pos;
    }

    public void MoveRight()
    {
        Vector3 pos = rb.transform.position;
        pos.z -= 1.4f;
        pos.z = Mathf.Clamp(pos.z, -1.4f, 1.4f);
        plselector.UpdatePosition(pos);

        rb.transform.position = pos;
    }
}
