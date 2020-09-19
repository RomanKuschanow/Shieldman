using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow : MonoBehaviour
{
    public Transform SpawnPos1, SpawnPos2;
    public GameObject Arrow, SpawnedArrow, caunter, TryAgain, Stats;
    
    public int fly, Score;

    public float speed = 0.2f;
    public int arrowDirection;

    public Sprite GameOver;
    public float height;

    public Text scoreText, ScoreTextEnd, HighScoreText;

    public bool pause;
    public bool Gameover = false;

    void FixedUpdate()
    {
        //Условие снятия паузы
        if (caunter.transform.position.x == -20)
        {
            pause = false;
            Arrow.transform.position = new Vector3(-20, 20, -1);
        }

        //анимация окончания
        if (Arrow.transform.position.y == height && TryAgain.transform.position.x < 1.5f && Stats.transform.position.y > 12)
        {
            Gameover = true;
            ScoreTextEnd.text = System.Convert.ToString(Score);
            HighScoreText.text = System.Convert.ToString(PlayerPrefs.GetInt("Score"));

            TryAgain.transform.Translate(new Vector2((0 - TryAgain.transform.position.x) / 4, 0));
            Stats.transform.Translate(new Vector2(0, -(0 + Stats.transform.position.y) / 16.9f));
        }

        //спавн стрелы
        if (fly == 0 && caunter.transform.position.x == -20)
        {
            fly = Random.Range(1, 3);

            // указывает сторону с которой вылетит стрела
            arrowDirection = fly == 1 ? 1 : -1;

            Arrow.transform.localScale = new Vector2(0.2f * arrowDirection, 0.2f);
            height = Random.Range(-1, -1.5f);
            SpawnedArrow = Instantiate(Arrow, new Vector3(20 * -arrowDirection, height, -1), Quaternion.identity) as GameObject;

        }

        //полет стрелы
        if (!pause && fly > 0)
        {
            SpawnedArrow.transform.Translate(new Vector2(speed * arrowDirection, 0));
        }

        //столкновение стрелы с игроком
        if (SpawnedArrow.transform.position.x > -3.6 && fly == 1)
        {
            if (gameObject.transform.localScale.x == 0.6f)
            {
                Destroy(SpawnedArrow);
                fly = 0;
                Score++;
            }
            else if(gameObject.transform.localScale.x == -0.6f && SpawnedArrow.transform.position.x > -2)
            {
                GameEnd(true);
            }
        }
        else if(SpawnedArrow.transform.position.x < 3.6 && fly == 2)
        {
            if (gameObject.transform.localScale.x == -0.6f)
            {
                Destroy(SpawnedArrow);
                fly = 0;
                Score++;
            }
            else if (gameObject.transform.localScale.x == 0.6f && SpawnedArrow.transform.position.x < 2.5)
            {
                GameEnd(false);
            }
        }

        //счет
        scoreText.text = System.Convert.ToString(Score);

        //столкновение стрелы со считом
        if (System.Math.Abs(SpawnedArrow.transform.position.x) < 3.6)
        {
            //увеличивает скорость на 0.05f каждые 10 очков
            if (Score % 10 == 0)
            {
                speed += 0.05f;
            }
        }
    }

    //Окончание игры
    void GameEnd(bool GameEnd)
    {
        GetComponent<SpriteRenderer>().sprite = GameOver;
        fly = 0;
        Destroy(SpawnedArrow);
        caunter.transform.position = new Vector3(-19, 12, -3);

        if (GameEnd) Arrow.transform.position = new Vector3(-2, height, -0.5f);
        else Arrow.transform.position = new Vector3(2, height, -0.5f);


        if (System.Convert.ToInt32(scoreText.text) > PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("Score", System.Convert.ToInt32(scoreText.text));
    }

    //Запуск паузы
    public void Pause()
    {
        caunter.transform.position = new Vector3(-19, 12, -3);
        pause = true;
    }
}
