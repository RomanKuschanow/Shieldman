using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial1, tutuorial2, tutorialText, tutorialBox;
    bool playTouch = false;

    void Start()
    {
        if (PlayerPrefs.GetInt("Score") != 0)
        {
            transform.position = new Vector3(0, -25, -1);
            tutorial1.transform.position = new Vector3(-20, -3, -1);
            tutuorial2.transform.position = new Vector3(20, -3, -1);
            tutorialText.transform.position = new Vector3(0, 25, -1);
            tutorialBox.transform.position = new Vector3(0, -4.8f, 0);
        }
    }

    void FixedUpdate()
    {
        if (playTouch == true && transform.position != new Vector3(0, -25, -1))
        {
            transform.Translate(new Vector3(0, -1, 0));
        }
        if (playTouch == true && tutorial1.transform.position != new Vector3(20, -3, -1))
        {
            tutorial1.transform.Translate(new Vector3(1, 0, 0));
        }
        if (playTouch == true && tutuorial2.transform.position != new Vector3(-20, -3, -1))
        {
            tutuorial2.transform.Translate(new Vector3(-1, 0, 0));
        }
        if (playTouch == true && tutorialText.transform.position != new Vector3(0, 25, -1))
        {
            tutorialText.transform.Translate(new Vector3(0, 1, 0));
        }
        if (playTouch == true && tutorialBox.transform.position != new Vector3(0, -4.8f, 0))
        {
            tutorialBox.transform.position = new Vector3(0, -4.8f, 0);
        }
    }

    private void OnMouseDown()
    {
        playTouch = true;
    }
}
