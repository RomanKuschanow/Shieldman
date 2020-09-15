using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header("Объекты")]
    public GameObject dark;
    public GameObject counter;
    public GameObject arrow;

    private Animation Animation;

    private void Start()
    {
        Animation = GetComponent<Animation>();
    }

    //Возобновление игры
    private void OnMouseDown()
    {
        PlayAnimation("PauseEndLeft");
    }

    //Условия запуска начальной анимации
    private void StartPauseAnimation()
    {
        PlayAnimation("PauseStartLeft");
    }

    private void PlayAnimation(string AnimationName)
    {
        Vector3 DartPosition = Vector3.zero;
        Vector3 ArrowPosition = Vector3.zero;
        Vector3 CounterPosition = Vector3.zero;

        switch (AnimationName)
        {
            case "PauseStartLeft":
                DartPosition = new Vector3(0, 0, -4.4f);
                ArrowPosition = new Vector3(-20, 19, -1);
                break;

            case "PauseEndLeft":
                DartPosition = new Vector3(-25, 0, -4.4f);
                CounterPosition = new Vector3(0, 12, -3);
                break;

            default:
                throw new System.ArgumentException(string.Concat("Не найдена анимация с названием: ", AnimationName));
        }

        dark.transform.position = DartPosition;

        if (ArrowPosition != Vector3.zero)
        {
            arrow.transform.position = ArrowPosition;
        }
        else if (CounterPosition != Vector3.zero)
        {
            counter.transform.position = CounterPosition;
        }

        Animation.Play(AnimationName);
    }
}
