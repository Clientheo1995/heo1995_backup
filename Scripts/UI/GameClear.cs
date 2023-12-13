using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public CanvasController canvas;
    [SerializeField] Button next;
    [SerializeField] GameObject Final;

    void Start()
    {
        next.onClick.AddListener(() =>
        {
            if (DataManager.Instance.RecentLayer == DataManager.Instance.Layers.Count - 1)
            {
                EventManager.Instance.OnEventOnPanel(EnUIPanel.End);
            }
            else
            {
                EventManager.Instance.OnEventOnPanel(EnUIPanel.StageSelect);
            }
        });
    }


}
