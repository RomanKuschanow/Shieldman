using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
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
    }

    private void OnMouseDown()
    {
        mode = -mode;

        PlayerPrefs.SetInt("mode", mode);
    }
}
