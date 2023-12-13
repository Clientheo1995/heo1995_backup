using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Monster : MonoBehaviour
{
    bool m_isReady;
    float m_fCurTime;
    float m_Hp;
    float m_MaxHp;
    bool m_isDead = false;

    [SerializeField] GameObject hpBar;
    [SerializeField] Drop drop;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject SkillList;
    [SerializeField] public Transform ReadyTiles;

    MonsterData m_data;
    public MonsterData Data { get { return m_data; } }

    InstanceController m_Controller;
    TileEventListener m_TileListener;
    public List<Skill> m_SkillList;

    void Update()
    {
        //if (!m_Controller.FreezeMonster)
        {
            if (m_isReady)
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

        if (m_data.index == 10006)
            CheckSkill(EnSkillConditionType.time);

        if (DataManager.Instance.KILLALL)
        {
            Destroy(gameObject);
        }
    }

    public void SetData(InstanceController controller, int index)
    {
        m_Controller = controller;
        m_data = DataManager.Instance.MonsterInfo[index];
        if (index == 13001)
            hpBar.transform.localPosition = new Vector3(0, 3f, 0);
        m_Hp = Data.monster_hp;
        m_MaxHp = m_Hp;
        spriteRenderer.sprite = Resources.Load<Sprite>($"TempImage/{Data.monster_resource}");
        m_isReady = true;

        transform.localScale = new Vector3(Data.monster_size_x, Data.monster_size_y);
        drop.SetData(controller);
        if (Data.attack_idx > 0)
            m_TileListener = AttackManager.Instance.MakeReadyTile(DataManager.Instance.AttackTypeInfo[Data.attack_idx], transform, ReadyTiles, Data.monster_type == EnMonsterType.boss);

        SetSkills();
    }

    void SetSkills()
    {
        if (DataManager.Instance.SkillInfo.ContainsKey(Data.skill_idx))
        {
            Skill skill = new GameObject().AddComponent<Skill>();
            skill.transform.SetParent(SkillList.transform);
            skill.SetData(Data.skill_idx, null, this);
            m_SkillList.Add(skill);
        }
    }

    void Movement()
    {
        float distance = Vector3.Distance(m_Controller.FirstCrypture.transform.position, transform.position);

        spriteRenderer.flipX = m_Controller.FirstCrypture.transform.position.x > transform.position.x;

        if (distance <= Data.monster_aggression_x * Data.monster_aggression_y)
        {
            transform.position = Vector3.Lerp(transform.position, m_Controller.FirstCrypture.transform.position, Data.monster_speed * 0.3f * Time.deltaTime);
        }
    }

    void FollowUp()
    {
        //if (m_Controller.Direction.x < 0 && spine.skeleton.ScaleX < 0)
        //{
        //    spine.skeleton.ScaleX *= -1;
        //}
        //else if (m_Controller.Direction.x > 0 && spine.skeleton.ScaleX > 0)
        //{
        //    spine.skeleton.ScaleX *= -1;
        //}

        //m_fDistance = Vector3.Distance(HeadObject.localPosition, transform.localPosition);

        //float T = Time.deltaTime * m_fDistance / DataManager.MinDistance * m_Controller.FollowSpeed;

        //if (T > 0.1f)
        //    T = 0.1f;

        //transform.localPosition = Vector3.Slerp(transform.localPosition, HeadObject.localPosition, T);
        //ReadyTiles.rotation = Quaternion.Slerp(ReadyTiles.localRotation, HeadArrow.localRotation, T);
        //if (AttackArrow != null)
        //    AttackArrow.localRotation = Quaternion.Slerp(AttackArrow.localRotation, HeadArrow.localRotation, T);
    }

    public void Die()
    {
        if (m_isDead) return;
        m_isDead = true;
        hpBar.SetActive(false);
        boxCollider.enabled = false;
        m_Controller.AddScore(Data.monster_score);
        m_Controller.CheckCryptureSkill(EnSkillConditionType.finalHit);
        EventManager.OnEventMonsterDie();
        StartCoroutine(Dying());
    }

    void HpRegen()
    {
        //최대 체력 이상으로 리젠 불가능하도록 처리
        if (m_Hp < m_MaxHp)
        {
            m_Hp += Data.monster_hp_regen;

            if (m_Hp > m_MaxHp)
                m_Hp = m_MaxHp;

            UpdateHpBar();
        }
    }

    void UpdateHpBar()
    {
        hpBar.transform.localScale = new Vector2(m_Hp / m_MaxHp, 1);
    }

    public void CalculateDamage(float attack_damage)
    {
        float damage = attack_damage - Data.monster_def;
        if (damage <= 0)
            damage = 1;

        m_Hp -= damage;

        if (m_Hp <= 0) Die();
        else UpdateHpBar();

        Debug.Log($"Monster Attacked Hp: {m_Hp}");
    }

    IEnumerator Dying()//fade out
    {
        while (spriteRenderer.color.a > 0)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, spriteRenderer.color.a - Time.deltaTime);
            yield return null;
        }

        if (drop != null)
        {
            drop.gameObject.SetActive(drop.m_dropType != EnDropType.None);
            drop.transform.SetParent(transform.parent);
            drop = null;
        }
        Destroy(gameObject);
    }

    public void CheckSkill(EnSkillConditionType skillCondition)
    {
        for (int i = 0; i < m_SkillList.Count; i++)
        {
            m_SkillList[i].CheckCondition(skillCondition);
        }
    }
}
