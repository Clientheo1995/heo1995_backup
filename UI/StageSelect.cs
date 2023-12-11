using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject Layer;
    [SerializeField] GameObject Node;
    [SerializeField] Transform content;

    [SerializeField] Transform RestSkill;
    [SerializeField] Transform RestSelect;
    [SerializeField] Transform SkillSelect;
    [SerializeField] Transform CryptureList;
    [SerializeField] Transform ChangeSkill;
    [SerializeField] Transform ChangedSkillCrypture;

    [SerializeField] Button restSlot0;
    [SerializeField] Button restSlot1;
    [SerializeField] Button restSlot2;

    [SerializeField] Button skillSlot0;
    [SerializeField] Button skillSlot1;
    [SerializeField] Button skillSlot2;

    [SerializeField] Image skillImage0;
    [SerializeField] Image skillImage1;
    [SerializeField] Image skillImage2;

    [SerializeField] Text skillName0;
    [SerializeField] Text skillName1;
    [SerializeField] Text skillName2;

    [SerializeField] Text skillDesc0;
    [SerializeField] Text skillDesc1;
    [SerializeField] Text skillDesc2;

    #region cryptureList
    //cryptureList
    [SerializeField] CryptureSlot cryptureSlot0;
    [SerializeField] CryptureSlot cryptureSlot1;
    [SerializeField] CryptureSlot cryptureSlot2;

    [SerializeField] Text hpText0;
    [SerializeField] Text hpText1;
    [SerializeField] Text hpText2;

    [SerializeField] Button skillGet0;
    [SerializeField] Button skillGet1;
    [SerializeField] Button skillGet2;

    [SerializeField] Button cryptureInfo0;
    [SerializeField] Button cryptureInfo1;
    [SerializeField] Button cryptureInfo2;

    [SerializeField] Image cryptureSkillImage0;
    [SerializeField] Image cryptureSkillImage1;
    [SerializeField] Image cryptureSkillImage2;

    [SerializeField] GameObject cryptureSkillempty0;
    [SerializeField] GameObject cryptureSkillempty1;
    [SerializeField] GameObject cryptureSkillempty2;

    [SerializeField] Image preSkill;
    [SerializeField] Image newSkill;

    [SerializeField] GameObject preSkillEmpty;

    [SerializeField] Button no;
    [SerializeField] Button yes;

    #endregion

    [SerializeField] CryptureSlot changedSkillCrypture;
    [SerializeField] Image changedSkill;
    [SerializeField] Button goNext;

    int SelectedRestSkillIndex = 0;
    int SelectedCryptureIndex = 0;

    void Awake()
    {
    }

    void Start()
    {
        restSlot0.onClick.AddListener(() => { StageRest(0); });
        restSlot1.onClick.AddListener(() => { StageRest(1); });
        restSlot2.onClick.AddListener(() => { StageRest(2); });
        //휴식스킬 리스트
        skillSlot0.onClick.AddListener(() => { SelectedRestSkillIndex = DataManager.Instance.RestSkillList[0].index; OnRestPanel(EnRestPanelOrder.skillSelect); });
        skillSlot1.onClick.AddListener(() => { SelectedRestSkillIndex = DataManager.Instance.RestSkillList[1].index; OnRestPanel(EnRestPanelOrder.skillSelect); });
        skillSlot2.onClick.AddListener(() => { SelectedRestSkillIndex = DataManager.Instance.RestSkillList[2].index; OnRestPanel(EnRestPanelOrder.skillSelect); });

        skillGet0.onClick.AddListener(() => { SelectedCryptureIndex = 0; OnRestPanel(EnRestPanelOrder.cryptureList); });
        skillGet1.onClick.AddListener(() => { SelectedCryptureIndex = 1; OnRestPanel(EnRestPanelOrder.cryptureList); });
        skillGet2.onClick.AddListener(() => { SelectedCryptureIndex = 2; OnRestPanel(EnRestPanelOrder.cryptureList); });

        cryptureInfo0.onClick.AddListener(() => { });
        cryptureInfo1.onClick.AddListener(() => { });
        cryptureInfo2.onClick.AddListener(() => { });

        no.onClick.AddListener(() => { OnRestPanel(EnRestPanelOrder.cryptureList); });
        yes.onClick.AddListener(() =>
        {
            if (SelectedCryptureIndex == 0)
            {
                DataManager.Instance.RestSkillList[0] = DataManager.Instance.SkillInfo[SelectedRestSkillIndex];
                //DataManager.Instance.TempRoster[0].AddSkill(DataManager.Instance.TempRoster[0].restSkill.index);
            }
            else if (SelectedCryptureIndex == 1)
            {
                DataManager.Instance.RestSkillList[1] = DataManager.Instance.SkillInfo[SelectedRestSkillIndex];
                //if (canvas.now.RestSkill1 != null)
                //    DataManager.Instance.TempRoster[1].RemoveSkill(canvas.now.RestSkill1.index);
                //canvas.now.RestSkill1 = DataManager.Instance.SkillInfo[SelectedRestSkillIndex];
                //canvas.now.CryptureList[1].AddSkill(canvas.now.RestSkill1);
            }
            else if (SelectedCryptureIndex == 2)
            {
                DataManager.Instance.RestSkillList[2] = DataManager.Instance.SkillInfo[SelectedRestSkillIndex];
                //if (canvas.now.RestSkill2 != null)
                //    DataManager.Instance.TempRoster[2].RemoveSkill(canvas.now.RestSkill2.index);
                //canvas.now.RestSkill2 = DataManager.Instance.SkillInfo[SelectedRestSkillIndex];
                //DataManager.Instance.TempRoster[2].AddSkill(canvas.now.RestSkill2);
            }

            OnRestPanel(EnRestPanelOrder.changeSkill);

        });

        goNext.onClick.AddListener(() => { OnRestPanel(EnRestPanelOrder.Length); });
    }

    void OnEnable()
    {
        if (DataManager.Instance.RecentLayer == -1)
        {
            for (int i = 0; i < content.childCount; i++)
                Destroy(content.GetChild(i).gameObject);

            DataManager.Instance.ThisStage = DataManager.Instance.StageInfo[40001];

            DataManager.Instance.Layers = new List<Transform>();
            MakeLayers();

            DataManager.Instance.WholeNodes = new List<MapNode>();
            MakeNodes();
        }
    }

    void MakeLayers()
    {
        for (int i = 0; i < DataManager.Instance.ThisStage.act_max; i++)
        {
            Transform layer = Instantiate(Layer, content).transform;
            DataManager.Instance.Layers.Add(layer);
            layer.SetAsFirstSibling();
        }
    }

    void MakeNodes()
    {
        List<float> stageTypePick = new List<float>();

        stageTypePick.Add(DataManager.Instance.ThisStage.battle_per);
        //stageTypePick.Add(DataManager.Instance.ThisStage.event_per);
        //stageTypePick.Add(DataManager.Instance.ThisStage.shop_per);
        stageTypePick.Add(DataManager.Instance.ThisStage.rest_per);

        List<Transform> layers = DataManager.Instance.Layers;

        for (int i = 0; i < layers.Count - 1; i++)
        {
            int nodeCount = Random.Range(2, 4);
            for (int j = 0; j < nodeCount; j++)
            {
                MapNode newNode = Instantiate(Node, DataManager.Instance.Layers[i].transform).GetComponent<MapNode>();
                DataManager.Instance.WholeNodes.Add(newNode);

                if (i > 0)
                {
                    if (nodeCount == 2)
                    {
                        if (layers[i - 1].childCount == 2)
                        {
                            if (j < layers[i - 1].childCount)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(j));
                            }
                            if (j + 1 < layers[i - 1].childCount)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(j + 1));
                            }
                        }

                        if (layers[i - 1].childCount == 4)
                        {
                            if (j == 0)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(0));
                                newNode.Front.Add(layers[i - 1].GetChild(1));
                            }
                            if (j == 1)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(2));
                                newNode.Front.Add(layers[i - 1].GetChild(3));
                            }
                        }
                    }
                    else if (nodeCount == 4)
                    {
                        if (j < 2)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(0));
                        }
                        else
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(1));
                        }
                    }
                    else if (nodeCount < layers[i - 1].childCount)
                    {
                        if (j < layers[i - 1].childCount)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j));
                        }
                        if (j + 1 < layers[i - 1].childCount)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j + 1));
                        }
                    }
                    else if (nodeCount >= layers[i - 1].childCount)
                    {
                        if (j < layers[i - 1].childCount)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j));
                        }
                        if (j - 1 > 0)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j - 1));
                        }
                    }
                }

                newNode.SetData((EnStageType)WeightedRandom.Picker(stageTypePick), i, DataManager.Instance.ThisStage.index, DataManager.Instance.ThisStage.act_max);
            }
        }

        MapNode boss = Instantiate(Node, DataManager.Instance.Layers[layers.Count - 1].transform).GetComponent<MapNode>();
        DataManager.Instance.WholeNodes.Add(boss);
        boss.SetData(EnStageType.Normal, layers.Count - 1, DataManager.Instance.ThisStage.index, DataManager.Instance.ThisStage.act_max, true);

        for (int i = 0; i < DataManager.Instance.Layers[layers.Count - 2].transform.childCount; i++)
        {
            boss.Front.Add(DataManager.Instance.Layers[layers.Count - 2].transform.GetChild(i));
        }
    }

    public void OnRestPanel(EnRestPanelOrder index)
    {
        RestSkill.gameObject.SetActive(index < EnRestPanelOrder.Length);
        RestSelect.gameObject.SetActive(index == EnRestPanelOrder.restSelect);
        SkillSelect.gameObject.SetActive(index == EnRestPanelOrder.skillSelect);
        CryptureList.gameObject.SetActive(index == EnRestPanelOrder.cryptureList);
        ChangeSkill.gameObject.SetActive(index == EnRestPanelOrder.changeSkill);
        ChangedSkillCrypture.gameObject.SetActive(index == EnRestPanelOrder.Length);

        //switch (index)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        skillImage0.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkillList[0].skill_img}");
        //        skillImage1.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkillList[1].skill_img}");
        //        skillImage2.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkillList[2].skill_img}");

        //        skillName0.text = DataManager.Instance.StringTable[canvas.now.RestSkillList[0].skill_name];
        //        skillName1.text = DataManager.Instance.StringTable[canvas.now.RestSkillList[1].skill_name];
        //        skillName2.text = DataManager.Instance.StringTable[canvas.now.RestSkillList[2].skill_name];

        //        skillDesc0.text = DataManager.Instance.StringTable[canvas.now.RestSkillList[0].skill_effect_description];
        //        skillDesc1.text = DataManager.Instance.StringTable[canvas.now.RestSkillList[1].skill_effect_description];
        //        skillDesc2.text = DataManager.Instance.StringTable[canvas.now.RestSkillList[2].skill_effect_description];

        //        break;
        //    case 2:
        //        cryptureSlot0.SetCrypture(canvas, DataManager.Instance.TempRoster[0].index);
        //        cryptureSlot1.SetCrypture(canvas, DataManager.Instance.TempRoster[1].index);
        //        cryptureSlot2.SetCrypture(canvas, DataManager.Instance.TempRoster[2].index);

        //        hpText0.text = $"{DataManager.Instance.TempRoster[0].data.char_hp / DataManager.Instance.TempRoster[0].data.char_hp}";
        //        hpText1.text = $"{DataManager.Instance.TempRoster[1].data.char_hp / DataManager.Instance.TempRoster[1].data.char_hp}";
        //        hpText2.text = $"{DataManager.Instance.TempRoster[2].data.char_hp / DataManager.Instance.TempRoster[2].data.char_hp}";

        //        if (canvas.now.RestSkill0 != null)
        //        {
        //            cryptureSkillempty0.SetActive(true);
        //            cryptureSkillImage0.gameObject.SetActive(true);
        //            cryptureSkillImage0.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkill0.skill_img}");
        //        }
        //        else
        //        {
        //            cryptureSkillempty0.SetActive(false);
        //            cryptureSkillImage0.gameObject.SetActive(false);
        //        }

        //        if (canvas.now.RestSkill1 != null)
        //        {
        //            cryptureSkillempty1.SetActive(true);
        //            cryptureSkillImage1.gameObject.SetActive(true);
        //            cryptureSkillImage1.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkill1.skill_img}");
        //        }
        //        else
        //        {
        //            cryptureSkillImage1.gameObject.SetActive(false);
        //            cryptureSkillempty1.SetActive(false);
        //        }

        //        if (canvas.now.RestSkill2 != null)
        //        {
        //            cryptureSkillempty2.SetActive(true);
        //            cryptureSkillImage2.gameObject.SetActive(true);
        //            cryptureSkillImage2.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkill2.skill_img}");
        //        }
        //        else
        //        {
        //            cryptureSkillempty1.SetActive(false);
        //            cryptureSkillImage2.gameObject.SetActive(false);
        //        }
        //        break;

        //    case 3:
        //        {
        //            preSkillEmpty.SetActive(false);
        //            preSkill.gameObject.SetActive(false);

        //            if (SelectedCryptureIndex == 0)
        //            {
        //                if (canvas.now.RestSkill0 != null)
        //                {
        //                    preSkillEmpty.SetActive(true);
        //                    preSkill.gameObject.SetActive(true);
        //                    preSkill.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkill0.skill_img}");
        //                }
        //            }
        //            else if (SelectedCryptureIndex == 1)
        //            {
        //                if (canvas.now.RestSkill1 != null)
        //                {
        //                    preSkillEmpty.SetActive(true);
        //                    preSkill.gameObject.SetActive(true);
        //                    preSkill.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkill1.skill_img}");
        //                }
        //            }
        //            else if (SelectedCryptureIndex == 2)
        //            {
        //                if (canvas.now.RestSkill2 != null)
        //                {
        //                    preSkillEmpty.SetActive(true);
        //                    preSkill.gameObject.SetActive(true);
        //                    preSkill.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{canvas.now.RestSkill2.skill_img}");
        //                }
        //            }

        //            newSkill.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{DataManager.Instance.SkillInfo[SelectedRestSkillIndex].skill_img}");
        //        }
        //        break;

        //    case 4:
        //        changedSkillCrypture.SetCrypture(canvas, DataManager.Instance.TempRoster[SelectedCryptureIndex].index);
        //        changedSkill.sprite = Resources.Load<Sprite>($"RCD_Sprites/skillIcons/{DataManager.Instance.SkillInfo[SelectedRestSkillIndex].skill_img}");
        //        break;
        //}
    }

    void StageRest(int index)
    {
        switch (index)
        {
            case 0://낮잠 최대체력의 20퍼마큼 모든 크립쳐 회복
                break;
            case 1://드르러엉
                {
                }
                break;
            case 2://주변탐색 50퍼확률로 최대 체력 10퍼만큼 모든크립처 회복 or 50퍼확률로 스킬 획득 실패 최대체력 10퍼만큼 모든 크립처 회복
                break;
        }
    }
}
