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
    [SerializeField] float speed;
    [SerializeField] float range;

    MonsterData data;
    InstanceController m_Controller;
    TileEventListener m_TileListener;
    public List<Skill> m_SkillList;

    void Update()
    {
        if (!m_Controller.FreezeMonster)
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

        if (data.index == 10006)
            CheckSkill(EnSkillConditionType.time);

        if (DataManager.Instance.KILLALL)
        {
            Destroy(gameObject);
        }
    }

    public void SetData(InstanceController controller, int index)
    {
        m_Controller = controller;
        data = DataManager.Instance.MonsterInfo[index];
        m_Hp = data.monster_hp;
        m_MaxHp = m_Hp;
        spriteRenderer.sprite = Resources.Load<Sprite>($"TempImage/{data.monster_resource}");
        m_isReady = true;

        drop.SetData(controller);
        if (data.attack_idx > 0)
            m_TileListener = AttackManager.Instance.MakeReadyTile(DataManager.Instance.AttackTypeInfo[data.attack_idx], transform, ReadyTiles);

        SetSkills();
    }

    void SetSkills()
    {
        if (DataManager.Instance.SkillInfo.ContainsKey(data.skill_idx))
        {
            Skill skill = new GameObject().AddComponent<Skill>();
            skill.transform.SetParent(SkillList.transform);
            skill.SetData(data.skill_idx, null, this);
            m_SkillList.Add(skill);
        }
    }

    void Movement()
    {
        float distance = Vector3.Distance(m_Controller.FirstCrypture.transform.position, transform.position);

        spriteRenderer.flipX = m_Controller.FirstCrypture.transform.position.x > transform.position.x;

        if (distance <= data.monster_aggression_x * data.monster_aggression_y)
        {
            transform.position = Vector3.Lerp(transform.position, m_Controller.FirstCrypture.transform.position, data.monster_speed * 0.3f * Time.deltaTime);
        }
    }

    public void Die()
    {
        if (m_isDead) return;
        m_isDead = true;

        if (data.index == 10001)
        {
            m_Controller.m_nSpawned10001--;
        }
        else if (data.index == 10002)
        {
            m_Controller.m_nSpawned10002--;
        }
        else if (data.index == 10003)
        {
            m_Controller.m_nSpawned10003--;
        }
        else if (data.index == 10004)
        {
            m_Controller.m_nSpawned10004--;
        }
        else if (data.index == 10005)
        {
            m_Controller.m_nSpawned10005--;
        }
        else if (data.index == 10006)
        {
            m_Controller.m_nSpawned10006--;
        }
        else if (data.index == 10007)
        {
            m_Controller.m_nSpawned10007--;
        }
        else if (data.index == 10008)
        {
            m_Controller.m_nSpawned10008--;
        }
        else if (data.index == 10009)
        {
            m_Controller.m_nSpawned10009--;
            CheckSkill(EnSkillConditionType.die);
        }
        else if (data.index == 13001)
        {
            m_Controller.m_nSpawned13001--;
        }

        hpBar.SetActive(false);
        boxCollider.enabled = false;
        m_Controller.AddScore(data.monster_score);
        m_Controller.CheckCryptureSkill(EnSkillConditionType.finalHit);
        m_Controller.killCount += 1;
        StartCoroutine(Dying());
    }

    void HpRegen()
    {
        //최대 체력 이상으로 리젠 불가능하도록 처리
        if (m_Hp < m_MaxHp)
        {
            m_Hp += data.monster_hp_regen;

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
        float damage = attack_damage - data.monster_def;
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
