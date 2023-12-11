using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] public MainMenu mainMenu;
    [SerializeField] public Roster roster;
    [SerializeField] public Header header;
    [SerializeField] OptionMenu option;
    [SerializeField] public GameStart gameStart;
 
    [SerializeField] Button Title;

    //https://calvinjmkim.tistory.com/40

    Coroutine titleFade = null;

    void Awake()
    {
        EventManager.Instance.EOnPanel += OnPanel;
        EventManager.Instance.EOffPanel += OffPanel;
    }

    void OnDestroy()
    {
        EventManager.Instance.EOnPanel -= OnPanel;
        EventManager.Instance.EOffPanel -= OffPanel;
    }

    void Start()
    {
        Title.onClick.AddListener(() =>
        {
            if (titleFade != null)
            {
                StopCoroutine(titleFade);
                titleFade = null;
            }
            Title.gameObject.SetActive(false);
        });

        titleFade = StartCoroutine(TitleFadeOut());
        SoundManager.Instance.SetSound(AudioChannel.BGM, "bgm_lobby");
    }

    IEnumerator TitleFadeOut()
    {
        yield return new WaitForSeconds(2f);

        Title.gameObject.SetActive(false);
    }

    void OffPanel(EnUIPanel panel)
    {
        switch (panel)
        {
            case EnUIPanel.MainMenu:
                mainMenu.gameObject.SetActive(false);
                background.SetActive(false);
                break;
            case EnUIPanel.Roster:
                roster.gameObject.SetActive(false);
                break;
            case EnUIPanel.Header:
                header.gameObject.SetActive(false);
                break;
            case EnUIPanel.Option:
                option.gameObject.SetActive(false);
                break;
            case EnUIPanel.GameStart:
                gameStart.gameObject.SetActive(false);
                break;
        }
    }

    void OnPanel(EnUIPanel panel)
    {
        switch (panel)
        {
            case EnUIPanel.MainMenu:
                mainMenu.gameObject.SetActive(true);
                background.SetActive(true);

                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.Instance);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.GameStart);
                OffPanel(EnUIPanel.Roster);
                OffPanel(EnUIPanel.StageSelect);
                OffPanel(EnUIPanel.End);
                break;
            case EnUIPanel.Roster:
                roster.gameObject.SetActive(true);

                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.Instance);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.Option);
                OffPanel(EnUIPanel.GameStart);
                OffPanel(EnUIPanel.StageSelect);
                OffPanel(EnUIPanel.End);
                break;
            case EnUIPanel.Header:
                header.gameObject.SetActive(true);
                break;
            case EnUIPanel.Option:
                //option.gameObject.SetActive(true);
                break;
            case EnUIPanel.GameStart:
                SoundManager.Instance.SetSound(AudioChannel.BGM, "bgm_lobby");
                gameStart.gameObject.SetActive(true);
                mainMenu.gameObject.SetActive(true);
                background.SetActive(true);

                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.Instance);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.Option);
                OffPanel(EnUIPanel.Roster);
                OffPanel(EnUIPanel.StageSelect);
                OffPanel(EnUIPanel.End);
                break;
        }
    }
}
