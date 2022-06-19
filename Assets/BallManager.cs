using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    int angleMultp = 10;
    [SerializeField]
    int forceAddOnHit = 100;
    [SerializeField]
    int startingSpeed = 200;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartGame(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //General bounce on any surface
        if(collision.gameObject.layer == 1)
        {
            rb.AddForce(-collision.GetContact(0).point * 15);
        }


        if (collision.gameObject.tag == "Racket")
        {
            AudioManager.instance.Play("Bounce");
            Vector2 Dir = new Vector2((transform.position.x - collision.gameObject.transform.position.x) * angleMultp, (transform.position.y - collision.gameObject.transform.position.y)*angleMultp);
            Dir.Normalize();
            rb.AddForce(Dir* forceAddOnHit);
        }

        if (collision.gameObject.tag == "ScoreRight")
        {
            GameFlowManager.Scored(true);
        }else if(collision.gameObject.tag == "ScoreLeft")
        {
            GameFlowManager.Scored(false);
        }
    }

    public void RestartPos()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    public void StartGame(bool isRight)
    {
        if (isRight)
        {
            rb.AddForce(transform.right * startingSpeed);
        }
        else
        {
            rb.AddForce(-transform.right * startingSpeed);
        }

    }


}
