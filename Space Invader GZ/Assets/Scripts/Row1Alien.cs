using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row1Alien : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 currentPos;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float repeatInterval;
    [SerializeField]
    private float horizontalSpeed = 1;
    private Vector2 endpos;
    public static bool r1wCollision;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("horizontalMove", waitTime,repeatInterval);
        rb2d = GetComponent<Rigidbody2D>();
    }

    void horizontalMove()   
    {  
        //Moved = False
        //rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y -0.5f));
        currentPos = rb2d.position;
        endpos = new Vector2(currentPos.x + horizontalSpeed, currentPos.y);
        rb2d.MovePosition(endpos);
    }

    void verticalMove()
    {
       rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y - 0.5f));
       //transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
    }

    void directionChange()
    {
        horizontalSpeed *= -1;
    }


    private void Update()
    {
        Debug.Log(horizontalSpeed);
        //Debug.Log("Any Collision is " + GameManager.anyCollision);
        //localWallColl = GameManager.anyCollision;
        if (GameManager.anyCollision)
        {
            //verticalMove();
            //directionChange();
            //r1wCollision = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.collider.CompareTag("Wall"))
        {
            /*OLD CODE THAT USES GAMEMANAGER SCRIPT
             *r1wCollision = true;
             *verticalMove();
             * directionChange();
            */
            gameObject.SendMessage("verticalMove", null, SendMessageOptions.RequireReceiver);
            gameObject.SendMessage("directionChange", null,SendMessageOptions.RequireReceiver);
        }

        if (coll.collider.CompareTag("Shield"))
        {
            Destroy(coll.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    void ResetVel()
    {
    }
}
