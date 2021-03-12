using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2_0 : MonoBehaviour
{
    public bool arrow_start;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            arrow_start = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            arrow_start = true;
    }
}
