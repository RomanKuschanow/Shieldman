using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollider : MonoBehaviour
{
    public Transform button;

    void FixedUpdate()
    {
        transform.position = button.transform.position;
    }
}