using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    private int dimensions;

    public string button;

    private float screen_width = (Screen.width / (Screen.height / 40f)) / 2f;
    private float screen_height = Screen.height / (Screen.height / 20f);

    public int indent, count, pos;

    private void Start()
    {
        if (PlayerPrefs.GetInt("mode") == 0)
        {
            PlayerPrefs.SetInt("mode", 1);
            dimensions = 1;
        }
        else
            dimensions = PlayerPrefs.GetInt("mode");

        gameObject.transform.position = new Vector3(pos * screen_width + indent, (0 - (screen_height / 4)) + (count * screen_height / 2), -5);
    }

    void Update()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0, (0 - (screen_height / 4)) + (count * screen_height / 2), -5), 1);
    }

    private void OnMouseDown()
    {
        switch (button)
        {
            case "dimensions":
                if(dimensions == 1)
                {
                    dimensions = 3;
                    PlayerPrefs.SetInt("mode", dimensions);
                }
                else
                {
                    dimensions = 1;
                    PlayerPrefs.SetInt("mode", dimensions);
                }
                SceneManager.LoadScene(dimensions);
                break;
        }
    }
}
