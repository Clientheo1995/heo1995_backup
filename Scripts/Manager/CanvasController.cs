using Spine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] public MainMenu mainMenu;
    [SerializeField] public Instance instance;
    [SerializeField] GameOver gameOver;
    [SerializeField] GameClear gameClear;
    [SerializeField] public Roster roster;
    [SerializeField] public Header header;
    [SerializeField] OptionMenu option;
    [SerializeField] public GameStart gameStart;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject background;
    [SerializeField] public StageSelect stageSelect;
    [SerializeField] public InstanceController now;

    void Start()
    {
        mainMenu.canvas = this;
        instance.canvas = this;
        gameClear.canvas = this;
        gameOver.canvas = this;
        roster.canvas = this;
        option.canvas = this;
        header.canvas = this;
        gameStart.canvas = this;
        stageSelect.canvas = this;
    }

    public void Call()
    {

    }

    public void SetNextStage(int stageIndex, MapNode node, bool isBoss)
    {
        Debug.Log("toss stage data");
        now.SetStageData(stageIndex, node, isBoss);
    }

    public void OffPanel(EnUIPanel panel)
    {
        switch (panel)
        {
            case EnUIPanel.MainMenu:
                mainMenu.gameObject.SetActive(false);
                background.SetActive(false);
                break;
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
            case EnUIPanel.StageSelect:
                stageSelect.gameObject.SetActive(false);
                break;
        }
    }

    public void OnPanel(EnUIPanel panel)
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
                break;
            case EnUIPanel.Instance:
                DataManager.Instance.GameStart = true;
                instance.gameObject.SetActive(true);
                joystick.SetActive(true);
                now.GameInitialize();

                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.GameStart);
                OffPanel(EnUIPanel.MainMenu);
                OffPanel(EnUIPanel.Roster);
                OffPanel(EnUIPanel.StageSelect);
                break;
            case EnUIPanel.GameClear:
                gameClear.gameObject.SetActive(true);
                DataManager.Instance.GameStart = false;
                break;
            case EnUIPanel.GameOver:
                gameOver.gameObject.SetActive(true);
                DataManager.Instance.GameStart = false;
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
                break;
            case EnUIPanel.Header:
                header.gameObject.SetActive(true);
                break;
            case EnUIPanel.Option:
                option.gameObject.SetActive(true);
                break;
            case EnUIPanel.GameStart:
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
                break;
            case EnUIPanel.StageSelect:
                stageSelect.gameObject.SetActive(true);

                OffPanel(EnUIPanel.Header);
                OffPanel(EnUIPanel.Instance);
                OffPanel(EnUIPanel.GameClear);
                OffPanel(EnUIPanel.GameOver);
                OffPanel(EnUIPanel.Option);
                OffPanel(EnUIPanel.Roster);
                OffPanel(EnUIPanel.GameStart);
                break;
        }
    }
}
