using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause1 : MonoBehaviour
{
    public int Animations = 1;
    public bool AnimationStart;
    public string AniName;
    public GameObject dark;

    void Update()
    {
        if (AnimationStart == true)
            GetComponent<Animation>().Play(AniName);
    }

    void OnMouseDown()
    {
        if (Animations == 2)
        {
            AnimationStart = true;
            AniName = "Pause animation left 2";
            dark.transform.position = new Vector3(-25, 0, -4.4f);
        } else if (Animations == 4)
        {
            AnimationStart = true;
            AniName = "Pause animation rigth 2";
            dark.transform.position = new Vector3(-25, 0, -4.4f);
        }
    }

    public void StartPauseAnimation()
    {
        if (Animations == 1)
        {
            AnimationStart = true;
            AniName = "Pause animation left 1";
        } else if (Animations == 3)
        {
            AnimationStart = true;
            AniName = "Pause animation rigth 1";
        }
    }

    public void EndAnimations1_3()
    {
        Animations += 1;
        AnimationStart = false;
    }

    public void EndAnimations4()
    {
        Animations = 1;
        AnimationStart = false;
    }
}
