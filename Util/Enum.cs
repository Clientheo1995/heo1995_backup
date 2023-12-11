public enum AudioChannel
{
    BGM,
    UI,
    SFX,

    Length
}

public enum EnCryptureType
{
    cryptty,
    crypkky,
    crypoon,
    no_limit,

    Length
}

public enum EnGrade
{
    none,
    common,
    uncommon,
    rare,
    epic,

    Length
}

public enum EnTileType
{
    blank, 
    attacker, 
    target,
    aggro,
    damage,

    Length
}

public enum EnMonsterType
{
    normal,
    elite,
    special,
    boss,

    Length
}

public enum EnAttackType
{
    range,
    missile,
    melee,
    timer,

    Length
}

public enum SpineParts
{
    back = 0,  // 날개 back_color 날개
    ear, //  = 모자
    tail, //, tail_color = 꼬리
    eye, //  = 눈
    mouth, // = 입
    pattern, // 코 or 메이크업
    background, //백그라운드 별도// 유닛에는 없음.
    Length,
    color, // 실제론 안들어가지만 유형 부여할 상황이 있을 때 쓰려고 넣었음.
}

public enum SpinePartsColor
{
    //몸통 색상 지정
    body_color, ear_color, back_color, tail_color,
    leg1_color, leg2_color, leg3_color, leg4_color, head_color,
    Length
}

public enum EnSkillConditionType
{
    defaultCondition,//기본
    time,//시간
    attack,//타격
    hit,//피격
    die,//사망
    get,//획득
    percent,//확률
    finalHit,//막타

    Length
}

public enum EnSkillTime_PerType
{
    none = 0,
    time,
    percent,

    Length
}

public enum EnSkillFix_PerType
{
    none = 0,
    fix,
    percent,

    Length
}

public enum EnSkillActivationType
{
    aura,               //0 : 오라 생성
    time,               //1 : 시간 지속
    normalStage,        //2 : 일반 전투 스테이지 지속
    bossStage,          //3 : 보스 전투 스테이지 지속
    wholeStage,         //4 : 일반 / 보스 전투 스테이지 지속
    summon,             //5 : 소환

    Length
}

public enum EnSkillTargetType
{
    solo_ally,

    Length
}

public enum EnSkillEffectType
{
    dmgInc,
    defInc,
    hpRegenInc,
    maxHpInc,
    dmgDec,
    defDec,
    hpRegenDec,
    maxHpDec,
    bomb,
    laser,
    gainHp,
    gainHpWhenAttack,
    fire,
    defSheild,

    Length

}

public enum EnDrop1stType
{
    is1stItems,
    is2ndItems,

    Length
}

public enum EnDropType
{
    Utility,
    Currency,
    None,

    Length
}

public enum EnDropTypeEffect
{
    Utility_freeze,
    Utility_damageUp,
    Utility_defUp,
    Utility_hpUp,

    Length
}

public enum EnStageType
{
    Normal,
    Event,
    Shop,
    Rest,

    Length
}

public enum EnUIPanel
{
    MainMenu,
    Instance,
    GameClear,
    GameOver,
    Roster,
    Header,
    Option,
    GameStart,
    StageSelect,
    End,

    Length
}

public enum EnSlotState
{
    buttonOn,
    buttonOff,

    Length
}

public enum EnSummonType
{
    bomb,
    mine,

    Length
}

/// <summary>
/// 0 - RestSelect 휴식 내 선택지
/// 1 - SkillSelect 휴식 내 선택할 수 있는 스킬 리스트
/// 2 - CryptureList 휴식 내 스킬을 등록할 크립쳐 리스트
/// 3 - ChangeSkill
/// </summary>
/// <param name="restIndex"></param>
public enum EnRestPanelOrder
{
    restSelect,
    skillSelect,
    cryptureList,
    changeSkill,

    Length
}