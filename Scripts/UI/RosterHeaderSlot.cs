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
    TempGStarCrypture data;
    Roster roster;

    void Start()
    {
        regist.onClick.AddListener(() =>
        {
            if (data == null) return;
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
        infoB.onClick.AddListener(() => { Debug.Log($"크립쳐 {data.index}번의 정보팝업"); CloseButtons(); });
        releaseB.onClick.AddListener(() => { DataManager.Instance.TempRoster[m_rosterIndex] = null; ClearThisSlot(); CloseButtons(); });

        infoB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
        releaseB.gameObject.SetActive(slotState == EnSlotState.buttonOn);
    }

    public void SetCrypture(Roster roster, int rosterIndex, int cryptureIndex)
    {
        empty.SetActive(false);
        this.roster = roster;

        DataManager.Instance.TempRoster[rosterIndex] = DataManager.Instance.GStarCrypture[cryptureIndex];
        data = DataManager.Instance.TempRoster[rosterIndex];
        background.sprite = Resources.Load<Sprite>($"RCD_Sprites/Atlas/Background/{data.parts[data.parts.Count - 1].parts_spine}");
        SpineManager.SetSkeletonUI(spine, data.data.index);
        SpineManager.SetSlots(data.parts, spine.Skeleton);
        SpineManager.SetColor(data.color, spine.Skeleton);

        spine.gameObject.SetActive(true);
        stars.gameObject.SetActive(true);
        background.gameObject.SetActive(true);

        switch (data.star)
        {
            case 0:
                star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
                star[0].gameObject.SetActive(true);
                break;
            case 1:
                star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
                star[0].gameObject.SetActive(true);
                star[1].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
                star[1].gameObject.SetActive(true);
                star[2].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
                star[2].gameObject.SetActive(true);
                star[3].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
                star[3].gameObject.SetActive(true);
                star[4].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_0");
                star[4].gameObject.SetActive(true);
                break;
            case 2:
                star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
                star[0].gameObject.SetActive(true);
                star[1].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
                star[1].gameObject.SetActive(true);
                star[2].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
                star[2].gameObject.SetActive(true);
                star[3].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
                star[3].gameObject.SetActive(true);
                star[4].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_1");
                star[4].gameObject.SetActive(true);
                break;
            case 3:
                star[0].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
                star[0].gameObject.SetActive(true);
                star[1].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
                star[1].gameObject.SetActive(true);
                star[2].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
                star[2].gameObject.SetActive(true);
                star[3].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
                star[3].gameObject.SetActive(true);
                star[4].sprite = Resources.Load<Sprite>($"RCD_Sprites/UI/Icon_Star_2");
                star[4].gameObject.SetActive(true);
                break;
        }
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
