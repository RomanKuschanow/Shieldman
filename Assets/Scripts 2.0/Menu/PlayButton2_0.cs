using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton2_0 : MonoBehaviour
{
    public int scene;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }
}
