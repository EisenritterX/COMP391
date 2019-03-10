using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    GameObject paddle;
    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindGameObjectWithTag("paddle");
        rb2d = GetComponent<Rigidbody2D>();
        //Wait 2 seconds before start
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBall()
    {
        rb2d.velocity = new Vector2(Random.Range(-10.0f, 10.0f), -2.5f);
    }

    void ResetBall()
    {
        Vector2 scale;
        scale.x = 0.25f;
        scale.y = 0.25f;
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        paddle.transform.localScale = scale;
    }

   void RestartBall(float waitTime)
    {
        ResetBall();
        Invoke("GoBall", waitTime);
    }

    //Adjust velocity after collision
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("paddle"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x + (coll.collider.attachedRigidbody.velocity.x/20); 
            vel.y = (rb2d.velocity.y);
            rb2d.velocity = vel;
        }
        //Destroy brick after collision
        if (coll.collider.CompareTag("brick"))
        {
            Destroy(coll.gameObject);
            GameManager.playerScore++;
            GameManager.brickCount--;
        }
        //Destroy brick after collision and 2x speed
        if (coll.collider.CompareTag("brickfast"))
        {
            rb2d.velocity = rb2d.velocity*2;
            Destroy(coll.gameObject);
            GameManager.playerScore++;
            GameManager.brickCount--;
        }
        //Destroy brick after collision and half speed
        if (coll.collider.CompareTag("brickslow"))
        {
            rb2d.velocity = rb2d.velocity/2;
            Destroy(coll.gameObject);
            GameManager.playerScore++;
            GameManager.brickCount--;
        }

        //Destroy brick after collision and expand paddle
        if (coll.collider.CompareTag("brickexpand"))
        {
            Vector2 scale;
            scale.x = paddle.transform.localScale.x * 2;
            scale.y = paddle.transform.localScale.y;
            paddle.transform.localScale = scale;
            Destroy(coll.gameObject);
            GameManager.playerScore++;
            GameManager.brickCount--;
        }

        //Destroy brick after collision and shrink paddle
        if (coll.collider.CompareTag("brickshrink"))
        {
            Vector2 scale;
            scale.x = paddle.transform.localScale.x / 2;
            scale.y = paddle.transform.localScale.y;
            paddle.transform.localScale = scale;
            Destroy(coll.gameObject);
            GameManager.playerScore++;
            GameManager.brickCount--;
        }

    }
}
