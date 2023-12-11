using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] Button start;
    public CanvasController canvas;

    void Start()
    {
        start.onClick.AddListener(() => {
            SceneManager.LoadScene("Instance");
            //OnPanel(EnUIPanel.StageSelect);
            //OffPanel(EnUIPanel.Header); 
            //OffPanel(EnUIPanel.GameStart);
        });
    }
}
