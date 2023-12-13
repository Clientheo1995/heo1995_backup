using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Roster : MonoBehaviour
{
    public CanvasController canvas;

    //instantiate용
    [SerializeField] GameObject cryptureSlot;
    [SerializeField] Button auto;
    [SerializeField] Button registCancel;
    [SerializeField] Transform cryptureListContent;
    [SerializeField] List<RosterHeaderSlot> headerSlots;
    [SerializeField] List<Toggle> toggleNums;

    [SerializeField] GameObject register;
    [SerializeField] GameObject cryptureList;
    [SerializeField] CryptureSlot registerCrypture;

    public int selectedCryptureIndex;
    public bool isRegister = false;

    void Start()
    {
        for (int i = 0; i < toggleNums.Count; i++)
        {
            toggleNums[i].onValueChanged.AddListener(ChangeHeaderToggles);
        }

        registCancel.onClick.AddListener(() => { selectedCryptureIndex = -1; register.SetActive(false); cryptureList.SetActive(true); });
        SetHeaderSlot();
        SetCryptureList();
    }

    void ChangeHeaderToggles(bool isOn)
    {
        //각 로스터 기능 필요 - 클라이언트에 저장
    }

    void SetHeaderSlot()//처음 셋팅
    {
        //for (int i = 0; i < DataManager.Instance.TempRoster.Length; i++)
        //{
        //    headerSlots[i].SetCrypture(this, i, i);
        //}
    }

    public void ChangeRoster(Transform slot, int cryptureIndex, int rosterIndex)
    {
        //DataManager.Instance.TempRoster[rosterIndex] = DataManager.Instance.GStarCrypture[cryptureIndex];
        //headerSlots[rosterIndex].SetCrypture(this, rosterIndex, cryptureIndex);

        //isRegister = false;
        //SetCryptureList();

        //register.SetActive(false);
        //cryptureList.SetActive(true);

    }

    void SetCryptureList()
    {
        //for (int i = 0; i < cryptureListContent.childCount; i++)
        //{
        //    cryptureListContent.GetChild(i).gameObject.SetActive(false);
        //}

        //for (int i = 0; i < DataManager.Instance.GStarCrypture.Count; i++)
        //{
        //    for (int j = 0; j < DataManager.Instance.TempRoster.Length; j++)
        //    {
        //        if (DataManager.Instance.TempRoster[j] == DataManager.Instance.GStarCrypture[i])
        //            continue;

        //        CryptureSlot slot;
        //        if (cryptureListContent.childCount > i)
        //        {
        //            cryptureListContent.GetChild(i).gameObject.SetActive(true);
        //            slot = cryptureListContent.GetChild(i).GetComponent<CryptureSlot>();
        //            slot.SetCrypture(canvas, i);
        //        }
        //        else
        //        {
        //            slot = Instantiate(cryptureSlot, cryptureListContent).GetComponent<CryptureSlot>();
        //            slot.SetCrypture(canvas, i);
        //        }
        //    }
        //}
    }

    public void OpenRegister(int index)
    {
        registerCrypture.SetCrypture(canvas, index);
        selectedCryptureIndex = index;
        register.SetActive(true);
        cryptureList.SetActive(false);
        //DataManager.Instance.GStarCrypture[index];
    }

    //public void Register(int index)
    //{
    //    register.SetActive(true);
    //    cryptureList.SetActive(false);

    //    registerCrypture.SetCrypture(this, index);
    //    //DataManager.Instance.GStarCrypture[index];
    //}
}