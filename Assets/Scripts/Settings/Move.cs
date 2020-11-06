using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int moveSelector;

    private void FixedUpdate()
    {
        if(gameObject.transform.position.x != 0)
        {
            gameObject.transform.Translate(new Vector2(moveSelector, 0));
        }
    }
}
