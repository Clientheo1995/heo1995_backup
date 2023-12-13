using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject roster1;
    [SerializeField] Button roster2;
    [SerializeField] GameObject stageSelect1;
    [SerializeField] Button stageSelect2;
    [SerializeField] Button option;
    public CanvasController canvas;

    void Start()
    {
        roster2.onClick.AddListener(()=> {
            EventManager.OnEventOnPanel(EnUIPanel.Roster);
            roster1.SetActive(true);
            stageSelect1.SetActive(false);
            stageSelect2.gameObject.SetActive(true);
            roster2.gameObject.SetActive(false);
        });

        stageSelect2.onClick.AddListener(()=> {
            EventManager.OnEventOnPanel(EnUIPanel.GameStart);
            roster1.SetActive(false);
            roster2.gameObject.SetActive(true);
            stageSelect1.SetActive(true);
            stageSelect2.gameObject.SetActive(false);
        });

        option.onClick.AddListener(()=> {
            EventManager.OnEventOnPanel(EnUIPanel.Option);
        });
    }
}