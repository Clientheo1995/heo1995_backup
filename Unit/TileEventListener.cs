using System.Collections;

using UnityEngine;

public class TileEventListener : MonoBehaviour
{
    public float Damage;
    public float DamageBuff;

    InstanceController m_Controller;
    AttackType m_AttackType;
    Transform DrawTarget;
    Transform Owner;
    AudioSource SFX;

    bool m_bCanAttack = true;
    bool m_bIsReadyTile = false;
    bool m_bIsAttacked = false;

    float m_fCurTime;
    float m_delay;
    bool m_bIsBoss;

    public void SetData(Transform owner, bool isReadyTile, AttackType attackType, Transform drawTarget, float damageBuff = 0f, float delay = 0f, bool isBoss = false)
    {
        Owner = owner;
        m_AttackType = attackType;
        m_bIsReadyTile = isReadyTile;
        DrawTarget = drawTarget;
        m_delay = delay;
        DamageBuff = damageBuff;
        m_bIsBoss = isBoss;
        Damage = m_AttackType.attack_damage;

        SFX = transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!m_bCanAttack && m_bIsReadyTile)
        {
            m_fCurTime += Time.deltaTime;
        }

        if (m_fCurTime > m_AttackType?.attack_cooltime)
        {
            m_fCurTime = 0;
            m_bCanAttack = true;
        }

        if (DataManager.Instance.KILLALL)
        {
            if (Owner != null)
            {
                if (Owner.name != "first")
                    Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void CallEvent(Collider2D collision)
    {
        if (!m_bCanAttack)
            return;

        if (m_bIsReadyTile)
        {
            if (m_bCanAttack)
            {
                if (m_AttackType.attack_type == EnAttackType.range || m_AttackType.attack_type == EnAttackType.missile)
                {
                    AttackManager.Instance.MakeBullet(m_AttackType, DamageBuff, DrawTarget, collision.transform, m_bIsBoss);
                    m_bCanAttack = false;
                }
                else
                {
                    if (Owner.name.CompareTo("first") == 0)
                    {
                        SFX.Stop();
                        SFX.clip = Resources.Load<AudioClip>("Sound/attack_melee2");
                        SFX.Play();
                    }
                    
                    AttackManager.Instance.MakeDamageTile(m_AttackType, DamageBuff, Owner, DrawTarget, transform.rotation, m_bIsBoss);//그 자리에 생성, 공격자(타일의 부모)의 회전값을 넘겨줌
                    m_bCanAttack = false;
                }
            }
        }
        else
        {
            if (!m_bIsAttacked)
            {
                if (collision.CompareTag("Monster"))
                {
                    m_bIsAttacked = true;
                    Crypture crypture = Owner.GetComponent<Crypture>();
                    collision.transform.GetComponent<Monster>().CalculateDamage(Damage + DamageBuff);
                    crypture.CheckSkill(EnSkillConditionType.attack);
                    Destroy(gameObject);
                }
                if (collision.CompareTag("Player"))
                {
                    Owner.GetComponent<Monster>()?.CheckSkill(EnSkillConditionType.attack);
                    collision.transform.GetComponent<Crypture>().CalculateDamage(Damage + DamageBuff);
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator Dying()
    {
        yield return new WaitForSeconds(m_delay);
        Destroy(gameObject);
    }
}
