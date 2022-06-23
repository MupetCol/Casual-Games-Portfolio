using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{

    [SerializeField]
    bool playerOne;

    [SerializeField]
    int racketSpeed = 10;

    Rigidbody2D rb;
    static bool started = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
    }

    public void SetStart()
    {
        started = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (started)
        {
            if (playerOne)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("VerticalArrows") * racketSpeed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("VerticalKeys") * racketSpeed);
            }
        }

    }
}
