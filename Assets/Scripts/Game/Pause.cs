using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public int Animations = 1;
    public bool AnimationStart;
    public string AnimationName;
    public GameObject dark, counter, arrow;

    void Update()
    {
        if (AnimationStart == true)
            GetComponent<Animation>().Play(AnimationName);
    }

    //Возобновление игры
    void OnMouseDown()
    {
        if (Animations == 2)
        {
            PlayAnimation(2);
        }
        else if (Animations == 4)
        {
            PlayAnimation(4);
        }
    }

    //Условия запуска начальной анимации
    public void StartPauseAnimation()
    {
        if (Animations == 1)
        {
            PlayAnimation(1);
        }
        else if (Animations == 3)
        {
            PlayAnimation(3);
        }
    }

    public void PlayAnimation(int AnimationId)
    {
        Vector3 DartPosition = Vector3.zero;
        Vector3 ArrowPosition = Vector3.zero;
        Vector3 CounterPosition = Vector3.zero;

        switch (AnimationId)
        {
            case 1:
                AnimationName = "PauseStartLeft";
                DartPosition = new Vector3(0, 0, -4.4f);
                ArrowPosition = new Vector3(-20, 19, -1);
                break;

            case 2:
                AnimationName = "PauseEndLeft";
                DartPosition = new Vector3(-25, 0, -4.4f);
                CounterPosition = new Vector3(0, 12, -3);
                break;

            case 3:
                AnimationName = "PauseStartRigth";
                DartPosition = new Vector3(0, 0, -4.4f);
                ArrowPosition = new Vector3(-20, 19, -1);
                break;

            case 4:
                AnimationName = "PauseEndRigth";
                DartPosition = new Vector3(-25, 0, -4.4f);
                CounterPosition = new Vector3(0, 12, -3);
                break;

            default:
                throw new System.ArgumentException(string.Concat("Не найдена анимация с идентификатором", AnimationId));
        }

        AnimationStart = true;

        dark.transform.position = DartPosition;
        if (ArrowPosition != Vector3.zero)
        {
            arrow.transform.position = ArrowPosition;
        }
        else if (CounterPosition != Vector3.zero)
        {
            counter.transform.position = CounterPosition;
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
