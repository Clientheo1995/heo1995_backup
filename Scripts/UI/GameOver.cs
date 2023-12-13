using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public CanvasController canvas;
    [SerializeField] Button video;
    [SerializeField] Button spendMoney;
    [SerializeField] Button home;
    [SerializeField] Button restart;
    [SerializeField] Text countTime;
    [SerializeField] Text score;
    [SerializeField] Text combo;
    [SerializeField] Text resumeCount;
    [SerializeField] GameObject continueBoard;
    [SerializeField] GameObject gameOverBoard;

    Coroutine continueCount = null;
    int remainSecond = 10;

    void Start()
    {
        resumeCount.gameObject.SetActive(false);

        video.onClick.AddListener(() => { StopCoroutine(continueCount); StartCoroutine(Resume()); });
        spendMoney.onClick.AddListener(() => { StopCoroutine(continueCount); StartCoroutine(Resume()); });
        home.onClick.AddListener(() => { GoHome(); });
        restart.onClick.AddListener(() => { ReStart(); });
    }

    void OnEnable()
    {
        if (canvas.now.isFirstGameOver)
        {
            EventManager.Instance.OnEventFirstGameOver();
            FirstGameOver();
            EventManager.Instance.OnEventInstanceValueReset();
        }
        else
        {
            LastGameOver();
        }
    }

    void EndOfGame()
    {
        DataManager.Instance.RecentLayer = -1;
        DataManager.Instance.KILLALL = true;
        EventManager.Instance.OnEventResetGameOverStack();
        EventManager.Instance.OnEventInstanceValueReset();
    }

    void GoHome()
    {
        EndOfGame();
        EventManager.Instance.OnEventOnPanel(EnUIPanel.GameStart);
    }

    void ReStart()//로스터 그대로, 1층부터 다시
    {
        EndOfGame();
        EventManager.Instance.OnEventOnPanel(EnUIPanel.StageSelect);
    }

    public void FirstGameOver()
    {
        continueBoard.SetActive(true);
        gameOverBoard.SetActive(false);

        continueCount = StartCoroutine(Count());
    }

    public void LastGameOver()
    {
        score.text = canvas.now.m_fScore.ToString();
        combo.text = canvas.now.KillCombo.ToString();
        gameOverBoard.SetActive(true);
        continueBoard.SetActive(false);
    }

    IEnumerator Count()
    {
        remainSecond = 9;
        while (remainSecond >= 0)
        {
            countTime.text = remainSecond.ToString();
            yield return new WaitForSeconds(1f);
            remainSecond -= 1;
        }

        LastGameOver();
    }

    IEnumerator Resume()
    {
        continueBoard.SetActive(false);
        gameOverBoard.SetActive(false);

        remainSecond = 3;
        resumeCount.gameObject.SetActive(true);
        while (remainSecond >= 1)
        {
            resumeCount.text = remainSecond.ToString();
            yield return new WaitForSeconds(1f);
            remainSecond -= 1;
        }

        resumeCount.gameObject.SetActive(false);
        EventManager.Instance.OnEventOnPanel(EnUIPanel.Instance);
    }
}