using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public int scene;

    private void Start()
    {
        Animation Anim = GetComponent<Animation>();
        Anim.Play("Fade");
        if (PlayerPrefs.GetInt("thirddimension") == 3)
        {
            scene = 3;
        }
        else
        {
            scene = 1;
        }
    }
    public void OnTrigered()
    {
        SceneManager.LoadScene(scene);
    }
}
