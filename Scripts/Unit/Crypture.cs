using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crypture : MonoBehaviour
{
    [SerializeField] Transform ReadyTiles;
    [SerializeField] Transform AttackArrow;
    [SerializeField] Transform HeadObject;
    [SerializeField] Transform HeadArrow;
    [SerializeField] SkeletonAnimation spine;
    [SerializeField] GameObject hpBar;
    [SerializeField] GameObject SkillList;

    //Effect
    [SerializeField] GameObject IceSfX;
    [SerializeField] GameObject HealSfX;
    [SerializeField] GameObject AuraSfX;
    [SerializeField] GameObject DamageBuffSfX;
    [SerializeField] GameObject DefBuffSfX;

    public float TotalDamage;
    public float FixDotHeal;
    public float PercentDotHeal;
    public float FixDotDeal;
    public float PercentDotDeal;

    public float m_Hp;
    public float m_HpRegen;
    public float m_Def;
    public float m_Speed;
    public float m_MaxHp;
    float m_fDistance;
    float m_fCurTime;

    Vector2 m_vt2Direction;
    [SerializeField] InstanceController m_Controller;
    UserCryptureData m_data;
    public UserCryptureData Data { get { return m_data; } }

    CryptureData m_baseStat;
    AttackType m_attackType;
    Parts m_parts;
    public Parts PartData { get { return m_parts; } }
    Color m_newColor;

    public List<Skill> m_SkillList;

    public void SetData(InstanceController controller, UserCryptureData data, Transform head)
    {
        m_Controller = controller;
        m_data = data;
        m_Speed = 5;
        if (data == null) return;
        m_baseStat = DataManager.Instance.CryptureInfo[data.Index];
        m_Hp = m_baseStat.char_hp;
        m_MaxHp = m_Hp;
        m_HpRegen = m_baseStat.char_hp_regen;
        m_Def = m_baseStat.char_def;
        m_Speed = m_baseStat.char_move_speed;
        m_fDistance = 0;
        m_fCurTime = 0;

        m_parts = new Parts();

        for (int i = 0; i < m_data.PartsIndex.Length; i++)
        {
            if (m_parts.m_listParts == null)
                m_parts.m_listParts = new List<PartData>();
            m_parts.m_listParts.Add(DataManager.Instance.PartInfo[m_data.PartsIndex[i]]);
        }

        m_parts.m_color = new Color(m_data.R, m_data.G, m_data.B);
        transform.localScale = new Vector3(m_baseStat.char_size_x, m_baseStat.char_size_y);
        //https://nakedgang.tistory.com/77

        SpineManager.SetSkeleton(spine, m_data.Index);

        SetParts();
        SetSkills();
        SetHead(head);
        UpdateHpBar();
    }

    public void SetParts()
    {
        SetPartsStat();
        SpineManager.SetSlots(PartData.m_listParts, spine.skeleton);
        SpineManager.SetColor(PartData.m_color, spine.skeleton);
    }

    void SetPartsStat()
    {
        PartData.SetAddition(m_newColor);
        if (m_attackType == null)
        {
            m_attackType = PartData.GetAttackType();
            if (m_attackType == null)
                Debug.Log($"해당 어택타입은 0입니다.");
            else
                m_attackType.attack_critical = PartData.MakeUp(m_attackType.attack_critical);
        }

        //현재 데이터
        m_Speed = PartData.Wing(m_baseStat.char_move_speed);
        m_MaxHp = PartData.Eye(m_baseStat.char_hp);
        m_Hp = m_MaxHp;
        m_Def = PartData.Mouth(m_baseStat.char_def);
        m_HpRegen = PartData.Background(m_baseStat.char_hp_regen);
    }

    void SetSkills()
    {
        for (int i = 0; i < PartData.m_listParts.Count; i++)
        {
            if (PartData.m_listParts[i].parts_type == SpineParts.ear || PartData.m_listParts[i].parts_type == SpineParts.tail)
            {
                Skill skill = new GameObject().AddComponent<Skill>();
                skill.transform.SetParent(SkillList.transform);
                if (PartData.m_listParts[i].parts_skill_idx1 != 0)
                {
                    skill.SetData(PartData.m_listParts[i].parts_skill_idx1, this);
                    m_SkillList.Add(skill);
                }
                if (PartData.m_listParts[i].parts_skill_idx2 != 0)
                {
                    skill.SetData(PartData.m_listParts[i].parts_skill_idx2, this);
                    m_SkillList.Add(skill);
                }
            }
        }
    }

    public void AddSkill(SkillData skillData)
    {
        Skill skill = new GameObject().AddComponent<Skill>();
        skill.transform.SetParent(SkillList.transform);
        skill.SetData(skillData.index, this);
        m_SkillList.Add(skill);
    }

    public void RemoveSkill(int index)
    {
        for (int i = 0; i < m_SkillList.Count; i++)
        {
            if (m_SkillList[i].m_Data.index == index)
                m_SkillList.RemoveAt(i);
        }
    }

    void Update()
    {
        if (DataManager.Instance.GameStart)
        {
            Movement();
            m_fCurTime += Time.deltaTime;

            if (m_fCurTime > 1f)
            {
                m_fCurTime = 0;
                HpRegen();
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return null;
        }
    }


    void HpRegen()
    {
        //최대 체력 이상으로 리젠 불가능하도록 처리
        if (m_Hp < m_MaxHp)
        {
            m_Hp += FixDotHeal + PercentDotHeal;

            if (m_Hp > m_MaxHp)
                m_Hp = m_MaxHp;

            UpdateHpBar();
        }
    }

    void UpdateHpBar()
    {
        if (m_Hp > 0)
            hpBar.transform.localScale = new Vector2(m_Hp / m_MaxHp, 1);
        else 
            hpBar.transform.localScale = Vector2.zero;
        Debug.Log($"Crypture HP: {m_Hp}");
    }

    void Die()
    {
        m_Hp = 0;
        Debug.Log("IM DYING!!!!");
        CheckSkill(EnSkillConditionType.die);
        gameObject.SetActive(false);

        if (HeadObject == null)
            m_Controller.GameOver();
    }

    public void SetHead(Transform head)
    {
        if (head == null)
            return;
        HeadObject = head;
    }

    //https://scvtwo.tistory.com/111
    public void SetDirection(Vector2 direction)
    {
        m_vt2Direction = direction;
    }

    void Movement()
    {
        float magnitude = Mathf.Clamp01(m_vt2Direction.magnitude);
        m_vt2Direction.Normalize();

        if (m_vt2Direction.x < 0 && spine.skeleton.ScaleX < 0)
        {
            spine.skeleton.ScaleX *= -1;
        }
        else if (m_vt2Direction.x > 0 && spine.skeleton.ScaleX > 0)
        {
            spine.skeleton.ScaleX *= -1;
        }

        transform.Translate(m_vt2Direction * m_Speed * magnitude * Time.deltaTime, Space.World);

        //회전식
        if (m_vt2Direction != Vector2.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, m_vt2Direction);
            ReadyTiles.rotation = rotation;
            if (AttackArrow != null)
                AttackArrow.rotation = rotation;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            m_Hp -= 10;
            UpdateHpBar();
        }
        if (collision.CompareTag("MonsterTile"))
        {
        }
    }

    public void OnEffects(EnDropTypeEffect effectType)
    {
        switch (effectType)
        {
            case EnDropTypeEffect.Utility_damageUp:
                DamageBuffSfX.SetActive(false);
                DamageBuffSfX.SetActive(!DamageBuffSfX.activeSelf);
                break;
            case EnDropTypeEffect.Utility_defUp:
                DefBuffSfX.SetActive(false);
                DefBuffSfX.SetActive(!DefBuffSfX.activeSelf);
                break;
            case EnDropTypeEffect.Utility_hpUp:
                HealSfX.SetActive(false);
                HealSfX.SetActive(!HealSfX.activeSelf);
                break;
        }
    }

    public void CheckSkill(EnSkillConditionType skillCondition)
    {
        for (int i = 0; i < m_SkillList.Count; i++)
        {
            m_SkillList[i].CheckCondition(skillCondition);
        }
    }

    public void CalculateDamage(float attack_damage)
    {
        CheckSkill(EnSkillConditionType.hit);
        float damage = attack_damage - m_Def;
        if (damage <= 0)
            return;

        m_Hp -= damage;

        if (m_Hp <= 0)
        {
            Die();
        }
        else
        {
            UpdateHpBar();
        }
    }

    public void StartAura(EnSkillEffectType effectType, EnSkillFix_PerType fixPerType, float addValue)
    {
        AuraSfX.SetActive(true);
    }

    public void EndAura(EnSkillEffectType effectType, EnSkillFix_PerType fixPerType, float addValue)
    {
        AuraSfX.SetActive(false);
    }
}
