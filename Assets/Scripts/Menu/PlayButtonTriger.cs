using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonTriger : MonoBehaviour
{
    public GameObject playButton;

    private void FixedUpdate()
    {
        if (playButton.transform.position.x < 0.05f)
        {
            transform.position = new Vector2(0, -3.8f);
        }
    }
}
