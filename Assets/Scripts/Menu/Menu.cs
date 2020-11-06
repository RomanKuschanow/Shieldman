using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Transform Player, gameName, playButton, settingsButon, settingsPos;
    public Sprite arrow, arrowInShield;
    public bool moveStart;
    public Text Score;
    public int playerpos, gamenamepos;
    public float arrowpos, arrowspeed;

    private void Start()
    {
        settingsButon.transform.position = new Vector2(settingsButon.transform.position.x, settingsPos.transform.position.y);
    }

    void FixedUpdate()
    {
        if (Player.transform.position.y <= playerpos && transform.position.x < arrowpos)
            transform.Translate(new Vector2(arrowspeed, 0));

        if (transform.position.x < -5 && arrowpos == -5)
            GetComponent<SpriteRenderer>().sprite = arrow;
        else if (transform.position.x > -3 && arrowpos == -2.5)
        {
            moveStart = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = arrowInShield;
            moveStart = true;
        }

        if (gamenamepos == 0)
        {
            if (gameName.transform.position.x != gamenamepos || playButton.transform.position.x != 0)
            {
                if (moveStart == true && playButton.transform.position.x > 0.001)
                {
                    float gameNamePos = (0 - gameName.transform.position.x) / 5;
                    float playButtonPos = -(0 + playButton.transform.position.x) / 5;
                    gameName.Translate(new Vector2(gameNamePos, 0));
                    playButton.Translate(new Vector2(playButtonPos, 0));
                    if (settingsButon.transform.position.x < settingsPos.transform.position.x)
                    {
                        settingsButon.Translate(new Vector2((settingsPos.transform.position.x - settingsButon.transform.position.x) / 5, 0));
                    }

                    Score.text = System.Convert.ToString(PlayerPrefs.GetInt("Score"));
                }
            }
        } else if ( gamenamepos == 5)
        {
            if (gameName.transform.position.y != gamenamepos || playButton.transform.position.x != 0)
            {
                if (moveStart == true && playButton.transform.position.x > 0.001)
                {
                    float gameNamePos = -(-6 + gameName.transform.position.y) / 10;
                    float playButtonPos = (0 + playButton.transform.position.x) / 5;
                    gameName.Translate(new Vector3(0, gameNamePos, 0));
                    playButton.Translate(new Vector3(playButtonPos, 0, 0));
                    if (settingsButon.transform.position.x < settingsPos.transform.position.x)
                    {
                        settingsButon.Translate(new Vector2((settingsPos.transform.position.x - settingsButon.transform.position.x) / 5, 0));
                    }

                    Score.text = System.Convert.ToString(PlayerPrefs.GetInt("Score"));
                }
            }
        }
        
    }
}
