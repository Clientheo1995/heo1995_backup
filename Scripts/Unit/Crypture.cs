using Spine.Unity;

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;

public class Crypture : MonoBehaviour
{
    //[SerializeField] int Part_Wing;
    //[SerializeField] int Part_Hat;
    //[SerializeField] int Part_Tail;
    //[SerializeField] int Part_Eye;
    //[SerializeField] int Part_Mouth;
    //[SerializeField] int Part_Pattern;
    //[SerializeField] int Part_Background;
    //[SerializeField] Color Part_Color;

    [SerializeField] Transform ReadyTiles;
    [SerializeField] Transform AttackArrow;
    [SerializeField] Transform HeadObject;
    [SerializeField] Transform HeadArrow;
    [SerializeField] SkeletonAnimation spine;
    [SerializeField] GameObject hpBar;
    [SerializeField] GameObject SkillList;

    public float TotalDamage;
    public float FixDotHeal;
    public float PercentDotHeal;
    public float FixDotDeal;
    public float PercentDotDeal;
    public float BloodSucking;

    float m_Hp;
    float m_HpRegen;
    float m_Def;
    public float m_Speed;
    float m_MaxHp;
    float m_fDistance;
    float m_fCurTime;

    Vector2 m_vt2Direction = Vector2.up;
    Dictionary<int, string> m_dicParts;
    InstanceController m_Controller;
    TileEventListener m_TileListener;
    CryptureData m_data;
    AttackType m_attackType;
    Parts m_parts;
    Color m_newColor;

    public List<Skill> m_SkillList;

    void Start()
    {
        //StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return DataManager.Instance.DATALOADCOMPLETE;
    }

    public void SetData(InstanceController controller, int index, List<PartData> parts, Color color, Transform head)
    {
        m_Controller = controller;
        m_data = DataManager.Instance.CryptureInfo[index];
        m_Hp = m_data.char_hp;
        m_MaxHp = m_Hp;
        m_HpRegen = m_data.char_hp_regen;
        m_Def = m_data.char_def;
        m_Speed = m_data.char_move_speed;
        m_fDistance = 0;
        m_fCurTime = 0;

        m_parts = new Parts(this);
        m_parts.m_listParts = parts;
        m_parts.m_color = color;

        //https://nakedgang.tistory.com/77

        SpineManager.SetSkeleton(spine, index);

        SetParts();
        SetSkills();
        SetHead(head);
    }

    public void SetParts()
    {
        //유저데이터 만든 후에 

        SetPartsStat();
        SpineManager.SetSlots(m_parts.m_listParts, spine.skeleton);
        SpineManager.SetColor(m_parts.m_color, spine.skeleton);
    }

    void SetPartsStat()
    {
        m_parts.SetAddition(m_newColor);
        if (m_attackType == null)
        {
            m_attackType = m_parts.GetAttackType();
            if (m_attackType == null)
                Debug.Log($"해당 어택타입은 0입니다.");
            else
                m_attackType.attack_critical = m_parts.MakeUp(m_attackType.attack_critical);
        }
        int atIndex = m_parts.Tail();
        if (atIndex > 0)
        {
            m_TileListener = AttackManager.Instance.MakeReadyTile(DataManager.Instance.AttackTypeInfo[atIndex], transform, ReadyTiles);
        }
        m_Speed = m_parts.Wing(m_data.char_move_speed);
        Debug.Log($"MoveSpeed: {m_Speed} =>  DataSpeed({m_data.char_move_speed}) + DataSpeed({m_data.char_move_speed}) * facter");
        m_Hp = m_parts.Eye(m_data.char_hp);
        Debug.Log($"Hp: {m_Hp} =>  DataHp({m_data.char_hp}) + DataHp({m_data.char_hp}) * facter");
        m_Def = m_parts.Mouth(m_data.char_def);
        Debug.Log($"Def: {m_Def} =>  DataDef({m_data.char_def}) + DataDef({m_data.char_def}) * facter");
        m_HpRegen = m_parts.Background(m_data.char_hp_regen);
        Debug.Log($"HpRegen: {m_HpRegen} =>  DataRegen({m_data.char_hp_regen}) + DataRegen({m_data.char_hp_regen}) * facter");
    }

    void SetSkills()
    {
        for (int i = 0; i < m_parts.m_listParts.Count; i++)
        {
            if (m_parts.m_listParts[i].parts_type == SpineParts.ear || m_parts.m_listParts[i].parts_type == SpineParts.tail)
            {
                Skill skill = new GameObject().AddComponent<Skill>();
                skill.transform.SetParent(SkillList.transform);
                if (m_parts.m_listParts[i].parts_skill_idx1 != 0)
                {
                    skill.SetData(m_parts.m_listParts[i].parts_skill_idx1);
                    m_SkillList.Add(skill);
                }
                if (m_parts.m_listParts[i].parts_skill_idx2 != 0)
                {
                    skill.SetData(m_parts.m_listParts[i].parts_skill_idx2);
                    m_SkillList.Add(skill);
                }
            }
        }
    }

    void Update()
    {
        if (DataManager.Instance.GameStart)
        {
            if (HeadObject == null)
                HeadMovement();
            else
                FollowUp();

            m_fCurTime += Time.deltaTime;

            if (m_fCurTime > 1f)
            {
                m_fCurTime = 0;
                HpRegen();
            }
        }
    }

    void HpRegen()
    {
        //최대 체력 이상으로 리젠 불가능하도록 처리
        if (m_Hp < m_MaxHp)
        {
            m_Hp += m_data.char_hp_regen;
            m_Hp += FixDotHeal + PercentDotHeal;

            if (m_Hp > m_MaxHp)
                m_Hp = m_MaxHp;

            UpdateHpBar();
        }
    }

    void UpdateHpBar()
    {
        hpBar.transform.localScale = new Vector2(m_Hp / m_MaxHp, 1);
        CheckSkill(EnSkillConditionType.hit);
    }

    void Die()
    {
        m_Hp = 0;
        Debug.Log("IM DYING!!!!");
        //m_Controller.ExceptCrypture(transform);
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
        m_Controller.Direction = direction;
        m_vt2Direction = direction;
    }

    void HeadMovement()
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

    void FollowUp()
    {
        if (HeadArrow == null)
            HeadArrow = HeadObject.GetChild(0);

        if (m_Controller.Direction.x < 0 && spine.skeleton.ScaleX < 0)
        {
            spine.skeleton.ScaleX *= -1;
        }
        else if (m_Controller.Direction.x > 0 && spine.skeleton.ScaleX > 0)
        {
            spine.skeleton.ScaleX *= -1;
        }

        m_fDistance = Vector3.Distance(HeadObject.localPosition, transform.localPosition);

        float T = Time.deltaTime * m_fDistance / DataManager.MinDistance * m_Controller.FollowSpeed;

        if (T > 0.1f)
            T = 0.1f;

        transform.localPosition = Vector3.Slerp(transform.localPosition, HeadObject.localPosition, T);
        ReadyTiles.rotation = Quaternion.Slerp(ReadyTiles.localRotation, HeadArrow.localRotation, T);
        if (AttackArrow != null)
            AttackArrow.localRotation = Quaternion.Slerp(AttackArrow.localRotation, HeadArrow.localRotation, T);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //Die();
        }
        else if (collision.CompareTag("Wall"))
        {
            //https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=ka87921001&logNo=221574578423
            Die();
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

        Debug.Log($"Crypture Attacked Hp: {m_Hp}");
    }

    public void AddItemBuff(EnDropTypeEffect effectType, float value1, float value2, float value3, float value4, float value5, float value6)
    {
        switch (effectType)
        {
            case EnDropTypeEffect.Utility_damageUp:
                {
                    float factor = value1 * 0.01f;
                    m_TileListener.DamageBuff += m_TileListener.Damage * factor;
                }
                break;
            case EnDropTypeEffect.Utility_defUp:
                {
                    float factor = value1 * 0.01f;
                    m_Def += m_data.char_def * factor;
                }
                break;
            case EnDropTypeEffect.Utility_hpUp:
                {
                    m_Hp += m_data.char_hp * value1;
                    if (m_Hp > m_MaxHp)
                        m_Hp = m_MaxHp;
                    UpdateHpBar();
                }
                break;
        }
    }

    public void AddSkillBuff(EnSkillEffectType effectType, EnSkillFix_PerType fixPerType, float addValue)
    {
        switch (effectType)
        {
            case EnSkillEffectType.dmgInc:
            case EnSkillEffectType.dmgDec:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    m_TileListener.DamageBuff += (int)addValue;
                    Debug.Log($"타일데미지 변화: {m_TileListener.DamageBuff}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    m_TileListener.DamageBuff += m_TileListener.Damage * factor;
                    Debug.Log($"타일데미지 변화: {m_TileListener.DamageBuff}");
                }

                break;
            case EnSkillEffectType.defInc:
            case EnSkillEffectType.defDec:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    m_Def += (int)addValue;
                    Debug.Log($"방어력 변화: {m_Def}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    m_Def += m_data.char_def * factor;
                    Debug.Log($"타일데미지 변화: {m_Def}");
                }

                break;
            case EnSkillEffectType.hpRegenInc:
            case EnSkillEffectType.hpRegenDec:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    m_HpRegen += (int)addValue;
                    Debug.Log($"체력회복량 변화: {m_HpRegen}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    m_HpRegen += m_data.char_hp_regen * factor;
                    Debug.Log($"체력회복량 변화: {m_HpRegen}");
                }
                break;
            case EnSkillEffectType.maxHpInc:
            case EnSkillEffectType.maxHpDec:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    m_MaxHp += (int)addValue;
                    Debug.Log($"체력 변화: {m_Hp}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    m_MaxHp += m_data.char_hp * factor;
                    Debug.Log($"체력 변화: {m_Hp}");
                }
                if (m_MaxHp < 0)
                    m_MaxHp = 0;
                break;
            case EnSkillEffectType.bomb:
                if (fixPerType == EnSkillFix_PerType.fix)
                {

                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                }

                Debug.Log($"준비되지 않았습니다 BOMB");
                break;
            case EnSkillEffectType.laser:
                if (fixPerType == EnSkillFix_PerType.fix)
                {

                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                }
                Debug.Log($"준비되지 않았습니다 LASER");
                break;
            case EnSkillEffectType.gainHp:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    FixDotHeal += (int)addValue;
                    Debug.Log($"도트힐량 변화: {FixDotHeal}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    PercentDotHeal += FixDotHeal * factor;
                    Debug.Log($"도트힐량 변화: {PercentDotHeal}");
                }

                if (FixDotHeal < 0)
                    FixDotHeal = 0;
                if (PercentDotHeal < 0)
                    PercentDotHeal = 0;
                break;

            case EnSkillEffectType.gainHpWhenAttack:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    m_Hp += (int)addValue;
                    Debug.Log($"체력 변화: {m_Hp}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    m_Hp += m_data.char_hp * factor;
                    Debug.Log($"체력 변화: {m_Hp}");
                }
                break;
            case EnSkillEffectType.fire:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                    FixDotDeal += (int)addValue;
                    Debug.Log($"화상뎀 변화: {FixDotDeal}");
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                    float factor = addValue * 0.01f;
                    PercentDotDeal += FixDotDeal * factor;
                    Debug.Log($"화상뎀 변화: {PercentDotDeal}");
                }

                if (FixDotDeal < 0)
                    FixDotDeal = 0;
                if (PercentDotDeal < 0)
                    PercentDotDeal = 0;
                break;
            case EnSkillEffectType.defSheild:
                if (fixPerType == EnSkillFix_PerType.fix)
                {
                }
                else if (fixPerType == EnSkillFix_PerType.percent)
                {
                }
                Debug.Log($"준비되지 않았습니다 DEFSHEILD");
                break;
        }
    }

    public void StartAura(EnSkillEffectType effectType, EnSkillFix_PerType fixPerType, float addValue)
    {
        Debug.Log($"오라 만들어졌셈");
    }

    public void EndAura(EnSkillEffectType effectType, EnSkillFix_PerType fixPerType, float addValue)
    {
        Debug.Log($"오라 꺼졋셈");
    }
}
