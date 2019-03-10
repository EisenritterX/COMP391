using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool direction;
    private Vector2 curPosition;
    private Vector2 endPos;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        CheckInput();
    }

    private void horizMove(float horizontal)
    {
        curPosition = rb2d.position;
        endPos = new Vector2(curPosition.x + horizontal, curPosition.y);
        rb2d.MovePosition(endPos);
    }

    private void vertMove(float vertical)
    {
        curPosition = rb2d.position;
        endPos = new Vector2(curPosition.x, curPosition.y + vertical);
        rb2d.MovePosition(endPos);
    }

    private void CheckInput()
    {

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            horizMove(1f);
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            horizMove(-1f);
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            vertMove(1f);
        }

    }
}


