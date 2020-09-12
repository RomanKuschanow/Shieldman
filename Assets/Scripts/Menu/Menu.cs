using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Transform Player, gameName, playButton, buttonCollider;
    public Sprite arrow, arrowInShield;
    bool moveStart;
    public Text Score;

    void FixedUpdate()
    {
        if (Player.transform.position.y <= 3 && transform.position.x < -5)
            transform.Translate(new Vector2(1, 0));

        if (transform.position.x < -5)
            GetComponent<SpriteRenderer>().sprite = arrow;
        else
        {
            GetComponent<SpriteRenderer>().sprite = arrowInShield;
            moveStart = true;
        }

        if (gameName.transform.position.x != 0 || playButton.transform.position.x != 0)
        {
            if(moveStart == true && playButton.transform.position.x > 0.001)
            {
                float gameNamePos = (0 - gameName.transform.position.x) / 5;
                float playButtonPos = -(0 + playButton.transform.position.x) / 5;
                gameName.Translate(new Vector2(gameNamePos, 0));
                playButton.Translate(new Vector2(playButtonPos, 0));

                Score.text = System.Convert.ToString(PlayerPrefs.GetInt("Score"));
            }
        }
    }
}
