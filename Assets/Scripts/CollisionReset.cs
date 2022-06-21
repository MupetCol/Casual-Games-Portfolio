using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionReset : MonoBehaviour
{

    private WinSequence lostSeq;

    private void Start()
    {
        lostSeq = GetComponent<WinSequence>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .05f);
        if (colliders.Length < 2)
        {
            lostSeq.Lost();
        }
        

    }
}
