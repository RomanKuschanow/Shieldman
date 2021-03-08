using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2_0 : MonoBehaviour
{
    public Collider2_0 collider;

    public GameObject arrow, settings, play, name;

    public Sprite arr1, arr2;

    public void Start()
    {
        arrow.transform.position = new Vector3((-(Screen.width / (Screen.height / 40f)) / 2f) - 5, 0, 0);
        settings.transform.position = new Vector3((-(Screen.width / (Screen.height / 40f)) / 2f) - 5, 0 - (Screen.height / 30f), 0);
        play.transform.position = new Vector3(((Screen.width / (Screen.height / 40f)) / 2f) + 10, 0, 0);
        name.transform.position = new Vector3((-(Screen.width / (Screen.height / 40f)) / 2f) - 20, 0 + (Screen.height / 30f), 0);
        arrow.GetComponent<SpriteRenderer>().sprite = arr1;
    }

    private void FixedUpdate()
    {
        if (collider.arrow_start == true && arrow.transform.localPosition.x < -1.3f)
            arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x + 0.5f, -0.12f, -5);
        else
        {
            arrow.GetComponent<SpriteRenderer>().sprite = arr2;

            name.transform.localPosition = Vector3.MoveTowards(name.transform.localPosition, new Vector3(0, name.transform.localPosition.y, -5), 0.3f);
            settings.transform.position = Vector3.MoveTowards(settings.transform.position, new Vector3(Screen.width - (Screen.height / 30f) / 60f, settings.transform.position.y, -5), 0.3f);
        } 
    }
}
