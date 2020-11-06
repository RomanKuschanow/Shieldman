using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public Sprite sprite1, sprite2;

    public int mode;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Score") == 0)
        {
            mode = 1;
            PlayerPrefs.SetInt("mode", mode);
        }
        else if(PlayerPrefs.GetInt("Score") > 0)
            mode = PlayerPrefs.GetInt("mode");

        if (mode == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (mode == -1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
    }

    private void OnMouseDown()
    {
        mode = -mode;

        PlayerPrefs.SetInt("mode", mode);
    }
}
