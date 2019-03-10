using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 15f);
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + new Vector2(transform.right.x, transform.right.y) * Time.fixedDeltaTime*speed);
    }


}
