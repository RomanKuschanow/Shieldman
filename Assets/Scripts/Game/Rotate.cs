using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Rotate : MonoBehaviour
{
    public GameObject Player, Arrow;
    public float  scl;
    private new PolygonCollider2D collider;

    private void FixedUpdate()
    {
        if (Player.transform.position.y < 0)
        {
            collider = GetComponent<PolygonCollider2D>();
            collider.enabled = true;
        }

        if (Arrow.transform.position.y < 20)
        {
            collider.enabled = false;
        }
    }
    void OnMouseDown()
    {
        if(PlayerPrefs.GetInt("mode") == 1)
            Player.transform.localScale = new Vector3(scl, 0.6f, 0.6f);

        if(PlayerPrefs.GetInt("mode") == -1)
        {
            Player.transform.localScale = new Vector3(-Player.transform.localScale.x, 0.6f, 0.6f);
        }
    }
}
