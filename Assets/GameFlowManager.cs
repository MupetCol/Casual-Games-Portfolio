using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreLeft, scoreRight, win, nameLeft, nameRight;

    [SerializeField]
    Animator UIanim;

    [SerializeField]
    int winCon = 5;

    BallManager ballManager;
    bool isRight = false;

    int leftScoreCount = 0, rightScoreCount = 0;

    public delegate void OnScore(bool isRight);
    public static OnScore Scored;
    void Start()
    {
        ballManager = FindObjectOfType<BallManager>();
        Scored = SetScore;
    }

    void SetScore(bool isRight)
    {
        if (isRight)
        {
            rightScoreCount++;
            if (leftScoreCount > winCon || rightScoreCount > winCon)
            {
                UIanim.SetBool("Win", true);
                win.text = nameLeft.text + " WON!!";
                ballManager.RestartPos();
                scoreRight.text = rightScoreCount.ToString();
            }
            else
            {
                this.isRight = isRight;
                StartCoroutine(Restart());
                scoreRight.text = rightScoreCount.ToString();
            }

        }
        else
        {
            leftScoreCount++;
            if (leftScoreCount > winCon || rightScoreCount > winCon)
            {
                UIanim.SetBool("Win", true);
                win.text = nameRight.text + " WON!!";
                ballManager.RestartPos();
                scoreLeft.text = leftScoreCount.ToString();
            }
            else
            {
                this.isRight = isRight;
                StartCoroutine(Restart());
                scoreLeft.text = leftScoreCount.ToString();
            }

        }


    }

    public IEnumerator Restart()
    {
        ballManager.RestartPos();
        UIanim.SetBool("Scored", true);
        yield return new WaitForSeconds(2.5f);
        UIanim.SetBool("Scored", false);
        ballManager.StartGame(isRight);

    }

    void Win()
    {

    }
}
