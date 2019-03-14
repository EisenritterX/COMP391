using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    static bool onladder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetAxis("Vertical") != 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Input.GetAxis("Vertical"));
        }
        else if (PlayerMove.airborne == true)
        {

        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
