using System.Collections.Generic;
using UnityEngine;

public class AttackManager : Singleton<AttackManager>
{
    public bool IsAttack = false;
    GameObject bullet;

    public void Fire(AttackType attackType, float damageBuff, Transform startTarget, Transform finishTarget, bool isBoss = false)
    {
        if (bullet == null)
        {
            bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        }

        //추적 원거리 공격
        if (attackType.attack_type == EnAttackType.missile)
        {
            GameObject newBullet = Instantiate(bullet, startTarget.position, startTarget.rotation);
            newBullet.GetComponent<Bullet>().SetData(attackType, startTarget.parent, finishTarget, 10f, null, damageBuff, isBoss);
            newBullet.gameObject.layer = startTarget.gameObject.layer;
        }
        else if (attackType.attack_type == EnAttackType.range)
        {
            GameObject newBullet = Instantiate(bullet, startTarget.position, startTarget.rotation);
            newBullet.GetComponent<Bullet>().SetData(attackType, startTarget.parent, finishTarget, 10f, null, damageBuff, isBoss);
            newBullet.gameObject.layer = startTarget.gameObject.layer;
        }
    }
}