using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2_0 : MonoBehaviour
{
    private float screen_width = (Screen.width / (Screen.height / 40f)) / 2f;
    private float screen_heidht = Screen.height / (Screen.height / 20f);

    public Collider2_0 collider;

    public GameObject arrow, settings, play, name;

    public Sprite arr;

    public Vector3 Vector;

    public void Start()
    {
        arrow.transform.position = new Vector3(-screen_width - 5, 0, 0);
        settings.transform.position = new Vector3(-screen_width - 5, -screen_heidht + 3, 0);
        play.transform.position = new Vector3(screen_width + 10, -screen_heidht + 7, 0);
        name.transform.position = new Vector3(-screen_width - 20, screen_heidht - 7, 0);
    }

    private void FixedUpdate()
    {
        if (collider.arrow_start == true && arrow.transform.localPosition.x < -1.3f)
            arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x + 0.5f, -0.12f, -5);
        else if(collider.arrow_start == true && arrow.transform.localPosition.x >= -1.3f)
        {
            arrow.GetComponent<SpriteRenderer>().sprite = arr;

            name.transform.localPosition = Vector3.MoveTowards(name.transform.localPosition, new Vector3(0, name.transform.localPosition.y, -5), 1.5f);
            settings.transform.position = Vector3.MoveTowards(settings.transform.position, new Vector3(-screen_width + 3, -screen_heidht + 3, 0), 0.5f);
            play.transform.position = Vector3.MoveTowards(play.transform.position, new Vector3(0, -screen_heidht + 7, 0), 1.5f);
        }
    }
}
