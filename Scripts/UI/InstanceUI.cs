using UnityEngine;
using static EventManager;

public class InstanceCanvas : MonoBehaviour
{
    [SerializeField] Instance instance;
    [SerializeField] GameOver gameOver;
    [SerializeField] GameClear gameClear;
    [SerializeField] OptionMenu option;
    [SerializeField] GameObject joystick;
    [SerializeField] StageSelect stageSelect;

    void Awake()
    {
        EventManager.Instance.ESetNextStage += SetNextStage;
        EventManager.Instance.EOnPanel += OnPanel;
        EventManager.Instance.EOffPanel += OffPanel;
        EventManager.Instance.EOnRestPanel += OnRestPanel;
    }

    void OnDestroy()
    {
        EventManager.Instance.ESetNextStage -= SetNextStage;
        EventManager.Instance.EOnPanel -= OnPanel;
        EventManager.Instance.EOffPanel -= OffPanel;
        EventManager.Instance.EOnRestPanel -= OnRestPanel;
    }

    void Start()
    {
    }

    void SetNextStage(int stageIndex, MapNode node, bool isBoss)
    {
        Debug.Log("toss stage data");
        if (node.stageType == EnStageType.Normal)
        {
            EventManager.Instance.OnEventSetStageData(stageIndex, node, isBoss);
            OnPanel(EnUIPanel.Instance);
        }
        else if (node.stageType == EnStageType.Rest)
        {
            OnRestPanel(0);
            DataManager.Instance.ThisNode = node;
        }
    }

    void OffPanel(EnUIPanel panel)
    {
        switch (panel)
        {
            case EnUIPanel.Instance:
                instance.gameObject.SetActive(false);
                joystick.SetActive(false);
                break;
            case EnUIPanel.GameClear:
                gameClear.gameObject.SetActive(false);
                break;
            case EnUIPanel.GameOver:
                gameOver.gameObject.SetActive(false);
                break;
            case EnUIPanel.Option:
                option.gameObject.SetActive(false);
                break;
            case EnUIPanel.StageSelect:
                stageSelect.gameObject.SetActive(false);
                break;

        }
    }

    void OnPanel(EnUIPanel panel)
    {
        switch (panel)
        {
            case EnUIPanel.Instance:
                DataManager.Instance.GameStart = true;
                instance.gameObject.SetActive(true);
                joystick.SetActive(true);
                EventManager.Instance.OnEventInitialize();
                //if (now.isBoss)
                //    SoundManager.Instance.SetSound(AudioChannel.BGM, "bgm_battle_6");
                //else
                //    SoundManager.Instance.SetSound(AudioChannel.BGM, "bgm_battle_0");

                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.GameStart);
                OffPanel(EnUIPanel.MainMenu);
                OffPanel(EnUIPanel.Roster);
                OffPanel(EnUIPanel.StageSelect);
                OffPanel(EnUIPanel.End);
                break;
            case EnUIPanel.GameClear:
                gameClear.gameObject.SetActive(true);
                DataManager.Instance.GameStart = false;
                SoundManager.Instance.SetSound(AudioChannel.UI, "fx_ui_Win");
                break;
            case EnUIPanel.GameOver:
                gameOver.gameObject.SetActive(true);
                DataManager.Instance.GameStart = false;
                break;
            case EnUIPanel.Option:
                //option.gameObject.SetActive(true);
                break;
            case EnUIPanel.StageSelect:
                SoundManager.Instance.SetSound(AudioChannel.BGM, "bgm_lobby");
                stageSelect.gameObject.SetActive(true);
                OffPanel(EnUIPanel.MainMenu);
                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.Instance);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.Option);
                OffPanel(EnUIPanel.Roster);
                OffPanel(EnUIPanel.GameStart);
                OffPanel(EnUIPanel.End);
                break;
        }
    }

    void OnRestPanel(EnRestPanelOrder restIndex)
    {
        if (!stageSelect.gameObject.activeSelf)
            OnPanel(EnUIPanel.StageSelect);

        stageSelect.OnRestPanel(restIndex);
    }
}
