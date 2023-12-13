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
    bool isBoss;

    Vector2 direction;

    public void SetData(AttackType attackType, Transform owner, Transform target, float speed, UnityAction action, float damageBuff = 0f, bool isBoss = false)
    {
        Owner = owner;
        m_AttackType = attackType;
        this.speed = speed;
        this.action = action;
        this.target = target;
        this.isBoss = isBoss;
        DamageBuff = damageBuff;
        TotalDamage = m_AttackType.attack_damage + DamageBuff;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") || collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<Monster>().CalculateDamage(m_AttackType.attack_damage);
            Die();
        }
        else if (collision.CompareTag("Wall"))
        {
            Die();
        }
    }

    void Die()
    {
        //파티클을 넣어서 페이드 효과 없이 파괴되도록 조정
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
            //타겟을 상실할 경우 오브젝트 파괴
            Die();
        }

        if (DataManager.Instance.KILLALL)
        {
            Destroy(gameObject);
        }
    }
}
