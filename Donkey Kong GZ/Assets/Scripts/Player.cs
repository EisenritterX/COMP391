using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (CharacterController2D))]
public class Player : MonoBehaviour
{

    [SerializeField]
    private float jumpHeight = 4f;
    [SerializeField]
    private float timeToJumpApex = 0.4f;
    float accelerationTimeAirborne = .2f;
    float accererationTimeGrounded = .1f;
    [SerializeField]
    float movespeed = 6;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
