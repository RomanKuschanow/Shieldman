using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject dark, counter, arrow, PauseButton, PausePos, BackPos, PausePos2, BackToMenu;

    private Animation Animation;

    public bool buttonAnimationsLeftorRight = true;

    public counter scriptcon;
    public arrow scriptarr;

    private void Start()
    {
        BackToMenu.transform.position = new Vector3(BackToMenu.transform.position.x, PausePos.transform.position.y, -1);
        PauseButton.transform.position = new Vector3(PauseButton.transform.position.x, PausePos.transform.position.y, 0);
        PausePos2.transform.position = new Vector3(PausePos2.transform.position.x, PausePos.transform.position.y, 0);
        Animation = GetComponent<Animation>();
    }

    private void FixedUpdate()
    {
        if (scriptcon.i == 5 && PauseButton.transform.position.x > PausePos.transform.position.x)
            PauseButton.transform.Translate(new Vector3(-0.6f, 0, 0));

        if (PauseButton.transform.position.x < PausePos.transform.position.x && scriptcon.i == 5)
            scriptcon.i = 6;

        if (scriptcon.i == 7 && PauseButton.transform.position.x < PausePos2.transform.position.x)
            PauseButton.transform.Translate(new Vector3(0.6f, 0, 0));

        if (scriptcon.i == 7 && BackToMenu.transform.position.x < BackPos.transform.position.x)
            BackToMenu.transform.Translate(new Vector3(0.8f, 0, 0));

        if (scriptarr.gameover == true)
            scriptcon.i = 7;
    }

    //Возобновление игры
    private void OnMouseDown()
    {
        if(buttonAnimationsLeftorRight)
        {
            PlayAnimation("PauseEndLeft");
        }
        else
        {
            PlayAnimation("PauseEndRigth");
        }
    }

    //запуск начальной анимации
    public void StartPauseAnimation()
    {
        scriptcon.i = 7;

        if (buttonAnimationsLeftorRight)
        {
            PlayAnimation("PauseStartLeft");
        }
        else
        {
            PlayAnimation("PauseStartRigth");
        }
    }

    private void PlayAnimation(string AnimationName)
    {
        Vector3 DarkPosition = Vector3.zero;
        Vector3 ArrowPosition = Vector3.zero;
        Vector3 CounterPosition = Vector3.zero;

        switch (AnimationName)
        {
            case "PauseStartLeft":
                DarkPosition = new Vector3(0, 0, -3.45f);
                ArrowPosition = new Vector3(-20, 19, -1);
                break;

            case "PauseEndLeft":
                DarkPosition = new Vector3(-25, 0, -3.45f);
                CounterPosition = new Vector3(0, 12, -3);
                buttonAnimationsLeftorRight = false;
                break;
                
            case "PauseStartRigth":
                DarkPosition = new Vector3(0, 0, -3.45f);
                ArrowPosition = new Vector3(-20, 19, -1);
                break;

            case "PauseEndRigth":
                DarkPosition = new Vector3(-25, 0, -3.45f);
                CounterPosition = new Vector3(0, 12, -3);
                buttonAnimationsLeftorRight = true;
                break;

            default:
                throw new System.ArgumentException(string.Concat("Не найдена анимация с названием: ", AnimationName));
        }

        dark.transform.position = DarkPosition;

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
    
