using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool direction;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    private bool jump;
    [SerializeField]
    private float jumpForce;
    [SerializeField] 
    private LayerMask whatIsGround;

    private bool isGrounded; 

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
        InputControl();
    }

    private void FixedUpdate()
    {
        var vel = rb2d.velocity;
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();
        MovementControl(horizontal);
        flip(horizontal);
        ResetValues();
        Debug.Log("Grounded " +isGrounded);
        Debug.Log("Jump "+jump);
    }

    private void MovementControl(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            rb2d.AddForce(new Vector2(0, jumpForce));
            anim.SetBool("airborn", true);
        }

        rb2d.velocity = new Vector2(horizontal*speed,rb2d.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontal));  
    }
    
    private void InputControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true; 
        }
    }

    private void flip(float horizontal)
    {
        if (horizontal > 0 && !direction || horizontal<0 && direction)
        {
            direction = !direction;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private bool IsGrounded()
    {
        if (rb2d.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        anim.SetBool("airborn", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void ResetValues()
    {
        jump = false;

    }

}
