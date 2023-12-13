using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Skill : MonoBehaviour
{
    class EffectForPrint
    {
        internal Character crypture;
        internal Monster monster;
        internal SkillEffect effect;

        public EffectForPrint(Character crypture, Monster monster, SkillEffect effect)
        {
            this.crypture = crypture;
            this.monster = monster;
            this.effect = effect;
        }
    }

    GameObject summonObject;
    public SkillData m_Data;
    List<SkillCondition> m_listConditions;
    List<SkillActivation> m_listActivations;
    List<SkillTarget> m_listTargets;
    List<SkillEffect> m_listEffects;

    float m_fForCoolTime;
    float m_fForConditionTime;

    bool m_bCoolTimeOK;
    bool m_bConditionOK;

    Character m_Crypture;
    Monster m_Monster;

    public void Update()
    {
        if (m_Data == null) return;

        m_fForCoolTime += Time.deltaTime;
        if (m_fForCoolTime >= m_Data.skill_cooltime)
        {
            m_bCoolTimeOK = true;
            m_fForCoolTime = 0f;
        }

        m_fForConditionTime += Time.deltaTime;
    }

    public void SetData(int index, Character crypture = null, Monster monster = null)
    {
        m_Data = DataManager.Instance.SkillInfo[index];
        m_Crypture = crypture;
        m_Monster = monster;

        //conditions
        if (m_listConditions == null)
            m_listConditions = new List<SkillCondition>();

        foreach (SkillCondition con in DataManager.Instance.SkillConditionInfo.Values)
        {
            if (con.skill_group == m_Data.skill_condition_group)
                m_listConditions.Add(con);
        }

        //activations
        if (m_listActivations == null)
            m_listActivations = new List<SkillActivation>();

        foreach (SkillActivation ac in DataManager.Instance.SkillActivationInfo.Values)
        {
            if (ac.skill_group == m_Data.skill_activation_group)
                m_listActivations.Add(ac);
        }

        //targets
        if (m_listTargets == null)
            m_listTargets = new List<SkillTarget>();

        foreach (SkillTarget tar in DataManager.Instance.SkillTargetInfo.Values)
        {
            if (tar.skill_group == m_Data.skill_target_group)
                m_listTargets.Add(tar);
        }

        //effects
        if (m_listEffects == null)
            m_listEffects = new List<SkillEffect>();

        foreach (SkillEffect ef in DataManager.Instance.SkillEffectInfo.Values)
        {
            if (ef.skill_group == m_Data.skill_effect_group)
                m_listEffects.Add(ef);
        }
    }

    public void CheckCondition(EnSkillConditionType skillCondition)
    {
        m_bCoolTimeOK = false;

        for (int i = 0; i < m_listConditions.Count; i++)
        {
            if (m_listConditions[i].condition_type == skillCondition)
            {
                if (m_listConditions[i].time_per_type == EnSkillTime_PerType.time)
                {
                    if (m_fForConditionTime >= m_listConditions[i].time_per_write)
                    {
                        m_bConditionOK = true;
                        m_fForConditionTime = 0f;
                    }
                    else
                    {
                        m_bConditionOK = false;
                    }
                }
                else if (m_listConditions[i].time_per_type == EnSkillTime_PerType.percent)
                {
                    int gacha = Random.Range(1, 100);
                    if (gacha < m_listConditions[i].time_per_write)
                    {
                        m_bConditionOK = true;
                    }
                    else
                    {
                        m_bConditionOK = false;
                        Debug.Log("Percent Failed");
                    }

                }
                else if (m_listConditions[i].time_per_type == EnSkillTime_PerType.none)
                {
                    m_bConditionOK = true;
                }

                if (m_bConditionOK)
                {
                    Activation();
                    m_bConditionOK = false;
                }
            }
        }
    }

    void Activation()
    {
        List<EffectForPrint> printEffects = new List<EffectForPrint>();

        //타겟과 이펙트 설정
        for (int i = 0; i < m_listTargets.Count; i++)
        {
            for (int j = 0; j < m_listEffects.Count; j++)
            {
                if (m_listTargets[i].condition_type == EnSkillTargetType.solo_ally)
                {
                    printEffects.Add(new EffectForPrint(m_Crypture, null, m_listEffects[j]));
                }
            }
        }

        //지속되어야하는 시간 activation
        for (int i = 0; i < printEffects.Count; i++)
        {
            for (int j = 0; j < m_listActivations.Count; j++)
            {
                if (m_listActivations[j].time_per_type == EnSkillTime_PerType.time)
                {
                }
                else if (m_listActivations[j].time_per_type == EnSkillTime_PerType.percent)
                {
                }

                switch (m_listActivations[j].activation_type)
                {
                    case EnSkillActivationType.aura:
                        StartCoroutine(ActivateAuraForTime(printEffects[i], m_listActivations[j].time_per_write));
                        break;
                    case EnSkillActivationType.time:
                        StartCoroutine(ActivateBuff(printEffects[i], m_listActivations[j].time_per_write));
                        break;
                    case EnSkillActivationType.normalStage:
                    case EnSkillActivationType.bossStage:
                    case EnSkillActivationType.wholeStage:
                        StartCoroutine(ActiveStageBuff(printEffects[i], m_listActivations[j].time_per_write));
                        break;
                    case EnSkillActivationType.summon:
                        {
                            if (m_Crypture != null)
                                StartCoroutine(Summon(printEffects[i].effect.skill_group, m_Crypture.gameObject.layer, m_Crypture.transform.position, printEffects[i].effect.skill_x, printEffects[i].effect.skill_x, printEffects[i].effect.fix_per_write));
                            else if (m_Monster!= null)
                                StartCoroutine(Summon(printEffects[i].effect.skill_group, m_Monster.gameObject.layer, m_Monster.transform.position, printEffects[i].effect.skill_x, printEffects[i].effect.skill_x, printEffects[i].effect.fix_per_write));
                        }
                        break;
                }
            }
        }
    }

    IEnumerator ActivateAuraForTime(EffectForPrint efp, float time)
    {
        if (efp.crypture != null)
        {
            //오라는 각 타일별로 데이터를 가지고 있을 수 있도록 한다
            //캐릭터에서는 오라를 껐다 켰다만 할 수 있게
            m_Crypture.StartAura(efp.effect.effect_type, efp.effect.fix_per_type, efp.effect.fix_per_write);
            yield return new WaitForSeconds(time);
            m_Crypture.EndAura(efp.effect.effect_type, efp.effect.fix_per_type, -efp.effect.fix_per_write);
        }
        else if (efp.monster != null)
        {
            yield return null;
        }
    }

    IEnumerator ActivateBuff(EffectForPrint efp, float time)
    {
        if (efp.crypture != null)
        {
            //m_Crypture.AddSkillBuff(efp.effect.effect_type, efp.effect.fix_per_type, efp.effect.fix_per_write);
            yield return new WaitForSeconds(time);
            //m_Crypture.AddSkillBuff(efp.effect.effect_type, efp.effect.fix_per_type, -efp.effect.fix_per_write);
        }
        else if (efp.monster != null)
        {
            yield return null;
        }
    }

    IEnumerator ActiveStageBuff(EffectForPrint efp, float time)
    {
        if (efp.crypture != null)
        {
            //m_Crypture.AddBuff(effectType, addValue);
            yield return new WaitForSeconds(time);//controller 에서 스테이지가 어떻게 변하는지 체크하여 상태 변환
            //m_Crypture.AddBuff(effectType, -addValue);
        }
        else if (efp.monster != null)
        {
            yield return null;
        }
    }

    IEnumerator Summon(int skillGroup, int layerNum, Vector3 position, int sizeX, int sizeY, float damage)
    {
        yield return null;
        summonObject = Resources.Load<GameObject>("Prefabs/SummonObject");

        SummonObject summon = Instantiate(summonObject, position, Quaternion.identity, null).GetComponent<SummonObject>();
        summon.gameObject.layer = layerNum;
        if (skillGroup == 1301)//버섯슬라임 지뢰
        {
            summon.SetData(EnSummonType.mine, sizeX, sizeY, damage);
        }
        else if (skillGroup == 1302)//폭탄 슬라임 사망시 폭탄
        {
            summon.SetData(EnSummonType.bomb, sizeX, sizeY, damage);
        }
    }
}
