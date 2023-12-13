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
    back = 0,  // ���� back_color ����
    ear, //  = ����
    tail, //, tail_color = ����
    eye, //  = ��
    mouth, // = ��
    pattern, // �� or ����ũ��
    background, //��׶��� ����// ���ֿ��� ����.
    Length,
    color, // ������ �ȵ����� ���� �ο��� ��Ȳ�� ���� �� ������ �־���.
}

public enum SpinePartsColor
{
    //���� ���� ����
    body_color, ear_color, back_color, tail_color,
    leg1_color, leg2_color, leg3_color, leg4_color, head_color,
    Length
}

public enum EnSkillConditionType
{
    defaultCondition,//�⺻
    time,//�ð�
    attack,//Ÿ��
    hit,//�ǰ�
    die,//���
    get,//ȹ��
    percent,//Ȯ��
    finalHit,//��Ÿ

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
    aura,               //0 : ���� ����
    time,               //1 : �ð� ����
    normalStage,        //2 : �Ϲ� ���� �������� ����
    bossStage,          //3 : ���� ���� �������� ����
    wholeStage,         //4 : �Ϲ� / ���� ���� �������� ����
    summon,             //5 : ��ȯ

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
/// 0 - RestSelect �޽� �� ������
/// 1 - SkillSelect �޽� �� ������ �� �ִ� ��ų ����Ʈ
/// 2 - CryptureList �޽� �� ��ų�� ����� ũ���� ����Ʈ
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