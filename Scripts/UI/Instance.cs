using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Instance : MonoBehaviour
{
    [SerializeField] List<CryptureSlot> slots;

    [SerializeField] Button swapButton;
    [SerializeField] GameObject swapPanel;

    public bool Swap = false;

    void Start()
    {
        swapButton.onClick.AddListener(() => { OnSwapPanel(); });
    }

    public void OnSwapPanel()
    {
        swapPanel.SetActive(!swapPanel.activeSelf);
        Swap = swapPanel.activeSelf;
        DataManager.Instance.Resume();
    }

    void OnEnable()
    {
        //for (int i = 0; i < DataManager.Instance.TempRoster.Length; i++)
        //{
        //    slots[i].SetCrypture(canvas, DataManager.Instance.TempRoster[i].index);
        //}
    }
}