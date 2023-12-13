using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using static EventManager;

public class InstanceController : MonoBehaviour
{
    [SerializeField] public Crypture FirstCrypture;
    [SerializeField] Text ScoreText;
    [SerializeField] Text GOScore;
    [SerializeField] GameObject stageSelect;
    [SerializeField] int mapIndex;

    float m_fScore;
    List<Crypture> CryptureList;
    List<Monster> MonsterList;
    Vector2 Direction;
    float FollowSpeed;

    GameObject m_Monster;

    [SerializeField] List<GameObject> Maps;
    List<Vector3> SpawnPoints;
    GameObject Map;

    bool isBoss;
    bool isFirstGameOver = true;
    int goNextStageCut;
    int killCount;
    int killCombo;
    
    List<SkillData> RestSkillList;

    void Awake()
    {
        EventManager.Instance.EInitialize += GameInitialize;
        EventManager.Instance.EStageRestEffect += StageRest;
        EventManager.Instance.EFirstGameOver += CheckFIrstGameOver;
        EventManager.Instance.EResetGameOverStack += ResetGameOverStack;
        EventManager.Instance.EInstanceValueReset += ValueReset;
        EventManager.Instance.EMonsterDie += MonsterDie;
    }

    void ValueReset()
    {
        m_fScore = 0f;
        killCount = 0;
        killCombo = 0;
        isFirstGameOver = true;
        isBoss = false;
        goNextStageCut = 0;
    }

    public void GameInitialize()
    {
        
        if (MonsterList == null)
            MonsterList = new List<Monster>();
        else if (MonsterList != null)
            MonsterList.Clear();

        FirstCrypture.gameObject.SetActive(true);
        FirstCrypture.transform.position = Vector3.zero;
        FirstCrypture.SetData(this, DataManager.Instance.User.RosterCryptures[0], null);
        CryptureList.Add(FirstCrypture);
        FollowSpeed = FirstCrypture.m_Speed * 3;//임시

        if (DataManager.Instance.RecentLayer == DataManager.Instance.Layers.Count - 1)
            mapIndex = Maps.Count - 1;
        else
            mapIndex = UnityEngine.Random.Range(0, Maps.Count - 1);
        Map = Maps[mapIndex];
        for (int i = 0; i < Maps.Count; i++)
        {
            Maps[i].SetActive(mapIndex == i);
        }
    }

    void StageRest(int index)
    {
        switch (index)
        {
            case 0://낮잠 최대체력의 20퍼마큼 모든 크립쳐 회복
                FirstCrypture.m_Hp += FirstCrypture.m_MaxHp * 0.2f;
                SoundManager.Instance.SetSound(AudioChannel.UI, "heal");
                EventManager.Instance.OnEventOnRestPanel(EnRestPanelOrder.Length);
                break;
            case 1://드르러엉
                {
                    int result = UnityEngine.Random.Range(0, 2);
                    SoundManager.Instance.SetSound(AudioChannel.UI, "heal");

                    if (result == 0)//50퍼확률로 최대체력의40퍼만큼 모든크립쳐 회복
                    {
                        FirstCrypture.m_Hp += FirstCrypture.m_MaxHp * 0.4f;
                        EventManager.Instance.OnEventOnRestPanel(EnRestPanelOrder.Length);
                    }
                    else// 50퍼확률로 최대체력의 10퍼만큼 회복 + 일반전투 진입
                    {
                        FirstCrypture.m_Hp += FirstCrypture.m_MaxHp * 0.1f;
                        EventManager.Instance.OnEventOnPanel(EnUIPanel.Instance);
                    }
                }
                break;
            case 2://주변탐색 50퍼확률로 최대 체력 10퍼만큼 모든크립처 회복 or 50퍼확률로 스킬 획득 실패 최대체력 10퍼만큼 모든 크립처 회복
                {
                    //스킬 획득
                    int result = UnityEngine.Random.Range(0, 2);
                    if (result == 0)
                    {
                        FirstCrypture.m_Hp += FirstCrypture.m_MaxHp * 0.1f;
                        DataManager.Instance.RestSkillList.Clear();

                        while (DataManager.Instance.RestSkillList.Count < 3)
                        {
                            int skillIndex = UnityEngine.Random.Range(1, 9);
                            if (DataManager.Instance.RestSkillList.Contains(DataManager.Instance.SkillInfo[skillIndex + 3000]))
                                continue;
                            DataManager.Instance.RestSkillList.Add(DataManager.Instance.SkillInfo[skillIndex + 3000]);
                        }

                        SoundManager.Instance.SetSound(AudioChannel.UI, "DM-CGS-45");
                        EventManager.Instance.OnEventOnRestPanel(EnRestPanelOrder.restSelect);
                    }
                    else
                    {
                        FirstCrypture.m_Hp += FirstCrypture.m_MaxHp * 0.05f;
                        SoundManager.Instance.SetSound(AudioChannel.UI, "DM-CGS-02");
                        //미획득
                        EventManager.Instance.OnEventOnRestPanel(EnRestPanelOrder.Length);
                    }
                }
                break;
        }
    }

    void ResetGameOverStack()
    {
        isFirstGameOver = true;
    }

    void CheckFIrstGameOver()
    {
        isFirstGameOver = false;
    }

    void MonsterDie()
    {
        killCount += 1;
    }

    void OnDestroy()
    {
        EventManager.Instance.EInitialize -= GameInitialize;
        EventManager.Instance.EStageRestEffect -= StageRest;
        EventManager.Instance.EFirstGameOver -= CheckFIrstGameOver;
        EventManager.Instance.EResetGameOverStack -= ResetGameOverStack;
        EventManager.Instance.EInstanceValueReset -= ValueReset;
        EventManager.Instance.EMonsterDie -= MonsterDie;
    }

    void Start()
    {
        m_Monster = Resources.Load<GameObject>("Prefabs/Monster");
    }

    IEnumerator SpawnEnemies()
    {
        yield return null;
        //if (!m_bIsSpawn)
        //{
        //    m_fCurTime += Time.deltaTime;

        //    if (m_fCurTime > Spawn_Time)
        //    {
        //        m_fCurTime = 0;
        //        m_bIsSpawn = true;
        //    }
        //}
    }
    void Update()
    {
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

            //if (!m_bIsSpawn10001)
            //{
            //    m_fCurTime10001 += Time.deltaTime;

            //    if (m_fCurTime10001 > Spawn_Time_10001)
            //    {
            //        m_fCurTime10001 = 0;
            //        m_bIsSpawn10001 = true;
            //    }
            //}
            MonsterSpawnRule();
        }
    }

    IEnumerator WaitForData()
    {
        yield return DataManager.Instance.DATALOADCOMPLETE;
        yield return DataManager.Instance.GameStart;
        GameInitialize();
    }

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

        //    if (m_nSpawned10001 < Spawn_Max_EA_10001)
        //    {
        //        if (m_bIsSpawn10001)
        //        {
        //            m_bIsSpawn10001 = false;
        //            if (m_nSpawned10001 < Spawn_Min_EA_10001)
        //            {
        //                AddMonster(10001);
        //                ++m_nSpawned10001;
        //            }
        //            else
        //            {
        //                int spawnRate = UnityEngine.Random.Range(1, 100);
        //                if (spawnRate < Spawn_Per_10001)
        //                {
        //                    AddMonster(10001);
        //                    ++m_nSpawned10001;
        //                }
        //            }
        //        }
        //    }


        //if (isBoss)
        //    if (m_nSpawned13001 <= Spawn_Max_EA_13001)
        //    {
        //        if (m_bIsSpawn13001)
        //        {
        //            m_bIsSpawn13001 = false;
        //            if (m_nSpawned13001 < Spawn_Min_EA_13001)
        //            {
        //                AddMonster(13001);
        //                ++m_nSpawned13001;
        //            }
        //            else
        //            {
        //                int spawnRate = UnityEngine.Random.Range(1, 100);
        //                if (spawnRate < Spawn_Per_13001)
        //                {
        //                    AddMonster(13001);
        //                    ++m_nSpawned13001;
        //                }
        //            }
        //        }
        //    }
    }

    //struct AvoidRect
    //{
    //    public float minX, minY, maxX, maxY;
    //}

    //void AvoidField(int index)
    //{
    //    //Vector3 newPos = new Vector3(UnityEngine.Random.Range(minX, minY), UnityEngine.Random.Range(maxX, maxY), 0f);
    //    AvoidRect ar = new AvoidRect();
    //    float x = 0f, y = 0f;

    //    for (int i = 0; i < MonsterList.Count; i++)
    //    {
    //        switch (index)
    //        {
    //            case 10001:
    //                x = Spawn_Prevention_X_10001 * 0.5f;
    //                y = Spawn_Prevention_Y_10001 * 0.5f;
    //                break;
    //        }
    //        ar.minX = MonsterList[i].transform.position.x - x;
    //        ar.minY = MonsterList[i].transform.position.y - y;
    //        ar.maxX = MonsterList[i].transform.position.x + x;
    //        ar.maxY = MonsterList[i].transform.position.x + y;
    //    }
    //}

    void Clear()
    {
        isBoss = false;
        DataManager.Instance.GameStart = false;
        EventManager.Instance.OnEventOnPanel(EnUIPanel.GameClear);
        DataManager.Instance.KILLALL = true;
        FirstCrypture.transform.position = Vector3.zero;
    }

    public void Restart()
    {
        GameInitialize();
    }

    public void GameOver()
    {
        EventManager.Instance.OnEventOnPanel(EnUIPanel.GameOver);
    }

    public void CheckCryptureSkill(EnSkillConditionType condition)
    {
        FirstCrypture.CheckSkill(condition);
    }

    public void OpenStageSelect()
    {
        stageSelect.SetActive(true);
    }

    public void BossClear()
    {
        Clear();
        isBoss = false;
    }

    public void SetStageData(int stageIndex, MapNode node, bool isBoss)
    {
        this.isBoss = isBoss;
        killCombo = 0;
        killCount = 0;
        DataManager.Instance.ThisStage = DataManager.Instance.StageInfo[stageIndex];
        goNextStageCut = DataManager.Instance.RecentLayer * DataManager.Instance.ThisStage.monster_stair_clear_plus + DataManager.Instance.ThisStage.monster_first_stair_clear_ea;

        DataManager.Instance.ThisNode = node;
        DataManager.Instance.KILLALL = false;
    }
}
