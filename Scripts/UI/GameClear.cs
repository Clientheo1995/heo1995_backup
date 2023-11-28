using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public CanvasController canvas;
    [SerializeField] Button next;

    void Start()
    {
        next.onClick.AddListener(() => { canvas.OnPanel(EnUIPanel.StageSelect); });
    }
}
