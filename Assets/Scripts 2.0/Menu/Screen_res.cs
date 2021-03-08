using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_res : MonoBehaviour
{
    public Text res;

    void FixedUpdate()
    {
        res.text = System.Convert.ToString(Screen.width + "x" + Screen.height);

        res.transform.position = new Vector2(0, 0 + (Screen.height / 30));
    }
}
