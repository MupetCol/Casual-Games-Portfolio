using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionReset : MonoBehaviour
{

    private WinSequence lostSeq;
    [SerializeField]
    Transform[] hitSpots;

    bool doFor = true;


    private void Start()
    {
        lostSeq = GetComponent<WinSequence>();
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .01f);
    //    if (colliders.Length < 2)
    //    {
    //        lostSeq.Lost();
    //    }
    //}

    private void Update()
    {
        if (doFor)
        {
            foreach (Transform t in hitSpots)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(t.position, .01f);
                Debug.Log(colliders.Length);
                if (colliders.Length < 2)
                {
                    lostSeq.Lost();
                    doFor = false;
                }
            }
        }

    }
}
