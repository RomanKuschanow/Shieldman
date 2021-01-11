using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thirddimension : MonoBehaviour
{
    public Sprite sprite3d, sprite2d;

    public void Start()
    {
        if (PlayerPrefs.GetInt("thirddimension") == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2d;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprite3d;
        }
    }

    private void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().sprite == sprite3d)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2d;
            PlayerPrefs.SetInt("thirddimension", 2);
            SceneManager.LoadScene(3);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprite3d;
            PlayerPrefs.SetInt("thirddimension", 3);
            SceneManager.LoadScene(1);
        }
    }
}