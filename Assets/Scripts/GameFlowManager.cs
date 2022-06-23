using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField]
    Volume urpVolume;

    [SerializeField]
    TMP_Text scoreLeft, scoreRight, win, nameLeft, nameRight;

    [SerializeField]
    TMP_InputField inputNameLeft, inputNameRight;

    [SerializeField]
    GameObject startPopUp;

    [SerializeField]
    Animator UIanim, UIRetry;

    [SerializeField]
    int sceneIndex;

    [SerializeField]
    int winCon = 5;

    [SerializeField]
    RacketMovement racket;

    BallManager ballManager;
    bool isRight = false;

    int leftScoreCount = 0, rightScoreCount = 0;
    UnityEngine.Rendering.Universal.LensDistortion lens;
    float t = 0;
    bool addTot = false;

    public delegate void OnScore(bool isRight);
    public static OnScore Scored;
    void Start()
    {
        urpVolume.sharedProfile.TryGet<UnityEngine.Rendering.Universal.LensDistortion>(out lens);
        AudioManager.instance.Play("Music");
        ballManager = FindObjectOfType<BallManager>();
        Scored = SetScore;
    }

    private void Update()
    {
        if (addTot && t < 1)
        {
            t += Time.deltaTime;
        }else if(!addTot && t > 0)
        {
            t -= Time.deltaTime;    
        }

        lens.intensity.value = Mathf.Lerp(0, -.3f, t);
        lens.scale.value = Mathf.Lerp(1, .7f, t);
    }

    public void StartP()
    {
        StartCoroutine(StartGame());
    }

    public void ShowControlsP()
    {
        StartCoroutine(ShowControls());
    }

    IEnumerator ShowControls()
    {
        UIanim.SetBool("Controls_Pong", true);
        yield return new WaitForSeconds(4f);
        UIanim.SetBool("Controls_Pong", false);
    }

    IEnumerator StartGame()
    {
        addTot = true;
        startPopUp.SetActive(false);
        nameRight.text = inputNameRight.text != "" ? inputNameRight.text : "RIGHT";
        nameLeft.text = inputNameLeft.text != "" ? inputNameLeft.text : "LEFT";
        yield return new WaitForSeconds(1f);
        UIanim.SetBool("Countdown", true);
        yield return new WaitForSeconds(2.5f);
        racket.SetStart();
        ballManager.StartGame(true);
        yield return null;
    }
    void ReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void SetScore(bool isRight)
    {
        if (isRight)
        {
            rightScoreCount++;
            if (rightScoreCount > winCon)
            {
                StartCoroutine(Win());
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
            if (leftScoreCount > winCon)
            {
                StartCoroutine(Win());
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
        UIanim.SetBool("Countdown", true);
        yield return new WaitForSeconds(2.5f);
        UIanim.SetBool("Countdown", false);
        ballManager.StartGame(isRight);

    }

    IEnumerator Win()
    {
        AudioManager.instance.Play("Victory");
        AudioManager.instance.StopPlaying("Music");
        yield return new WaitForSeconds(.84f);
        addTot = false;
        UIRetry.SetBool("PopUp", true);

    }
}
