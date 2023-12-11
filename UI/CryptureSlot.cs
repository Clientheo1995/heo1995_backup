using Spine.Unity;

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class CryptureSlot : MonoBehaviour
{
    [SerializeField] SkeletonGraphic spine;
    [SerializeField] Image bgPart;
    [SerializeField] List<Image> star;

    [SerializeField] Button openButtons;
    [SerializeField] Button infoB;
    [SerializeField] Button useB;
    [SerializeField] int swapIndex;//임시
    CanvasController canvas;
    int tempIndex;

    EnSlotState slotState = EnSlotState.buttonOff;
    Crypture data;

    public void SetCrypture(CanvasController canvas, int index, EnSlotState slotState = EnSlotState.buttonOff)
    {
        this.canvas = canvas;
        //data = DataManager.Instance.User
        //tempIndex = index;


        //if (openButtons != null)
        //    openButtons.onClick.AddListener(() =>
        //{
        //    if (this.canvas.instance.Swap)
        //    {
        //        for (int i = 0; i < DataManager.Instance.TempRoster.Length; i++)
        //        {
        //            if (this.canvas.now.FirstCrypture.Data.index == DataManager.Instance.TempRoster[i].data.index)
        //            {
        //                DataManager.Instance.TempRoster[i].SetTempData(this.canvas.now.FirstCrypture.m_Hp, this.canvas.now.FirstCrypture.m_MaxHp, this.canvas.now.FirstCrypture.m_HpRegen, this.canvas.now.FirstCrypture.m_Def);
        //            }
        //        }
        //        this.canvas.now.FirstCrypture.SetData(this.canvas.now, DataManager.Instance.TempRoster[swapIndex].data.index, DataManager.Instance.TempRoster[swapIndex].parts, DataManager.Instance.TempRoster[swapIndex].color, null);
        //        //현재 데이터 집어넣기
        //        this.canvas.instance.OnSwapPanel();
        //    }
        //    else if (slotState == EnSlotState.buttonOff && !this.canvas.instance.Swap)
        //    {
        //        this.canvas.roster.isRegister = true;

        //        slotState = EnSlotState.buttonOn;
        //        //infoB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
                
        //        useB?.gameObject.SetActive(slotState == EnSlotState.buttonOn);
        //    }
        //});

        //if (infoB != null)
        //{
        //    infoB.onClick.AddListener(() =>
        //    {
        //        Debug.Log($"크립쳐 {data.Data.index}번의 정보팝업");
        //        CloseButtons();
        //    });
        //    infoB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
        //}

        //if (useB != null)
        //{
        //    useB.onClick.AddListener(() =>
        //    {
        //        this.canvas.roster.OpenRegister(data.Data.index);
        //        CloseButtons();
        //    });
        //    useB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
        //}

        //bgPart.sprite = Resources.Load<Sprite>($"RCD_Sprites/Atlas/Background/{data.parts[data.part.Count - 1].parts_spine}");
        //SpineManager.SetSkeletonUI(spine, data.Data.index);
        //SpineManager.SetSlots(data.PartData.m_listParts, spine.Skeleton);
        //SpineManager.SetColor(data.PartData.m_color, spine.Skeleton);

        //switch (data.star)
        //{
        //    case 0:
        //        star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
        //        star[0].gameObject.SetActive(true);
        //        star[1].gameObject.SetActive(false);
        //        star[2].gameObject.SetActive(false);
        //        star[3].gameObject.SetActive(false);
        //        star[4].gameObject.SetActive(false);
        //        break;
        //    case 1:
        //        star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
        //        star[0].gameObject.SetActive(true);
        //        star[1].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
        //        star[1].gameObject.SetActive(true);
        //        star[2].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
        //        star[2].gameObject.SetActive(true);
        //        star[3].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
        //        star[3].gameObject.SetActive(true);
        //        star[4].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
        //        star[4].gameObject.SetActive(true);
        //        break;
        //    case 2:
        //        star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
        //        star[0].gameObject.SetActive(true);
        //        star[1].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
        //        star[1].gameObject.SetActive(true);
        //        star[2].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
        //        star[2].gameObject.SetActive(true);
        //        star[3].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
        //        star[3].gameObject.SetActive(true);
        //        star[4].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
        //        star[4].gameObject.SetActive(true);
        //        break;
        //    case 3:
        //        star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
        //        star[0].gameObject.SetActive(true);
        //        star[1].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
        //        star[1].gameObject.SetActive(true);
        //        star[2].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
        //        star[2].gameObject.SetActive(true);
        //        star[3].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
        //        star[3].gameObject.SetActive(true);
        //        star[4].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
        //        star[4].gameObject.SetActive(true);
        //        break;
        //}
    }

    void CloseButtons()
    {
        slotState = EnSlotState.buttonOff;
        infoB.gameObject.SetActive(false);
        useB.gameObject.SetActive(false);
    }
}
