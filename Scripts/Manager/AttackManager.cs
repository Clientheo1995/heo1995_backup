using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AttackManager : Singleton<AttackManager>
{
    public static int TILE_SIZE = 1;

    public bool IsAttack = false;
    GameObject checkTile;
    GameObject bullet;
    List<List<GameObject>> ReadyCheckTileList;

    //��� ĳ���͸� ����ٳ����
    public TileEventListener MakeReadyTile(AttackType attackType, Transform owner, Transform destination)
    {
        if (ReadyCheckTileList == null)
            ReadyCheckTileList = new List<List<GameObject>>();

        if (checkTile == null)
        {
            checkTile = Resources.Load<GameObject>("Prefabs/CheckTile");
        }

        for (int i = 0; i < destination.childCount; i++)
        {
            Destroy(destination.GetChild(i).gameObject);
        }

        destination.gameObject.layer = owner.gameObject.layer;
        int tileIndex = attackType.attack_ready_check_idx;
        TileEventListener tl = destination.gameObject.GetComponent<TileEventListener>();
        if (tl == null)
            tl = destination.gameObject.AddComponent<TileEventListener>();
        tl.SetData(owner, true, attackType, destination);

        for (int i = 0; i < DataManager.Instance.AttackReadyCheckTableInfo[tileIndex].row; i++)
        {
            for (int j = 0; j < DataManager.Instance.AttackReadyCheckTableInfo[tileIndex].col; j++)
            {
                int rowGap = i - DataManager.Instance.AttackReadyCheckTableInfo[tileIndex].targetRow;//��
                int colGap = j - DataManager.Instance.AttackReadyCheckTableInfo[tileIndex].targetCol;//��

                Vector3 pos = new Vector3(colGap * TILE_SIZE, rowGap * TILE_SIZE, 0f) + destination.position;//y���� �����Ϳ� �ݴ�� �ؾ� ȭ��� ��ǥ�� ����� ���
                GameObject tile = Instantiate(checkTile, pos, destination.rotation, destination);
                tile.layer = owner.gameObject.layer;
                EnTileType tileType = (EnTileType)DataManager.Instance.AttackReadyCheckTableInfo[tileIndex].tileData[i * DataManager.Instance.AttackReadyCheckTableInfo[tileIndex].col + j];
                tile.GetComponent<CheckTile>().SetData(tl, tileType);
            }
        }

        return tl;
    }

    //��� ĳ���͸� ����ٴϸ� �ȵ�
    public void MakeDamageTile(AttackType attackType, float damageBuff, Transform owner, Transform destination, Quaternion rotation)
    {
        int tileIndex = attackType.attack_damage_check_idx;
        ParticleSystem EffectType1 = checkTile.GetComponentInChildren<ParticleSystem>();
        GameObject newTileGroup = new GameObject("DamageTiles");
        newTileGroup.transform.position = destination.position;
        newTileGroup.transform.rotation = rotation;

        if (owner.gameObject.layer == 6)//Player
            newTileGroup.gameObject.layer = 11;//PlayerTile
        else if (owner.gameObject.layer == 7)//Monster
            newTileGroup.gameObject.layer = 12;//MonsterTile

        TileEventListener tl = newTileGroup.AddComponent<TileEventListener>();
        tl.SetData(owner, false, attackType, destination, EffectType1.main.duration, damageBuff);
        for (int i = 0; i < DataManager.Instance.AttackDamageCheckTableInfo[tileIndex].row; i++)
        {
            for (int j = 0; j < DataManager.Instance.AttackDamageCheckTableInfo[tileIndex].col; j++)
            {
                EnTileType tileType = (EnTileType)DataManager.Instance.AttackDamageCheckTableInfo[tileIndex].tileData[i * DataManager.Instance.AttackDamageCheckTableInfo[tileIndex].col + j];
                if (tileType != EnTileType.damage) continue;
                int rowGap = i - DataManager.Instance.AttackDamageCheckTableInfo[tileIndex].targetRow;//��
                int colGap = j - DataManager.Instance.AttackDamageCheckTableInfo[tileIndex].targetCol;//��

                Vector3 pos = new Vector3(colGap * TILE_SIZE, rowGap * TILE_SIZE, 0f)/* + destination.localPosition*/;//y���� �����Ϳ� �ݴ�� �ؾ� ȭ��� ��ǥ�� ����� ���
                //https://m.blog.naver.com/dj3630/221447943453
                //���ʹϾ� ������ ��ȯ�� �Ǵµ� �̰� �״�� �����ϸ� �ȵǴ°ɱ�
                GameObject tile = Instantiate(checkTile, newTileGroup.transform);//�� ������Ʈ ���� �� ��Ƽ�� ȸ���� �ְ� �� �Ʒ��� Ÿ���� ��ġ�ϱ�
                tile.layer = newTileGroup.gameObject.layer;
                tile.transform.SetLocalPositionAndRotation(pos, newTileGroup.transform.rotation);
                tile.GetComponent<CheckTile>().SetData(tl, tileType);
            }
        }
    }

    public void MakeBullet(AttackType attackType, float damageBuff, Transform startTarget, Transform finishTarget)
    {
        if (bullet == null)
        {
            bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        }

        //���� ���Ÿ� ����
        if (attackType.attack_type == EnAttackType.missile)
        {
            GameObject newBullet = Instantiate(bullet, startTarget.position, startTarget.rotation);
            newBullet.GetComponent<Bullet>().SetData(attackType, startTarget.parent, finishTarget, 10f, null, damageBuff);
            newBullet.gameObject.layer = startTarget.gameObject.layer;
        }
        else if (attackType.attack_type == EnAttackType.range)
        {
            GameObject newBullet = Instantiate(bullet, startTarget.position, startTarget.rotation);
            newBullet.GetComponent<Bullet>().SetData(attackType, startTarget.parent, finishTarget, 10f, null, damageBuff);
            newBullet.gameObject.layer = startTarget.gameObject.layer;
        }
    }
}