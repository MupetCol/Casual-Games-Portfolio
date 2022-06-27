using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    public float posit_RotMin, posit_RotMax, neg_RotMin, neg_RotMax;

    [SerializeField]
    float slashStrength;

    private Fruit fruit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.rigidbody.gameObject.name);
            fruit = hitInfo.collider.gameObject.GetComponentInParent<Fruit>();
            
            fruit.Cut(slashStrength, true);
        }


    }
}
