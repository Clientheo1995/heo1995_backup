using Spine.Unity;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class RosterHeaderSlot : MonoBehaviour
{
    [SerializeField] SkeletonGraphic spine;
    [SerializeField] Image background;
    [SerializeField] GameObject empty;
    [SerializeField] GameObject stars;

    [SerializeField] List<Image> star;

    [SerializeField] Button regist;
    [SerializeField] Button infoB;
    [SerializeField] Button releaseB;
    [SerializeField] int m_rosterIndex;

    EnSlotState slotState = EnSlotState.buttonOff;
    UserCryptureData m_SlotData;
    Roster roster;

    void Start()
    {
        regist.onClick.AddListener(() =>
        {
            if (m_SlotData == null) return;
            if (slotState == EnSlotState.buttonOff)
            {
                if (roster.isRegister)
                {
                    roster.ChangeRoster(transform, roster.selectedCryptureIndex, m_rosterIndex);
                }
                else
                {
                    slotState = EnSlotState.buttonOn;
                    infoB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
                    releaseB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
                }
            }
        });
        //infoB.onClick.AddListener(() => { Debug.Log($"크립쳐 {m_SlotData.Data.index}번의 정보팝업"); CloseButtons(); });
        //releaseB.onClick.AddListener(() => { DataManager.Instance.User = null; ClearThisSlot(); CloseButtons(); });

        //infoB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
        releaseB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
    }

    public void SetCrypture(Roster roster, int rosterIndex, int cryptureIndex)
    {
        empty.SetActive(false);
        this.roster = roster;

        //m_SlotData = DataManager.Instance.User.RosterCryptures[rosterIndex];
        //background.sprite = Resources.Load<Sprite>($"RCD_Sprites/Atlas/Background/{m_SlotData.parts[m_SlotData.parts.Count - 1].parts_spine}");
        //SpineManager.SetSkeletonUI(spine, m_SlotData.Data.index);
        //SpineManager.SetSlots(m_SlotData., spine.Skeleton);
        //SpineManager.SetColor(m_SlotData.color, spine.Skeleton);

        //spine.gameObject.SetActive(true);
        //stars.gameObject.SetActive(true);
        //background.gameObject.SetActive(true);

        //switch (data.star)
        //{//더러워
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

    public void ClearThisSlot()
    {
        empty.SetActive(true);
        spine.gameObject.SetActive(false);
        stars.gameObject.SetActive(false);
    }

    void CloseButtons()
    {
        slotState = EnSlotState.buttonOff;
        infoB.gameObject.SetActive(false);
        releaseB.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }
}
