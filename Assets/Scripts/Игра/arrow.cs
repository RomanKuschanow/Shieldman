using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow : MonoBehaviour
{
    public Transform SpawnPos1, SpawnPos2;
    public GameObject Arrow, SpawnedArrow, triger, TryAgain, Stats, left, reight, dark, Button, ButtonPos, ButtonStartPos;
    public int rand = 0;
    int fly, Score;
    float speed;
    public Sprite GameOver;
    float height;
    public Text scoreText, ScoreTextEnd, HighScoreText;
    bool pause;
    bool pausePos = true;

    void FixedUpdate()
    {
        if (dark.transform.position.x == -25 && triger.transform.position.x == -20)
        {
            pause = false;
        }

        if (triger.transform.position.x == -20 && pausePos == true)
        {
            Button.transform.position = ButtonPos.transform.position;
            pausePos = false;
        }

        if (Arrow.transform.position.y == height && TryAgain.transform.position.x < 0)
            TryAgain.transform.Translate(new Vector2((0 - TryAgain.transform.position.x) / 4, 0));
        if (Arrow.transform.position.y == height && Stats.transform.position.y > 12)
        {
            ScoreTextEnd.text = System.Convert.ToString(Score);
            HighScoreText.text = System.Convert.ToString(PlayerPrefs.GetInt("Score"));

            Stats.transform.Translate(new Vector2(0, -(0 + Stats.transform.position.y) / 16.9f));
        }
            

        if (rand == 0 && triger.transform.position.x == -20)
        {
            rand = Random.Range(1, 3);
            if(rand == 1)
            {
                Arrow.transform.localScale = new Vector2(0.2f, 0.2f);
                fly = 1;
                height = Random.Range(-1, -1.5f);
                SpawnPos1.transform.position = new Vector3(-20, height, -1);
                SpawnedArrow = Instantiate(Arrow, SpawnPos1.position, Quaternion.identity) as GameObject;
            }
            else if (rand == 2)
            {
                Arrow.transform.localScale = new Vector2(-0.2f, 0.2f);
                fly = 2;
                height = Random.Range(-1, -1.5f);
                SpawnPos2.transform.position = new Vector3(20, height, -1);
                SpawnedArrow = Instantiate(Arrow, SpawnPos2.position, Quaternion.identity) as GameObject;
            }
        }

        if (fly == 1 && pause != true)
        {
            SpawnedArrow.transform.Translate(new Vector2(speed, 0));
        }
        else if (fly == 2 && pause != true)
        {
            SpawnedArrow.transform.Translate(new Vector2(-speed, 0));
        }

        if (SpawnedArrow.transform.position.x > -3.6 && fly == 1)
        {
            if (gameObject.transform.localScale.x == 0.6f)
            {
                Destroy(SpawnedArrow);
                rand = 0;
                Score++;
            }
            else if(gameObject.transform.localScale.x == -0.6f && SpawnedArrow.transform.position.x > -2)
            {
                GameEnd1();
            }
        }
        else if(SpawnedArrow.transform.position.x < 3.6 && fly == 2)
        {
            if (gameObject.transform.localScale.x == -0.6f)
            {
                Destroy(SpawnedArrow);
                rand = 0;
                Score++;
            }
            else if (gameObject.transform.localScale.x == 0.6f && SpawnedArrow.transform.position.x < 2.5)
            {
                GameEnd2();
            }
        }

        scoreText.text = System.Convert.ToString(Score);

        if (System.Convert.ToInt32(scoreText.text) < 10)
        {
            speed = 0.2f;
        }
        else if (System.Convert.ToInt32(scoreText.text) == 10)
        {
            speed = 0.3f;
        }
        else if (System.Convert.ToInt32(scoreText.text) == 20)
        {
            speed = 0.35f;
        }
        else if (System.Convert.ToInt32(scoreText.text) == 30)
        {
            speed = 0.45f;
        }
        else if (System.Convert.ToInt32(scoreText.text) == 40)
        {
            speed = 0.5f;
        }
        else if (System.Convert.ToInt32(scoreText.text) == 50)
        {
            speed = 0.6f;
        }
    }

    void GameEnd2()
    {
        Button.transform.position = ButtonStartPos.transform.position;
        GetComponent<SpriteRenderer>().sprite = GameOver;
        fly = 0;
        Destroy(SpawnedArrow);
        Arrow.transform.position = new Vector3(2, height, -0.5f);

        if (System.Convert.ToInt32(scoreText.text) > PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("Score", System.Convert.ToInt32(scoreText.text));
    }

    void GameEnd1()
    {
        Button.transform.position = ButtonStartPos.transform.position;
        GetComponent<SpriteRenderer>().sprite = GameOver;
        fly = 0;
        Destroy(SpawnedArrow);
        Arrow.transform.position = new Vector3(-2, height, -0.5f);

        if (System.Convert.ToInt32(scoreText.text) > PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("Score", System.Convert.ToInt32(scoreText.text));
    }

    public void Pause()
    {
        pause = true;
        dark.transform.position = new Vector3(0, 0, -4.4f);
        left.transform.position = new Vector3(-25, 0, 0);
        reight.transform.position = new Vector3(25, 0, 0);
    }
}
