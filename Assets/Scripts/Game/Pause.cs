using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Pause : MonoBehaviour
{
    int pauseCounter;
    int EndPause;
    public int PauseStart = 0;
    public GameObject Button, ButtonStartPos, ButtonPos, dark, left, reight, counter, gameover;

    void FixedUpdate()
    {
        //перемещение большой кнопки на экран
        if (PauseStart > 0 && PauseStart < 11 && gameObject.transform.position.x < 0)
        {
            transform.Translate(new Vector3(2, 0, 0));
            pauseCounter = 1;
            PauseStart ++;
            Button.transform.position = ButtonStartPos.transform.position;
        }
        else if (PauseStart > 11 && PauseStart < 23 && gameObject.transform.position.x > 0)
        {
            transform.Translate(new Vector3(-2, 0, 0));
            pauseCounter = 2;
            PauseStart ++;
            Button.transform.position = ButtonStartPos.transform.position;
        }
        //перемещение большой кнопки за экран
        if (pauseCounter == 1 && EndPause == 1)
        {
            transform.Translate(new Vector3(2, 0, 0));
        }
        else if (pauseCounter == 2 && EndPause == 1)
        {
            transform.Translate(new Vector3(-2, 0, 0));
        }
        //окончание перемещения
        if (gameObject.transform.position.x == 20 || gameObject.transform.position.x == -20)
        {
            EndPause = 0;
        }
        //возврат управления
        if (counter.transform.position.x == -20 && dark.transform.position.x != 0)
        {
            left.transform.position = new Vector3(-5.8f, 0, 0);
            reight.transform.position = new Vector3(5.8f, 0, 0);
            Button.transform.position = ButtonPos.transform.position;
        }
    }

    private void OnMouseDown()
    {
        EndPause = 1;

        dark.transform.position = new Vector3(-25, 0, -4.4f);

        counter.transform.position = new Vector3(0, 12, -3);
    }

    public void PauseStartVoid()
    {
        if (PauseStart == 0)
        {
            PauseStart = 1;
        }

        if(PauseStart == 11)
        {
            PauseStart = 12;
        }

        if(PauseStart == 22)
        {
            PauseStart = 1;
        }
    }
}
