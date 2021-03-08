using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo2_0 : MonoBehaviour
{
    public int scene;

    private void Start()
    {
        scene = 1;
        GetComponent<Animation>().Play("Fade");
    }

    public void OnTrigered()
    {
        SceneManager.LoadScene(scene);
    }
}
