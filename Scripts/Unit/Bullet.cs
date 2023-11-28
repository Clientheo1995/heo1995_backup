using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float TotalDamage;
    public float DamageBuff;
    public float speed;
    UnityAction action;
    Transform target;
    Transform Owner;
    AttackType m_AttackType;
    [SerializeField] SpriteRenderer spriteRenderer;
    float m_fCurTime;
    bool isFollow;

    Vector2 direction;

    public void SetData(AttackType attackType, Transform owner, Transform target, float speed, UnityAction action, float damageBuff = 0f)
    {
        Owner = owner;
        m_AttackType = attackType;
        this.speed = speed;
        this.action = action;
        this.target = target;
        DamageBuff = damageBuff;
        TotalDamage = m_AttackType.attack_damage + DamageBuff;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            if (m_AttackType.attack_type == EnAttackType.missile)
            {
                AttackManager.Instance.MakeDamageTile(m_AttackType, DamageBuff, Owner, target, transform.rotation);
            }
            else
            {
                collision.transform.GetComponent<Monster>().CalculateDamage(m_AttackType.attack_damage);
            }

            Die();
        }
        else if (collision.CompareTag("Wall"))
        {
            Die();
        }
    }

    void Die()
    {
        //��ƼŬ�� �־ ���̵� ȿ�� ���� �ı��ǵ��� ����
        Destroy(gameObject);
    }

    void Update()
    {
        m_fCurTime += Time.deltaTime;
        if (m_fCurTime > 0f)
        {
            m_fCurTime = 0f;
        }

        //https://ssabi.tistory.com/23
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //Ÿ���� ����� ��� ������Ʈ �ı�
            Die();
        }

        if (DataManager.Instance.KILLALL)
        {
            Destroy(gameObject);
        }
    }
}
