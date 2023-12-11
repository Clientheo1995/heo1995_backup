//https://parksh3641.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-C-%EB%8D%B8%EB%A6%AC%EA%B2%8C%EC%9D%B4%ED%8A%B8-%EC%9D%B4%EB%B2%A4%ED%8A%B8-%EA%B0%84%EB%8B%A8-%EC%82%AC%EC%9A%A9%EB%B2%95
//https://computer-art.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-C-Delegate-%EC%9D%B4%EB%B2%A4%ED%8A%B8-%EC%98%88%EC%A0%9C
//https://huiyu.tistory.com/entry/C-%EA%B8%B0%EC%B4%88-%EC%9D%B4%EB%B2%A4%ED%8A%B8%EC%99%80-%EB%8D%B8%EB%A6%AC%EA%B2%8C%EC%9D%B4%ED%8A%B8-Event-Delegate

public enum EnStat
{
    HP,
    MAXHP,
    DEF,
    SPEED,
    HPREGEN,
    DOT,
    SHIELD,

    Length
}

public enum SoundChannel
{
    BGM, 
    SFX,

    Length
}

public class EventManager : Singleton<EventManager>
{
    //서버
    public delegate void ServerConnected();
    public delegate void ServerDisconnected();

    //UI
    public delegate void StageRestEffect(int index);
    public event StageRestEffect EStageRestEffect;
    public void OnEventStageRestEffect(int index)
    {
        EStageRestEffect?.Invoke(index);
    }

    public delegate void OnPanel(EnUIPanel panel);
    public event OnPanel EOnPanel;
    public void OnEventOnPanel(EnUIPanel panel)
    {
        EOnPanel?.Invoke(panel);
    }

    public delegate void OffPanel(EnUIPanel panel);
    public event OffPanel EOffPanel;
    public void OnEventOffPanel(EnUIPanel panel)
    {
        EOffPanel?.Invoke(panel);
    }

    public delegate void OnRestPanel(EnRestPanelOrder restIndex);
    public event OnRestPanel EOnRestPanel;
    public void OnEventOnRestPanel(EnRestPanelOrder restIndex)
    {
        EOnRestPanel?.Invoke(restIndex);
    }

    //게임 프로세스
    public delegate void MakeInstance();
    public event MakeInstance EMakeInstance;

    public delegate void RemoveInstance();
    public event RemoveInstance ERemoveInstance;

    public delegate void SkillEffect(EnSkillConditionType condition, float value);
    public event SkillEffect ESkillEffect;

    public delegate void MonsterFreeze();
    public event MonsterFreeze EMonsterFreeze;

    public delegate void Initialize();
    public event Initialize EInitialize;
    public void OnEventInitialize()
    {
        EInitialize?.Invoke();
    }

    public delegate void SetNextStage(int stageIndex, MapNode node, bool isBoss);
    public event SetNextStage ESetNextStage;
    public void OnEventSetNextStage(int stageIndex, MapNode node, bool isBoss)
    {
        ESetNextStage?.Invoke(stageIndex, node, isBoss);
    }

    public delegate void SetStageData(int stageIndex, MapNode node, bool isBoss);
    public event SetStageData ESetStageData;
    public void OnEventSetStageData(int stageIndex, MapNode node, bool isBoss)
    {
        ESetStageData?.Invoke(stageIndex, node, isBoss);
    }

    public delegate void FirstGameOver();
    public event FirstGameOver EFirstGameOver;
    public void OnEventFirstGameOver()
    {
        EFirstGameOver?.Invoke();
    }

    public delegate void ResetGameOverStack();
    public event ResetGameOverStack EResetGameOverStack;
    public void OnEventResetGameOverStack()
    {
        EResetGameOverStack?.Invoke();
    }

    public delegate void InstanceValueReset();
    public event InstanceValueReset EInstanceValueReset;
    public void OnEventInstanceValueReset()
    {
        EInstanceValueReset?.Invoke();
    }

    public delegate void MonsterDie();
    public event MonsterDie EMonsterDie;
    public void OnEventMonsterDie()
    {
        EMonsterDie?.Invoke();
    }
}