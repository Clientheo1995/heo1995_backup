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

        score.text = canvas.now.m_fScore.ToString();
    }

    void OnEnable()
    {
        if (canvas.now.isFirstGameOver)
        {
            FirstGameOver();
            canvas.now.isFirstGameOver = false;
        }
        else
        {
            LastGameOver();
        }
    }

    void GoHome()
    {
        canvas.now.isFirstGameOver = true;
        DataManager.Instance.RecentLayer = 0;
        canvas.now.m_fScore = 0f;
        canvas.OnPanel(EnUIPanel.GameStart);
    }

    void ReStart()//로스터 그대로, 1층부터 다시
    {
        DataManager.Instance.RecentLayer = 0;
        canvas.now.m_fScore = 0f;
        canvas.now.isFirstGameOver = true;
        canvas.OnPanel(EnUIPanel.StageSelect);
    }

    public void FirstGameOver()
    {
        continueBoard.SetActive(true);
        gameOverBoard.SetActive(false);

        continueCount = StartCoroutine(Count());
    }

    public void LastGameOver()
    {
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
        canvas.OnPanel(EnUIPanel.Instance);
    }
}