using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool anyCollision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Row1Alien.r1wCollision || Row2Alien.r2wCollision || Row3Alien.r3wCollision || Row4Alien.r4wCollision || Row5Alien.r5wCollision)
        {
            anyCollision = true;
        }
        else
        {
            anyCollision = false;
             }
        //Debug.Log(anyCollision);
    }

}