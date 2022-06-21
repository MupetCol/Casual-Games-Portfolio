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
        ReloadScene();
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

    IEnumerator StartGame()
    {
        addTot = true;
        startPopUp.SetActive(false);
        nameRight.text = inputNameRight.text;
        nameLeft.text = inputNameLeft.text;
        yield return new WaitForSeconds(1f);
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
        UIanim.SetBool("Scored", true);
        yield return new WaitForSeconds(2.5f);
        UIanim.SetBool("Scored", false);
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
