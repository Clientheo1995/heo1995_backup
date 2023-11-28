using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] Button start;
    public CanvasController canvas;

    void Start()
    {
        start.onClick.AddListener(() => {
            canvas.OnPanel(EnUIPanel.StageSelect);
            canvas.OffPanel(EnUIPanel.Header); 
            canvas.OffPanel(EnUIPanel.GameStart);
        });
    }
}
