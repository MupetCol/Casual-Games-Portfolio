using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    [SerializeField]
    float startingSpeed = 100f;

    Rigidbody2D rb;
    float zRot = 0;
    Vector2 movementDir;

    void Start()
    {
        movementDir = transform.up;
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(transform.up * startingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate()
    {
        //Always moving upwards and catching up to the rotation on click, updating Dir to new transform.up
        
        rb.MovePosition(rb.position + movementDir * startingSpeed * Time.fixedDeltaTime);

    }

    void ChangeDirection()
    {
        zRot = transform.eulerAngles.z;
        transform.Rotate(0, 0, -zRot * 2);
        movementDir = transform.up;
    }
}
