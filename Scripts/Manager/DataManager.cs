using Spine.Unity;

using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;


public class DataManager : Singleton<DataManager>
{
    public List<int> startmembers = new List<int>();
    UserData m_UserData;

    public bool DATALOADCOMPLETE = false;
    public bool GameStart = false;
    [SerializeField]
    public static float MinDistance = 10f;

    public List<MapNode> WholeNodes;
    public List<Transform> Layers;

    public Stage ThisStage;
    public int RecentLayer = 0;
    public bool KILLALL = false;
    public MapNode ThisNode;

    //Table
    public Dictionary<string, string> StringTable = new Dictionary<string, string>();

    public Dictionary<int, CryptureData> CryptureInfo = new Dictionary<int, CryptureData>();
    public Dictionary<int, MonsterData> MonsterInfo = new Dictionary<int, MonsterData>();
    public Dictionary<int, PartData> PartInfo = new Dictionary<int, PartData>();
    public Dictionary<int, AttackType> AttackTypeInfo = new Dictionary<int, AttackType>();
    public Dictionary<int, TileData> AttackReadyCheckTableInfo = new Dictionary<int, TileData>();
    public Dictionary<int, TileData> AttackDamageCheckTableInfo = new Dictionary<int, TileData>();
    public Dictionary<int, Mode> ModeInfo = new Dictionary<int, Mode>();
    public Dictionary<int, SkillData> SkillInfo = new Dictionary<int, SkillData>();
    public Dictionary<int, SkillCondition> SkillConditionInfo = new Dictionary<int, SkillCondition>();
    public Dictionary<int, SkillActivation> SkillActivationInfo = new Dictionary<int, SkillActivation>();
    public Dictionary<int, SkillTarget> SkillTargetInfo = new Dictionary<int, SkillTarget>();
    public Dictionary<int, SkillEffect> SkillEffectInfo = new Dictionary<int, SkillEffect>();
    public Dictionary<int, DropItem> DropItemInfo = new Dictionary<int, DropItem>();
    public Dictionary<int, DropItemEffect> DropItemEffectInfo = new Dictionary<int, DropItemEffect>();
    public Dictionary<int, Stage> StageInfo = new Dictionary<int, Stage>();
    public Dictionary<int, StageEvent> StageEventInfo = new Dictionary<int, StageEvent>();
    public Dictionary<int, StageShop> StageShopInfo = new Dictionary<int, StageShop>();

    #region
    public List<TempGStarCrypture> GStarCrypture = new List<TempGStarCrypture>();
    public TempGStarCrypture[] TempRoster = new TempGStarCrypture[3];

    public void Resume()
    {
        if (Time.timeScale <= 0)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0f;
    }

    void MakeGStarCrypture()
    {
        TempGStarCrypture crypture = new TempGStarCrypture();
        crypture.data = CryptureInfo[10];
        crypture.star = 0;
        crypture.index = 0;
        crypture.color = new Color(178, 200, 125);
        crypture.parts = new List<PartData>();
        crypture.parts.Add(PartInfo[2000002]);
        crypture.parts.Add(PartInfo[3000001]);
        crypture.parts.Add(PartInfo[4000002]);
        crypture.parts.Add(PartInfo[5000002]);
        crypture.parts.Add(PartInfo[6000002]);
        crypture.parts.Add(PartInfo[7000002]);
        crypture.parts.Add(PartInfo[8000002]);
        GStarCrypture.Add(crypture);

        TempGStarCrypture crypture1 = new TempGStarCrypture();
        crypture1.data = CryptureInfo[10];
        crypture1.star = 1;
        crypture1.index = 1;
        crypture1.color = new Color(200, 100, 120);
        crypture1.parts = new List<PartData>();
        crypture1.parts.Add(PartInfo[2000004]);
        crypture1.parts.Add(PartInfo[3000002]);
        crypture1.parts.Add(PartInfo[4000004]);
        crypture1.parts.Add(PartInfo[5000005]);
        crypture1.parts.Add(PartInfo[6000004]);
        crypture1.parts.Add(PartInfo[7000005]);
        crypture1.parts.Add(PartInfo[8000005]);
        GStarCrypture.Add(crypture1);

        TempGStarCrypture crypture2 = new TempGStarCrypture();
        crypture2.data = CryptureInfo[10];
        crypture2.star = 2;
        crypture2.index = 2;
        crypture2.color = new Color(25, 25, 155);
        crypture2.parts = new List<PartData>();
        crypture2.parts.Add(PartInfo[2000007]);
        crypture2.parts.Add(PartInfo[3000003]);
        crypture2.parts.Add(PartInfo[4000008]);
        crypture2.parts.Add(PartInfo[5000006]);
        crypture2.parts.Add(PartInfo[6000005]);
        crypture2.parts.Add(PartInfo[7000006]);
        crypture2.parts.Add(PartInfo[8000008]);
        GStarCrypture.Add(crypture2);

        TempGStarCrypture crypture3 = new TempGStarCrypture();
        crypture3.data = CryptureInfo[10];
        crypture3.star = 3;
        crypture3.index = 3;
        crypture3.color = new Color(100, 100, 100);
        crypture3.parts = new List<PartData>();
        crypture3.parts.Add(PartInfo[2000009]);
        crypture3.parts.Add(PartInfo[3000004]);
        crypture3.parts.Add(PartInfo[4000009]);
        crypture3.parts.Add(PartInfo[5000009]);
        crypture3.parts.Add(PartInfo[6100001]);
        crypture3.parts.Add(PartInfo[7100001]);
        crypture3.parts.Add(PartInfo[8100002]);
        GStarCrypture.Add(crypture3);

        TempGStarCrypture crypture4 = new TempGStarCrypture();
        crypture4.data = CryptureInfo[11];
        crypture4.star = 0;
        crypture4.index = 4;
        crypture4.color = new Color(17, 132, 177);
        crypture4.parts = new List<PartData>();
        crypture4.parts.Add(PartInfo[2100002]);
        crypture4.parts.Add(PartInfo[3100001]);
        crypture4.parts.Add(PartInfo[4100001]);
        crypture4.parts.Add(PartInfo[5000003]);
        crypture4.parts.Add(PartInfo[6000003]);
        crypture4.parts.Add(PartInfo[7000003]);
        crypture4.parts.Add(PartInfo[8000003]);
        GStarCrypture.Add(crypture4);

        TempGStarCrypture crypture5 = new TempGStarCrypture();
        crypture5.data = CryptureInfo[11];
        crypture5.star = 1;
        crypture5.index = 5;
        crypture5.color = new Color(85, 35, 65);
        crypture5.parts = new List<PartData>();
        crypture5.parts.Add(PartInfo[2100004]);
        crypture5.parts.Add(PartInfo[3100002]);
        crypture5.parts.Add(PartInfo[4100005]);
        crypture5.parts.Add(PartInfo[5000007]);
        crypture5.parts.Add(PartInfo[6000008]);
        crypture5.parts.Add(PartInfo[7000007]);
        crypture5.parts.Add(PartInfo[8000006]);
        GStarCrypture.Add(crypture5);

        TempGStarCrypture crypture6 = new TempGStarCrypture();
        crypture6.data = CryptureInfo[11];
        crypture6.star = 2;
        crypture6.index = 6;
        crypture6.color = new Color(70, 70, 67);
        crypture6.parts = new List<PartData>();
        crypture6.parts.Add(PartInfo[2100007]);
        crypture6.parts.Add(PartInfo[3100003]);
        crypture6.parts.Add(PartInfo[4100007]);
        crypture6.parts.Add(PartInfo[5000008]);
        crypture6.parts.Add(PartInfo[6000006]);
        crypture6.parts.Add(PartInfo[7100001]);
        crypture6.parts.Add(PartInfo[8000009]);
        GStarCrypture.Add(crypture6);

        TempGStarCrypture crypture7 = new TempGStarCrypture();
        crypture7.data = CryptureInfo[11];
        crypture7.star = 3;
        crypture7.index = 7;
        crypture7.color = new Color(74, 74, 74);
        crypture7.parts = new List<PartData>();
        crypture7.parts.Add(PartInfo[2100009]);
        crypture7.parts.Add(PartInfo[3100004]);
        crypture7.parts.Add(PartInfo[4100009]);
        crypture7.parts.Add(PartInfo[5000008]);
        crypture7.parts.Add(PartInfo[6000009]);
        crypture7.parts.Add(PartInfo[7000006]);
        crypture7.parts.Add(PartInfo[8100002]);
        GStarCrypture.Add(crypture7);

        TempGStarCrypture crypture8 = new TempGStarCrypture();
        crypture8.data = CryptureInfo[12];
        crypture8.star = 0;
        crypture8.index = 8;
        crypture8.color = new Color(38, 75, 95);
        crypture8.parts = new List<PartData>();
        crypture8.parts.Add(PartInfo[2200002]);
        crypture8.parts.Add(PartInfo[3200001]);
        crypture8.parts.Add(PartInfo[4200003]);
        crypture8.parts.Add(PartInfo[5000004]);
        crypture8.parts.Add(PartInfo[6000007]);
        crypture8.parts.Add(PartInfo[7000004]);
        crypture8.parts.Add(PartInfo[8000004]);
        GStarCrypture.Add(crypture8);

        TempGStarCrypture crypture9 = new TempGStarCrypture();
        crypture9.data = CryptureInfo[12];
        crypture9.star = 1;
        crypture9.index = 9;
        crypture9.color = new Color(44, 37, 40);
        crypture9.parts = new List<PartData>();
        crypture9.parts.Add(PartInfo[2200004]);
        crypture9.parts.Add(PartInfo[3200002]);
        crypture9.parts.Add(PartInfo[4200006]);
        crypture9.parts.Add(PartInfo[5200009]);
        crypture9.parts.Add(PartInfo[6100002]);
        crypture9.parts.Add(PartInfo[7000008]);
        crypture9.parts.Add(PartInfo[8000007]);
        GStarCrypture.Add(crypture9);

        TempGStarCrypture crypture10 = new TempGStarCrypture();
        crypture10.data = CryptureInfo[12];
        crypture10.star = 2;
        crypture10.index = 10;
        crypture10.color = new Color(88, 67, 67);
        crypture10.parts = new List<PartData>();
        crypture10.parts.Add(PartInfo[2200007]);
        crypture10.parts.Add(PartInfo[3200001]);
        crypture10.parts.Add(PartInfo[4200007]);
        crypture10.parts.Add(PartInfo[5000009]);
        crypture10.parts.Add(PartInfo[6000009]);
        crypture10.parts.Add(PartInfo[7000006]);
        crypture10.parts.Add(PartInfo[8100001]);

        GStarCrypture.Add(crypture10);

        TempGStarCrypture crypture11 = new TempGStarCrypture();
        crypture11.data = CryptureInfo[12];
        crypture11.star = 3;
        crypture11.index = 11;
        crypture11.color = new Color(164, 164, 164);
        crypture11.parts = new List<PartData>();
        crypture11.parts.Add(PartInfo[2200009]);
        crypture11.parts.Add(PartInfo[3200004]);
        crypture11.parts.Add(PartInfo[4200009]);
        crypture11.parts.Add(PartInfo[5000006]);
        crypture11.parts.Add(PartInfo[6000006]);
        crypture11.parts.Add(PartInfo[7100001]);
        crypture11.parts.Add(PartInfo[8100002]);

        GStarCrypture.Add(crypture);
    }

    #endregion
    public UserData User
    {
        get { return m_UserData; }
    }

    void Start()
    {
        m_UserData = new UserData();//플레이어 데이터 저장하는거 만들어야함

        SetData("attack_type", AttackTypeInfo);
        SetData("character", CryptureInfo);
        SetData("monster", MonsterInfo);
        SetData("parts", PartInfo);
        SetMapData("attack_ready_check_table", AttackReadyCheckTableInfo);
        SetCheckTiles(ref AttackReadyCheckTableInfo);
        SetMapData("attack_damage_check_table", AttackDamageCheckTableInfo);
        SetCheckTiles(ref AttackDamageCheckTableInfo);

        SetData("skill_condition", SkillConditionInfo);
        SetData("skill_activation", SkillActivationInfo);
        SetData("skill_target", SkillTargetInfo);
        SetData("skill_effect", SkillEffectInfo);
        SetData("skill", SkillInfo);

        SetData("drop_item", DropItemInfo);
        SetData("drop_item_effect", DropItemEffectInfo);

        SetData("stage", StageInfo);
        SetData("stage_event", StageEventInfo);
        SetData("stage_shop", StageShopInfo);
        //SetData("mode", ModeInfo);
        //ReadStringTable("string", StringTable);
        MakeGStarCrypture();
        DATALOADCOMPLETE = true;
    }

    void SetData<T>(string csvName, Dictionary<int, T> classDic) where T : new()
    {
        string[] variables = new string[] { };
        string[] headers = new string[] { };
        List<List<string>> list = new List<List<string>>();
        CSVReader.Read(csvName, ref variables, ref headers, ref list);

        if (list == null)
        {
            Debug.Log($"테이블 {typeof(T)}를 읽지 못했습니다.");
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            T newT = new T();
            int key = 0;
            int count = 0;

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                //https://blog.lunapiece.net/posts/CSharp-Propert-Ordering-Trick/
                //https://learn.microsoft.com/ko-kr/dotnet/api/system.reflection.propertyinfo.propertytype?view=net-7.0
                //https://yangbengdictionary.tistory.com/4
                //propertyInfo.SetValue();
                try
                {
                    if (propertyInfo.Name.Equals("index"))
                    {
                        key = Convert.ToInt32(list[i][count]);
                    }

                    if (variables[count].Equals(propertyInfo.PropertyType.Name) && propertyInfo.PropertyType.Name.Equals("Int32") && headers[count].Equals(propertyInfo.Name))
                    {
                        if (list[i][count].Equals("0"))//Convert.ToInt32는 0을 컨버팅 할 수 없다
                            propertyInfo.SetValue(newT, 0);
                        else
                            propertyInfo.SetValue(newT, Convert.ToInt32(list[i][count]));
                    }
                    else if (variables[count].Equals(propertyInfo.PropertyType.Name) && propertyInfo.PropertyType.Name.Equals("Single") && headers[count].Equals(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(newT, Convert.ToSingle(list[i][count]));
                    }
                    else if (variables[count].Equals(propertyInfo.PropertyType.Name) && propertyInfo.PropertyType.Name.Equals("Double") && headers[count].Equals(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(newT, Convert.ToDouble(list[i][count]));
                    }
                    else if (variables[count].Equals(propertyInfo.PropertyType.Name) && propertyInfo.PropertyType.Name.Equals("String") && headers[count].Equals(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(newT, list[i][count]);
                    }
                    else if (variables[count].Equals(propertyInfo.PropertyType.Name) && propertyInfo.PropertyType.Name.Equals("Bool") && headers[count].Equals(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(newT, Convert.ToBoolean(list[i][count]));
                    }
                    else//enum을 위한 부분
                    {
                        if (list[i][count].Equals("0"))//Convert.ToInt32는 0을 컨버팅 할 수 없다
                            propertyInfo.SetValue(newT, 0);
                        else if (list[i][count].Equals("0.0"))
                            propertyInfo.SetValue(newT, 0.0f);
                        else
                            propertyInfo.SetValue(newT, Convert.ToInt32(list[i][count]));
                    }
                }
                catch
                {
                    Debug.Log(propertyInfo.ReflectedType.Name + ", " + propertyInfo.PropertyType.Name + ", " + propertyInfo.Name);
                }
                count++;
            }

            if (key == 0)
                continue;

            classDic.Add(key, newT);
        }
    }

    void SetMapData(string csvName, Dictionary<int, TileData> classDic)
    {
        Dictionary<int, TileData> table = CSVReader.ReadMap(csvName);

        if (table == null)
        {
            Debug.Log($"맵을 읽지 못했습니다.");
            return;
        }

        foreach (KeyValuePair<int, TileData> p in table)
        {
            classDic.Add(p.Key, p.Value);
        }
    }

    public void SetCheckTiles(ref Dictionary<int, TileData> dic)
    {
        int startPos = -1;
        Dictionary<int, TileData> newDic = new Dictionary<int, TileData>();

        foreach (KeyValuePair<int, TileData> readyCheck in dic)
        {
            for (int i = 0; i < readyCheck.Value.tileData.Length; i++)
            {
                if (readyCheck.Value.tileData[i] == 1)//근거리 범위 공격일 때
                {
                    startPos = i;
                    break;
                }
                if (readyCheck.Value.tileData[i] == 2)
                    startPos = i;
            }

            if (startPos == -1)//원거리 투사체
                continue;

            if (startPos > 0)
            {
                int targetRow = 0;//공격자나 공격대상의 행렬 위치
                int targetCol = 0;

                targetRow = startPos % readyCheck.Value.col > 0 ? startPos / readyCheck.Value.col : (startPos / readyCheck.Value.col) + 1;
                targetCol = startPos % readyCheck.Value.col;

                TileData newData = readyCheck.Value;
                newData.targetIndex = startPos;
                newData.targetRow = targetRow;
                newData.targetCol = targetCol;

                newDic.Add(readyCheck.Key, newData);
            }
            else
            {
                newDic.Add(readyCheck.Key, readyCheck.Value);
            }
        }

        dic.Clear();
        dic = newDic;
    }
}
