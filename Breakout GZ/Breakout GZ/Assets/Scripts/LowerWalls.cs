using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.playerLives--;
            hitInfo.gameObject.SendMessage("RestartBall", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
