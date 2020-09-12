using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public string scene;

    private void Start()
    {
        Animation Anim = GetComponent<Animation>();
        Anim.Play("Fade");
    }
    public void OnTrigered()
    {
        SceneManager.LoadScene(scene);
    }
}
