using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Transform Ball;
    public int player1_score;
    public int player2_score;
    public Text Player1_display;
    public Text Player2_display;
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(50, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-50, -15));
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
        Player1_display.text = "0";
        Player2_display.text = "0";
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Goal1"))
        {
            player2_score += 1;
            Player2_display.text = player2_score.ToString();
        }
        if (coll.collider.CompareTag("Goal2"))
        {
            player1_score += 1;
            Player1_display.text = player1_score.ToString();
        }
    }

}