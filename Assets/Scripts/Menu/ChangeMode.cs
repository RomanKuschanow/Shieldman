using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public int mode = 1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Score") == 0)
            PlayerPrefs.SetInt("mode", mode);
    }

    private void OnMouseDown()
    {
        mode = -mode;

        PlayerPrefs.SetInt("mode", mode);
    }
}
