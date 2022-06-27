using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    GameObject fruit;

    MouseRaycast mouse;

    SpriteRenderer r_leftHalf, r_rightHalf, r_topHalf, r_downHalf;
    Collider2D fruitCollider;
    public Rigidbody2D rb_leftHalf, rb_rightHalf;

    [SerializeField]
    float lifetime = 5f;
    float counter_lifetime = 0;

    bool been_Cut = false;

    float leftRot, rightRot;

    private void Start()
    {
        r_leftHalf = transform.GetChild(1).GetComponent<SpriteRenderer>();
        r_rightHalf = transform.GetChild(2).GetComponent<SpriteRenderer>();
        r_topHalf = transform.GetChild(3).GetComponent<SpriteRenderer>();
        r_downHalf = transform.GetChild(4).GetComponent<SpriteRenderer>();

        fruitCollider = transform.GetChild(0).GetComponent<Collider2D>();
        rb_leftHalf = transform.GetChild(1).GetComponent<Rigidbody2D>();
        rb_rightHalf = transform.GetChild(2).GetComponent<Rigidbody2D>();


        mouse = FindObjectOfType<MouseRaycast>();

        Random.InitState (System.DateTime.Now.Millisecond);
        leftRot = Random.Range(mouse.neg_RotMin, mouse.neg_RotMax);
        rightRot = Random.Range(mouse.posit_RotMin, mouse.posit_RotMax);
    }
    private void Update()
    {
        counter_lifetime += Time.deltaTime;
        if (counter_lifetime > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (been_Cut)
        {
            StartRotating(rb_leftHalf, leftRot);
            StartRotating(rb_rightHalf, rightRot);
        }
    }

    public void Cut(float strength, bool isVertical)
    {
        fruit.SetActive(false);
        r_leftHalf.enabled = true;
        r_rightHalf.enabled = true;

        rb_leftHalf.AddForce(new Vector2(-strength, 0) );
        rb_rightHalf.AddForce(new Vector2(strength, 0) );

        been_Cut = true;
    }

    public void StartRotating(Rigidbody2D rb, float rotationSpeed)
    {
        rb.transform.Rotate(0,0, rotationSpeed, Space.Self);
    }
}
