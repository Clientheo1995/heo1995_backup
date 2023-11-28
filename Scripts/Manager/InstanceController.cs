using Spine;

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstanceController : MonoBehaviour
{
    #region inspector
    [Header("지스타 스펙용")]
    [Header("10001")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10001;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10001;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10001;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10001;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10001;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10001;

    [Header("10002")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10002;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10002;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10002;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10002;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10002;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10002;

    [Header("10003")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10003;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10003;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10003;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10003;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10003;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10003;

    [Header("10004")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10004;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10004;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10004;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10004;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10004;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10004;

    [Header("10005")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10005;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10005;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10005;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10005;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10005;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10005;

    [Header("10006")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10006;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10006;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10006;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10006;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10006;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10006;

    [Header("10007")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10007;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10007;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10007;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10007;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10007;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10007;

    [Header("10008")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10008;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10008;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10008;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10008;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10008;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10008;

    [Header("10009")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_10009;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_10009;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_10009;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_10009;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_10009;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_10009;

    [Header("13001")]
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최소 개수")]
    [SerializeField] int Spawn_Min_EA_13001;
    [Tooltip("맵에 해당 몬스터가 나올 수 있는 최대 개수")]
    [SerializeField] int Spawn_Max_EA_13001;
    [Tooltip("해당 몬스터가 가지는 스폰 주기")]
    [SerializeField] int Spawn_Time_13001;
    [Tooltip("해당 몬스터의 스폰 확률")]
    [SerializeField] int Spawn_Per_13001;
    [Tooltip("스폰 방지 범위 x축")]
    [SerializeField] int Spawn_Prevention_X_13001;
    [Tooltip("스폰 방지 범위 y축")]
    [SerializeField] int Spawn_Prevention_Y_13001;
    #endregion
    [SerializeField] public Crypture FirstCrypture;
    //[SerializeField] List<int> CryptureIndexList = new List<int>() { 10, 11, 12 };
    [SerializeField] GameObject GameOverPopup;
    [SerializeField] Text ScoreText;
    [SerializeField] Text GOScore;
    [SerializeField] GameObject StageSelect;
    [SerializeField] CanvasController canvas;
    [SerializeField] int mapIndex;

    public float m_fScore;
    public List<Crypture> CryptureList;
    public List<Monster> MonsterList;
    public Vector2 Direction;
    public float FollowSpeed;

    Coroutine m_coroutine;
    GameObject m_Crypture;
    GameObject m_Monster;

    [SerializeField] List<GameObject> Maps;
    List<Vector3> SpawnPoints;
    GameObject Map;

    public bool FreezeMonster = false;
    bool m_bIsSpawn10001 = false;
    bool m_bIsSpawn10002 = false;
    bool m_bIsSpawn10003 = false;
    bool m_bIsSpawn10004 = false;
    bool m_bIsSpawn10005 = false;
    bool m_bIsSpawn10006 = false;
    bool m_bIsSpawn10007 = false;
    bool m_bIsSpawn10008 = false;
    bool m_bIsSpawn10009 = false;
    bool m_bIsSpawn13001 = false;
    float m_fCurTime10001;
    float m_fCurTime10002;
    float m_fCurTime10003;
    float m_fCurTime10004;
    float m_fCurTime10005;
    float m_fCurTime10006;
    float m_fCurTime10007;
    float m_fCurTime10008;
    float m_fCurTime10009;
    float m_fCurTime13001;
    public int m_nSpawned10001;
    public int m_nSpawned10002;
    public int m_nSpawned10003;
    public int m_nSpawned10004;
    public int m_nSpawned10005;
    public int m_nSpawned10006;
    public int m_nSpawned10007;
    public int m_nSpawned10008;
    public int m_nSpawned10009;
    public int m_nSpawned13001;

    bool isBoss;
    int goNextStageCut;
    public int killCount;
    public int KillCombo;
    public bool isFirstGameOver = true;

    void Start()
    {
        //m_Crypture = Resources.Load<GameObject>("Prefabs/Crypture");
        m_Monster = Resources.Load<GameObject>("Prefabs/Monster");
        //FirstCrypture = GameObject.FindWithTag("Player")?.GetComponent<Crypture>();
        //StartCoroutine(WaitForData());
    }

    void Update()
    {
        //if (!m_bIsSpawn)
        //{
        //    m_fCurTime += Time.deltaTime;

        //    if (m_fCurTime > Spawn_Time)
        //    {
        //        m_fCurTime = 0;
        //        m_bIsSpawn = true;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Clear();
        }

        if (DataManager.Instance.GameStart)
        {
            if (killCount >= goNextStageCut)
            {
                Clear();
            }

            if (!m_bIsSpawn10001)
            {
                m_fCurTime10001 += Time.deltaTime;

                if (m_fCurTime10001 > Spawn_Time_10001)
                {
                    m_fCurTime10001 = 0;
                    m_bIsSpawn10001 = true;
                }
            }

            if (!m_bIsSpawn10002)
            {
                m_fCurTime10002 += Time.deltaTime;

                if (m_fCurTime10002 > Spawn_Time_10002)
                {
                    m_fCurTime10002 = 0;
                    m_bIsSpawn10002 = true;
                }
            }

            if (!m_bIsSpawn10003)
            {
                m_fCurTime10003 += Time.deltaTime;

                if (m_fCurTime10003 > Spawn_Time_10003)
                {
                    m_fCurTime10003 = 0;
                    m_bIsSpawn10003 = true;
                }
            }

            if (!m_bIsSpawn10004)
            {
                m_fCurTime10004 += Time.deltaTime;

                if (m_fCurTime10004 > Spawn_Time_10004)
                {
                    m_fCurTime10004 = 0;
                    m_bIsSpawn10004 = true;
                }
            }

            if (!m_bIsSpawn10005)
            {
                m_fCurTime10005 += Time.deltaTime;

                if (m_fCurTime10005 > Spawn_Time_10005)
                {
                    m_fCurTime10005 = 0;
                    m_bIsSpawn10005 = true;
                }
            }

            if (!m_bIsSpawn10006)
            {
                m_fCurTime10006 += Time.deltaTime;

                if (m_fCurTime10006 > Spawn_Time_10006)
                {
                    m_fCurTime10006 = 0;
                    m_bIsSpawn10006 = true;
                }
            }

            if (!m_bIsSpawn10007)
            {
                m_fCurTime10007 += Time.deltaTime;

                if (m_fCurTime10007 > Spawn_Time_10007)
                {
                    m_fCurTime10007 = 0;
                    m_bIsSpawn10007 = true;
                }
            }

            if (!m_bIsSpawn10008)
            {
                m_fCurTime10008 += Time.deltaTime;

                if (m_fCurTime10008 > Spawn_Time_10008)
                {
                    m_fCurTime10008 = 0;
                    m_bIsSpawn10008 = true;
                }
            }

            if (!m_bIsSpawn10009)
            {
                m_fCurTime10009 += Time.deltaTime;

                if (m_fCurTime10009 > Spawn_Time_10009)
                {
                    m_fCurTime10009 = 0;
                    m_bIsSpawn10009 = true;
                }
            }

            if (!m_bIsSpawn13001)
            {
                m_fCurTime13001 += Time.deltaTime;

                if (m_fCurTime13001 > Spawn_Time_13001)
                {
                    m_fCurTime13001 = 0;
                    m_bIsSpawn13001 = true;
                }
            }

            //if (!isBoss)
            MonsterSpawnRule();
        }
    }

    IEnumerator WaitForData()
    {
        yield return DataManager.Instance.DATALOADCOMPLETE;
        yield return DataManager.Instance.GameStart;
        GameInitialize();
    }
    
    public void GameInitialize()
    {
        //if (CryptureList == null)
        //    CryptureList = new List<Crypture>();
        //else if (CryptureList != null)
        //    CryptureList.Clear();
        m_fScore = 0f;
        if (MonsterList == null)
            MonsterList = new List<Monster>();
        else if (MonsterList != null)
            MonsterList.Clear();
        FirstCrypture.gameObject.SetActive(true);
        FirstCrypture.transform.position = Vector3.zero;
        //FirstCrypture.SetData(this, CryptureIndexList[0], null);
        FirstCrypture.SetData(this, DataManager.Instance.TempRoster[0].data.index, DataManager.Instance.TempRoster[0].parts, DataManager.Instance.TempRoster[0].color, null);
        CryptureList.Add(FirstCrypture);
        FollowSpeed = FirstCrypture.m_Speed * 3;

        Map = Maps[mapIndex];
        for (int i = 0; i < Maps.Count; i++)
        {
            Maps[i].SetActive(mapIndex == i);
        }

        m_nSpawned10001 = 0;
        m_nSpawned10002 = 0;
        m_nSpawned10003 = 0;
        m_nSpawned10004 = 0;
        m_nSpawned10005 = 0;
        m_nSpawned10006 = 0;
        m_nSpawned10007 = 0;
        m_nSpawned10008 = 0;
        m_nSpawned10009 = 0;
        m_nSpawned13001 = 0;

        //for (int i = 1; i < CryptureIndexList.Count; i++)
        //{
        //    AddCrypture(CryptureIndexList[i]);
        //}

        //for (int i = 1; i < DataManager.Instance.startmembers.Count; i++)
        //{
        //    AddCrypture(DataManager.Instance.startmembers[i]);
        //}
    }


    //void AddCrypture(int index)
    //{
    //    Crypture newCrypture = Instantiate(m_Crypture, transform).GetComponent<Crypture>();
    //    newCrypture.GetComponent<Crypture>().SetData(this, index, CryptureList[CryptureList.Count - 1].transform);
    //    CryptureList.Add(newCrypture);
    //}

    //public void ExceptCrypture(Transform excepted)
    //{
    //    for (int i = 1; i < CryptureList.Count; i++)
    //    {
    //        if (CryptureList[i] == excepted)
    //        {
    //            if (i < CryptureList.Count - 1)
    //                CryptureList[i + 1].SetHead(CryptureList[i - 1].transform);
    //            CryptureList.Remove(excepted.GetComponent<Crypture>());
    //        }
    //    }
    //}

    void AddMonster(int index)
    {
        Monster newMonster = Instantiate(m_Monster, SetSpawnPoint(), Quaternion.identity, transform).GetComponent<Monster>();
        newMonster.SetData(this, index);
        MonsterList.Add(newMonster);
    }

    public void AddScore(int monster_score)
    {
        m_fScore += monster_score;
        ScoreText.text = $"Score: {m_fScore}";
        GOScore.text = $"Score: {m_fScore}";
    }

    Vector3 SetSpawnPoint()
    {
        if (SpawnPoints == null)
        {
            SpawnPoints = new List<Vector3>();
        }
        else
        {
            SpawnPoints.Clear();
        }

        Transform spawnPoints = Map.transform.Find("SpawnPoint");
        return spawnPoints.GetChild(UnityEngine.Random.Range(0, spawnPoints.childCount)).position;
    }

    void MonsterSpawnRule()//몬스터 스폰 규칙
    {
        //if (MonsterList.Count < Spawn_Max_EA)
        //{
        //    if (m_bIsSpawn)
        //    {
        //        m_bIsSpawn = false;
        //        int spawnRate = Random.Range(1, 100);
        //        if (spawnRate < Spawn_Per)
        //        {
        //        }
        //    }
        //}

        if (m_nSpawned10001 < Spawn_Max_EA_10001)
        {
            if (m_bIsSpawn10001)
            {
                m_bIsSpawn10001 = false;
                if (m_nSpawned10001 < Spawn_Min_EA_10001)
                {
                    AddMonster(10001);
                    ++m_nSpawned10001;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10001)
                    {
                        AddMonster(10001);
                        ++m_nSpawned10001;
                    }
                }
            }
        }

        if (m_nSpawned10002 < Spawn_Max_EA_10002)
        {
            if (m_bIsSpawn10002)
            {
                m_bIsSpawn10002 = false;
                if (m_nSpawned10002 < Spawn_Min_EA_10002)
                {
                    AddMonster(10002);
                    ++m_nSpawned10002;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10002)
                    {
                        AddMonster(10002);
                        ++m_nSpawned10002;
                    }
                }
            }
        }

        if (m_nSpawned10003 < Spawn_Max_EA_10003)
        {
            if (m_bIsSpawn10003)
            {
                m_bIsSpawn10003 = false;
                if (m_nSpawned10003 < Spawn_Min_EA_10003)
                {
                    AddMonster(10003);
                    ++m_nSpawned10003;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10003)
                    {
                        AddMonster(10003);
                        ++m_nSpawned10003;
                    }
                }
            }
        }

        if (m_nSpawned10004 < Spawn_Max_EA_10004)
        {
            if (m_bIsSpawn10004)
            {
                m_bIsSpawn10004 = false;
                if (m_nSpawned10004 < Spawn_Min_EA_10004)
                {
                    AddMonster(10004);
                    ++m_nSpawned10004;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10004)
                    {
                        AddMonster(10004);
                        ++m_nSpawned10004;
                    }
                }
            }
        }

        if (m_nSpawned10005 < Spawn_Max_EA_10005)
        {
            if (m_bIsSpawn10005)
            {
                m_bIsSpawn10005 = false;
                if (m_nSpawned10005 < Spawn_Min_EA_10005)
                {
                    AddMonster(10005);
                    ++m_nSpawned10005;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10005)
                    {
                        AddMonster(10005);
                        ++m_nSpawned10005;
                    }
                }
            }
        }

        if (m_nSpawned10006 < Spawn_Max_EA_10006)
        {
            if (m_bIsSpawn10006)
            {
                m_bIsSpawn10006 = false;
                if (m_nSpawned10006 < Spawn_Min_EA_10006)
                {
                    AddMonster(10006);
                    ++m_nSpawned10006;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10006)
                    {
                        AddMonster(10006);
                        ++m_nSpawned10006;
                    }
                }
            }
        }

        if (m_nSpawned10007 < Spawn_Max_EA_10007)
        {
            if (m_bIsSpawn10007)
            {
                m_bIsSpawn10007 = false;
                if (m_nSpawned10007 < Spawn_Min_EA_10007)
                {
                    AddMonster(10007);
                    ++m_nSpawned10007;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10007)
                    {
                        AddMonster(10007);
                        ++m_nSpawned10007;
                    }
                }
            }
        }

        if (m_nSpawned10008 < Spawn_Max_EA_10008)
        {
            if (m_bIsSpawn10008)
            {
                m_bIsSpawn10008 = false;
                if (m_nSpawned10008 < Spawn_Min_EA_10008)
                {
                    AddMonster(10008);
                    ++m_nSpawned10008;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10008)
                    {
                        AddMonster(10008);
                        ++m_nSpawned10008;
                    }
                }
            }
        }

        if (m_nSpawned10009 < Spawn_Max_EA_10009)
        {
            if (m_bIsSpawn10009)
            {
                m_bIsSpawn10009 = false;
                if (m_nSpawned10009 < Spawn_Min_EA_10009)
                {
                    AddMonster(10009);
                    ++m_nSpawned10009;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_10009)
                    {
                        AddMonster(10009);
                        ++m_nSpawned10009;
                    }
                }
            }
        }

        if (m_nSpawned13001 < Spawn_Max_EA_13001)
        {
            if (m_bIsSpawn13001)
            {
                m_bIsSpawn13001 = false;
                if (m_nSpawned13001 < Spawn_Min_EA_13001)
                {
                    AddMonster(13001);
                    ++m_nSpawned13001;
                }
                else
                {
                    int spawnRate = UnityEngine.Random.Range(1, 100);
                    if (spawnRate < Spawn_Per_13001)
                    {
                        AddMonster(13001);
                        ++m_nSpawned13001;
                    }
                }
            }
        }
    }

    struct AvoidRect
    {
        public float minX, minY, maxX, maxY;
    }

    void AvoidField(int index)
    {
        //Vector3 newPos = new Vector3(UnityEngine.Random.Range(minX, minY), UnityEngine.Random.Range(maxX, maxY), 0f);
        AvoidRect ar = new AvoidRect();
        float x = 0f, y = 0f;

        for (int i = 0; i < MonsterList.Count; i++)
        {
            switch (index)
            {
                case 10001:
                    x = Spawn_Prevention_X_10001 * 0.5f;
                    y = Spawn_Prevention_Y_10001 * 0.5f;
                    break;
                case 10002:
                    x = Spawn_Prevention_X_10002 * 0.5f;
                    y = Spawn_Prevention_Y_10002 * 0.5f;
                    break;
                case 10003:
                    x = Spawn_Prevention_X_10003 * 0.5f;
                    y = Spawn_Prevention_Y_10003 * 0.5f;
                    break;
                case 10004:
                    x = Spawn_Prevention_X_10004 * 0.5f;
                    y = Spawn_Prevention_Y_10004 * 0.5f;
                    break;
                case 10005:
                    x = Spawn_Prevention_X_10005 * 0.5f;
                    y = Spawn_Prevention_Y_10005 * 0.5f;
                    break;
                case 10006:
                    x = Spawn_Prevention_X_10006 * 0.5f;
                    y = Spawn_Prevention_Y_10006 * 0.5f;
                    break;
                case 10007:
                    x = Spawn_Prevention_X_10007 * 0.5f;
                    y = Spawn_Prevention_Y_10007 * 0.5f;
                    break;
                case 10008:
                    x = Spawn_Prevention_X_10008 * 0.5f;
                    y = Spawn_Prevention_Y_10008 * 0.5f;
                    break;
                case 10009:
                    x = Spawn_Prevention_X_10009 * 0.5f;
                    y = Spawn_Prevention_Y_10009 * 0.5f;
                    break;
                case 13001:
                    x = Spawn_Prevention_X_13001 * 0.5f;
                    y = Spawn_Prevention_Y_13001 * 0.5f;
                    break;
            }
            ar.minX = MonsterList[i].transform.position.x - x;
            ar.minY = MonsterList[i].transform.position.y - y;
            ar.maxX = MonsterList[i].transform.position.x + x;
            ar.maxY = MonsterList[i].transform.position.x + y;
        }
    }

    public void DamageCalculate(Transform target, float damage)
    {
        target.GetComponent<Unit>().Damaged(damage);
    }

    void Clear()
    {
        DataManager.Instance.GameStart = false;
        canvas.OnPanel(EnUIPanel.GameClear);
        DataManager.Instance.KILLALL = true;
        FirstCrypture.transform.position = Vector3.zero;
    }

    public void Restart()
    {
        GameInitialize();
    }

    public void GameOver()
    {
        canvas.OnPanel(EnUIPanel.GameOver);
    }

    public void CheckCryptureSkill(EnSkillConditionType condition)
    {
        FirstCrypture.CheckSkill(condition);
    }

    public void Freeze(bool v)
    {
        FreezeMonster = v;
    }

    public void OpenStageSelect()
    {
        StageSelect.SetActive(true);
    }

    public void SetStageData(int stageIndex, MapNode node, bool isBoss)
    {
        this.isBoss = isBoss;
        KillCombo = 0;
        killCount = 0;
        DataManager.Instance.ThisStage = DataManager.Instance.StageInfo[stageIndex];
        goNextStageCut = DataManager.Instance.RecentLayer * DataManager.Instance.ThisStage.monster_stair_clear_plus + DataManager.Instance.ThisStage.monster_first_stair_clear_ea;

        DataManager.Instance.ThisNode = node;
        DataManager.Instance.RecentLayer += 1;
        DataManager.Instance.KILLALL = false;
    }
}
