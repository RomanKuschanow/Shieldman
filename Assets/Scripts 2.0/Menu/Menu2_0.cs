using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu2_0 : MonoBehaviour
{
    private float screen_width = (Screen.width / (Screen.height / 40f)) / 2f;
    private float screen_height = Screen.height / (Screen.height / 20f);

    public Collider2_0 collider;

    public GameObject arrow, settings, play, name;

    public Sprite arr;

    public Vector3 Vector;

    public int z_pos;

    public float arr_pos, speed;

    public void Start()
    {
        arrow.transform.position = new Vector3(-screen_width - 10, 0, z_pos);
        settings.transform.position = new Vector3(-screen_width - 5, -screen_height + 3, 0);
        play.transform.position = new Vector3(screen_width + 10, -screen_height + 7, 0);
        name.transform.position = new Vector3(-screen_width - 20, screen_height - 7, -5);
    }

    private void FixedUpdate()
    {
        if (collider.arrow_start == true && arrow.transform.localPosition.x < arr_pos)
            arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x + speed, 0.1f, z_pos);
        else if(collider.arrow_start == true && arrow.transform.localPosition.x >= arr_pos)
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "main")
            {
                arrow.GetComponent<SpriteRenderer>().sprite = arr;

                name.transform.localPosition = Vector3.MoveTowards(name.transform.localPosition, new Vector3(0, name.transform.localPosition.y, -5), 1.5f);
                settings.transform.position = Vector3.MoveTowards(settings.transform.position, new Vector3(-screen_width + 3, -screen_height + 3, 0), 0.5f);
                play.transform.position = Vector3.MoveTowards(play.transform.position, new Vector3(0, -screen_height + 7, 0), 1.5f);
            }
            else if (scene.name == "main3D")
            {
                name.transform.localPosition = Vector3.MoveTowards(name.transform.localPosition, new Vector3(0, name.transform.localPosition.y, -5), 1.5f);
                settings.transform.position = Vector3.MoveTowards(settings.transform.position, new Vector3(-screen_width + 3, -screen_height + 3, 0), 0.5f);
                play.transform.position = Vector3.MoveTowards(play.transform.position, new Vector3(0, -screen_height + 7, 0), 1.5f);
            }
            
        }
    }
}
