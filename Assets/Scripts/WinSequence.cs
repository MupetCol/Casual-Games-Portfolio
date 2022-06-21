using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSequence : MonoBehaviour
{
    [SerializeField]
    Animator UIAnimWL, UIAnimStart;

    [SerializeField]
    GameObject winPopUp, startPopUp;

    private ZigZagMovement movement;
    private void Start()
    {
       movement = GetComponent<ZigZagMovement>();
    }

    public void StartSequence()
    {
        StartCoroutine(Win());
    }

    public void Lost()
    {
        StartCoroutine(Lose());
    }

    public void StartCor()
    {
        StartCoroutine(SceneStart());
    }

    public IEnumerator Win()
    {
        movement.StopMoving();
        UIAnimWL.SetBool("PopUp", true);
        winPopUp.SetActive(true);
        AudioManager.instance.Play("Victory");
        AudioManager.instance.StopPlaying("Music");
        yield return new WaitForSeconds(7.32f);
    }

    public IEnumerator Lose()
    {
        movement.StopMoving();
        UIAnimWL.SetBool("PopUp", true);
        AudioManager.instance.Play("Defeat");
        AudioManager.instance.StopPlaying("Music");
        yield return null;
    }

    public IEnumerator SceneStart()
    {
        startPopUp.SetActive(false);
        UIAnimStart.SetBool("Scored", true);
        yield return new WaitForSeconds(2.5f);
        movement.speed = 3f;
    }
}
