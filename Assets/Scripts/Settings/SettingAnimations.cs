using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class SettingAnimations : MonoBehaviour
{
    public Sprite sprite1, sprite2;

    private void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().sprite == sprite1)
        {
            GetComponent<Animation>().Play("RotateButton1");
        }
        else if (GetComponent<SpriteRenderer>().sprite == sprite2)
        {
            GetComponent<Animation>().Play("RotateButton2");
        }
    }

    public void OnTriggeted()
    {
        if (GetComponent<SpriteRenderer>().sprite == sprite1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (GetComponent<SpriteRenderer>().sprite == sprite2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
    }
}
