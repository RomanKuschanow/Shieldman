using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public int Animations = 1;
    public bool AnimationStart;
    public string AniName;
    public GameObject dark, counter, arrow;
    
    //запуск анимации
    void Update()
    {
        if (AnimationStart == true)
            GetComponent<Animation>().Play(AniName);
    }

    //Условия запуска завершающей анимации
    void OnMouseDown()
    {
        if (Animations == 2)
        {
            AnimationStart = true;
            AniName = "Pause animation left 2";
            dark.transform.position = new Vector3(-25, 0, -4.4f);
            counter.transform.position = new Vector3(0, 12, -3);
        } else if (Animations == 4)
        {
            AnimationStart = true;
            AniName = "Pause animation rigth 2";
            dark.transform.position = new Vector3(-25, 0, -4.4f);
            counter.transform.position = new Vector3(0, 12, -3);
        }
    }

    //Условия запуска начальной анимации
    public void StartPauseAnimation()
    {
        if (Animations == 1)
        {
            AnimationStart = true;
            AniName = "Pause animation left 1";
            dark.transform.position = new Vector3(0, 0, -4.4f);
            arrow.transform.position = new Vector3(-20, 19, -1);
        } else if (Animations == 3)
        {
            AnimationStart = true;
            AniName = "Pause animation rigth 1";
            dark.transform.position = new Vector3(0, 0, -4.4f);
            arrow.transform.position = new Vector3(-20, 19, -1);
        }
    }

    //Событие при завершении 1, 2 и 3 анимации
    public void EndAnimations1_3()
    {
        Animations += 1;
        AnimationStart = false;
    }

    //Событие при завершении 4 анимации
    public void EndAnimations4()
    {
        Animations = 1;
        AnimationStart = false;
    }
}
