using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{
    public GameObject player, Spawner1, Spawner2;
    public Sprite one, two, three;
    public float i = 1;

    void Update()
    {
        if (player.transform.position.y < 0 && i < 4)
        {
            GetComponent<Animation>().Play("1");
        }

        if (i == 4)
        {
            gameObject.transform.position = new Vector2(-20, 12);
            i++;
        }
        //повторный запуск отсчета
        if (i == 7 && gameObject.transform.position.x == 0)
        {
            i = 1;
        }
    }

    void Animations()
    {
        i++;
        if(i == 2)
            GetComponent<SpriteRenderer>().sprite = two;
        else
            GetComponent<SpriteRenderer>().sprite = one;

    }
}
