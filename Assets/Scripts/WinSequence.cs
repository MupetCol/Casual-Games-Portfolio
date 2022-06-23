using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSequence : MonoBehaviour
{
    [SerializeField]
    Animator UIAnimWL, UIAnimStart;

    [SerializeField]
    GameObject winPopUp, startPopUp;

    [SerializeField]
    TMP_Text text_retryText;

    private ZigZagMovement movement;
    private void Start()
    {
       movement = GetComponent<ZigZagMovement>();
    }

    public void StartWinSequence()
    {
        StartCoroutine(Win());
    }

    public void Lost()
    {
        StartCoroutine(Lose());
    }

    public void StartGame()
    {
        StartCoroutine(SceneStart());
        StartCoroutine(SpacebarAnim());
    }

    public IEnumerator Win()
    {
        movement.StopMoving();
        text_retryText.text = "RESTART";
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

    public IEnumerator SpacebarAnim()
    {
        UIAnimWL.SetBool("Controls_ZigZag", true);
        yield return new WaitForSeconds(2.5f);
        UIAnimWL.SetBool("Controls_ZigZag", false);
    }

    public IEnumerator SceneStart()
    {
        startPopUp.SetActive(false);
        UIAnimStart.SetBool("Countdown", true);
        yield return new WaitForSeconds(2.5f);
        movement.SetStart();
        movement.speed = 3f;
    }
}
