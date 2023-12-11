public class PartData
{
    public static float None = 0.1f;
    public static float Common = 0.2f;
    public static float Uncommon = 0.3f;
    public static float Rare = 0.4f;
    public static float Epic = 0.5f;

    int indx;
    int charType;
    SpineParts partType;
    EnGrade rarityType;
    int increaseStat;
    int skillIdx1;
    int skillIdx2;
    int attackIdx1;
    float gacha_normal;
    float gacha_premium;
    float gacha_super;
    string img;
    string spineName;
    string name;
    string desc;

    public int index { get { return indx; } set { indx = value; } }
    public int parts_char_type { get { return charType; } set { charType = value; } }
    public SpineParts parts_type { get { return partType; } set { partType = (SpineParts)value; } }
    public EnGrade parts_rarity_type { get { return rarityType; } set { rarityType = (EnGrade)value; } }
    public int parts_increase_stat { get { return increaseStat; } set { increaseStat = value; } }
    public int parts_skill_idx1 { get { return skillIdx1; } set { skillIdx1 = value; } }
    public int parts_skill_idx2 { get { return skillIdx2; } set { skillIdx2 = value; } }
    public int parts_attack_idx1 { get { return attackIdx1; } set { attackIdx1 = value; } }
    public float parts_gacha_normal { get { return gacha_normal; } set { gacha_normal = value; } }
    public float parts_gacha_premium { get { return gacha_premium; } set { gacha_premium = value; } }
    public float parts_gacha_super { get { return gacha_super; } set { gacha_super = value; } }
    public string parts_img { get { return img; } set { img = value; } }
    public string parts_spine { get { return spineName; } set { spineName = value; } }
    public string parts_name { get { return name; } set { name = value; } }
    public string parts_description { get { return desc; } set { desc = value; } }
}

public class AttackType
{
    int indx;
    EnAttackType type;
    int readyCheck;
    int dmgCheck;
    int skillIdx;
    float shootSpeed;
    int shootEA;
    float cooltime;
    float damage;
    float critical;

    public int index { get { return indx; } set { indx = value; } }
    public EnAttackType attack_type { get { return type; } set { type = (EnAttackType)value; } }
    public int attack_ready_check_idx { get { return readyCheck; } set { readyCheck = value; } }
    public int attack_damage_check_idx { get { return dmgCheck; } set { dmgCheck = value; } }
    public int attack_skill_idx { get { return skillIdx; } set { skillIdx = value; } }
    public float attack_shoot_spd { get { return shootSpeed; } set { shootSpeed = value; } }
    public int attack_shoot_ea { get { return shootEA; } set { shootEA = value; } }
    public float attack_cooltime { get { return cooltime; } set { cooltime = value; } }
    public float attack_damage { get { return damage; } set { damage = value; } }
    public float attack_critical { get { return critical; } set { critical = value; } }
}

public class SkillData
{
    int indx;
    int conditionGroupNum;
    int activationGroupNum;
    int targetGroupNum;
    int effectGroupNum;
    float cooltime;
    string name;
    string conditionDesc;
    string effectDesc;
    int equipCheck;
    string img;
    float per;


    public int index { get { return indx; } set { indx = value; } }
    public int skill_condition_group { get { return conditionGroupNum; } set { conditionGroupNum = value; } }
    public int skill_activation_group { get { return activationGroupNum; } set { activationGroupNum = value; } }
    public int skill_target_group { get { return targetGroupNum; } set { targetGroupNum = value; } }
    public int skill_effect_group { get { return effectGroupNum; } set { effectGroupNum = value; } }
    public float skill_cooltime { get { return cooltime; } set { cooltime = value; } }
    public string skill_name { get { return name; } set { name = value; } }
    public string skill_condition_description { get { return conditionDesc; } set { conditionDesc = value; } }
    public string skill_effect_description { get { return effectDesc; } set { effectDesc = value; } }
    public int skill_equip_check { get { return equipCheck; } set { equipCheck = value; } }
    public float skill_per { get { return per; } set { per = value; } }
    public string skill_img { get { return img; } set { img = value; } }
}

public class SkillCondition
{
    int indx;
    int skillGroup;
    EnSkillConditionType conditionType;
    EnSkillTime_PerType timePerType;
    float timePerWrite;

    public int index { get { return indx; } set { indx = value; } }
    public int skill_group { get { return skillGroup; } set { skillGroup = value; } }
    public EnSkillConditionType condition_type { get { return conditionType; } set { conditionType = (EnSkillConditionType)value; } }
    public EnSkillTime_PerType time_per_type { get { return timePerType; } set { timePerType = (EnSkillTime_PerType)value; } }
    public float time_per_write { get { return timePerWrite; } set { timePerWrite = value; } }
}

public class SkillActivation
{
    int indx;
    int skillGroup;
    EnSkillActivationType activationType;
    int skillX;
    int skillY;
    EnSkillTime_PerType timePerType;
    float timePerWrite;

    public int index { get { return indx; } set { indx = value; } }
    public int skill_group { get { return skillGroup; } set { skillGroup = value; } }
    public EnSkillActivationType activation_type { get { return activationType; } set { activationType = (EnSkillActivationType)value; } }
    public int aura_x { get { return skillX; } set { skillX = value; } }
    public int aura_y { get { return skillY; } set { skillY = value; } }
    public EnSkillTime_PerType time_per_type { get { return timePerType; } set { timePerType = (EnSkillTime_PerType)value; } }
    public float time_per_write { get { return timePerWrite; } set { timePerWrite = value; } }
}

public class SkillTarget
{
    int indx;
    int skillGroup;
    EnSkillTargetType targetType;

    public int index { get { return indx; } set { indx = value; } }
    public int skill_group { get { return skillGroup; } set { skillGroup = value; } }
    public EnSkillTargetType condition_type { get { return targetType; } set { targetType = (EnSkillTargetType)value; } }
}

public class SkillEffect
{
    int indx;
    int skillGroup;
    EnSkillEffectType effectType;
    int skillX;
    int skillY;


    //스킬의 효과 수치가 고정 또는 퍼센테이지 만큼의 조건이 있는지 분류	
    //0 : 고정 수치나 퍼센테이지 수치를 기입하지 않음	
    //1 : 고정 수치	
    //2 : 퍼센테이지 기입
    EnSkillFix_PerType fixPerType;

    //fix_per_type에서 1 또는 2에 해당하는 경우 고정 수치 또는 퍼센테이지를 기입하도록 함
    //퍼센테이지의 경우 소수점 1번째까지 계산하도록 한다.
    //기입이 필요 없는 경우 0으로 두도록 한다.
    float fixPerWrite;

    public int index { get { return indx; } set { indx = value; } }
    public int skill_group { get { return skillGroup; } set { skillGroup = value; } }
    public EnSkillEffectType effect_type { get { return effectType; } set { effectType = (EnSkillEffectType)value; } }
    public int skill_x { get { return skillX; } set { skillX = value; } }
    public int skill_y { get { return skillY; } set { skillY = value; } }
    public EnSkillFix_PerType fix_per_type { get { return fixPerType; } set { fixPerType = (EnSkillFix_PerType)value; } }
    public float fix_per_write { get { return fixPerWrite; } set { fixPerWrite = value; } }
}

public class normal_battle_spawn
{
    int indx;
    int group;
    float normalRate;
    float eliteRate;
    float specialRate;
    float bossRate;
    float curtainMinusRate;
    float minusLimit;
    float curtainPlusRate;
    float plusLimit;
    float startNendX;
    float startNendY;
    float lineRate;
    int lineLimit;
    float coolTimeMin;
    float coolTimeMax;
    int startAct;

    public int index { get { return indx; } set { indx = value; } }
    public int spawn_per { get { return group; } set { group = value; } }
    public float monster_normal_per { get { return normalRate; } set { normalRate = value; } }
    public float monster_elite_per { get { return eliteRate; } set { eliteRate = value; } }
    public float monster_special_per { get { return specialRate; } set { specialRate = value; } }
    public float monster_boss_per { get { return bossRate; } set { bossRate = value; } }
    public float monster_curtain_spawn_minus_per { get { return curtainMinusRate; } set { curtainMinusRate = value; } }
    public float monster_spawn_minus_limit { get { return minusLimit; } set { minusLimit = value; } }
    public float monster_curtain_spawn_plus_per { get { return curtainPlusRate; } set { curtainPlusRate = value; } }
    public float monster_spawn_plus_limit { get { return plusLimit; } set { plusLimit = value; } }
    public float monster_spawn_startNend_x { get { return startNendX; } set { startNendX = value; } }
    public float monster_spawn_startNend_y { get { return startNendY; } set { startNendY = value; } }
    public float monster_line_per { get { return lineRate; } set { lineRate = value; } }
    public int monster_line_limit { get { return lineLimit; } set { lineLimit = value; } }
    public float monster_spawn_time_min { get { return coolTimeMin; } set { coolTimeMin = value; } }
    public float monster_spawn_time_max { get { return coolTimeMax; } set { coolTimeMax = value; } }
    public int monster_spawn_start_act { get { return startAct; } set { startAct = value; } }
}

public class Mode
{
    int indx;
    int stageIndex;
    string monsterSkill;
    int normalGroup;
    int bossIndex_1;
    int bossIndex_2;
    int bossIndex_3;
    int bossIndex_4;
    int dropItemGroup;
    int eventGroup;
    int shopGroup;
    int modeReward;
    int seasonReward;
    int nScore;
    string seasonStartDay;
    string seasonStartTime;
    string seasonEndDay;
    string seasonEndTime;

    public int index { get { return indx; } set { indx = value; } }
    public int stage_idx { get { return stageIndex; } set { stageIndex = value; } }
    public string monster_skill { get { return monsterSkill; } set { monsterSkill = value; } }
    public int normal_battle_spawn_group_set { get { return normalGroup; } set { normalGroup = value; } }
    public int boss_battle_spawn_idx_1 { get { return bossIndex_1; } set { bossIndex_1 = value; } }
    public int boss_battle_spawn_idx_2 { get { return bossIndex_2; } set { bossIndex_2 = value; } }
    public int boss_battle_spawn_idx_3 { get { return bossIndex_3; } set { bossIndex_3 = value; } }
    public int boss_battle_spawn_idx_4 { get { return bossIndex_4; } set { bossIndex_4 = value; } }
    public int drop_item_group_set { get { return dropItemGroup; } set { dropItemGroup = value; } }
    public int event_group_set { get { return eventGroup; } set { eventGroup = value; } }
    public int shop_group_set { get { return shopGroup; } set { shopGroup = value; } }
    public int mode_reward { get { return modeReward; } set { modeReward = value; } }
    public int season_reward { get { return seasonReward; } set { seasonReward = value; } }
    public int score { get { return nScore; } set { nScore = value; } }
    public string season_start_day { get { return seasonStartDay; } set { seasonStartDay = value; } }
    public string season_start_time { get { return seasonStartTime; } set { seasonStartTime = value; } }
    public string season_end_day { get { return seasonEndDay; } set { seasonEndDay = value; } }
    public string season_end_time { get { return seasonEndTime; } set { seasonEndTime = value; } }

}

public class Stage
{
    public bool isBoss;
    int indx;
    int firstRemainCount;
    int remainCount;
    int firstLimit;
    int limitPlus;
    int actMaxLayer;
    float battleRate;
    float eventRate;
    float shopRate;
    float restRate;
    int maxAct;

    public int index { get { return indx; } set { indx = value; } }
    public int monster_first_stair_clear_ea { get { return firstRemainCount; } set { firstRemainCount = value; } }
    public int monster_stair_clear_plus { get { return remainCount; } set { remainCount = value; } }
    public int monster_first_limit { get { return firstLimit; } set { firstLimit = value; } }
    public int monster_limit_plus { get { return limitPlus; } set { limitPlus = value; } }
    public int act_max { get { return actMaxLayer; } set { actMaxLayer = value; } }
    public float battle_per { get { return battleRate; } set { battleRate = value; } }
    public float event_per { get { return eventRate; } set { eventRate = value; } }
    public float shop_per { get { return shopRate; } set { shopRate = value; } }
    public float rest_per { get { return restRate; } set { restRate = value; } }
    public int max_act { get { return maxAct; } set { maxAct = value; } }
}

public class StageEvent
{
    int indx;
    int group;
    int condition;
    float rate;
    string name;
    string desc;
    string choiceName1;
    string choiceDesc1;
    string choiceName2;
    string choiceDesc2;
    string choiceName3;
    string choiceDesc3;
    string choiceName4;
    string choiceDesc4;
    string choiceName5;
    string choiceDesc5;
    string choiceName6;
    string choiceDesc6;

    public int index { get { return indx; } set { indx = value; } }
    public int event_group { get { return group; } set { group = value; } }
    public int event_condition { get { return condition; } set { condition = value; } }
    public float event_per { get { return rate; } set { rate = value; } }
    public string event_name { get { return name; } set { name = value; } }
    public string event_desc { get { return desc; } set { desc = value; } }
    public string choice_1_name { get { return choiceName1; } set { choiceName1 = value; } }
    public string choice_1_desc { get { return choiceDesc1; } set { choiceDesc1 = value; } }
    public string choice_2_name { get { return choiceName2; } set { choiceName2 = value; } }
    public string choice_2_desc { get { return choiceDesc2; } set { choiceDesc2 = value; } }
    public string choice_3_name { get { return choiceName3; } set { choiceName3 = value; } }
    public string choice_3_desc { get { return choiceDesc3; } set { choiceDesc3 = value; } }
    public string choice_4_name { get { return choiceName4; } set { choiceName4 = value; } }
    public string choice_4_desc { get { return choiceDesc4; } set { choiceDesc4 = value; } }
    public string choice_5_name { get { return choiceName5; } set { choiceName5 = value; } }
    public string choice_5_desc { get { return choiceDesc5; } set { choiceDesc5 = value; } }
    public string choice_6_name { get { return choiceName6; } set { choiceName6 = value; } }
    public string choice_6_desc { get { return choiceDesc6; } set { choiceDesc6 = value; } }
}

public class StageShop
{
    int indx;
    int group;
    string condition;
    int name;
    string desc;
    float rate;
    int cost;

    public int index { get { return indx; } set { indx = value; } }
    public int shop_group { get { return group; } set { group = value; } }
    public string shop_condition { get { return condition; } set { condition = value; } }
    public int shop_name { get { return name; } set { name = value; } }
    public string shop_desc { get { return desc; } set { desc = value; } }
    public float shop_per { get { return rate; } set { rate = value; } }
    public int shop_buy_coin { get { return cost; } set { cost = value; } }
}

public class DropItem
{
    int indx;
    int group;
    EnDrop1stType dropType;
    int effectIndex;
    float rate;

    public int index { get { return indx; } set { indx = value; } }
    public int drop_item_group { get { return group; } set { group = value; } }
    public EnDrop1stType drop_item_2nd_type { get { return dropType; } set { dropType = (EnDrop1stType)value; } }
    public int drop_item_effect { get { return effectIndex; } set { effectIndex = value; } }
    public float item_per { get { return rate; } set { rate = value; } }
}

public class DropItemEffect
{
    int indx;
    EnDropTypeEffect effectIndex;
    float fx1;
    float fx2;
    float fx3;
    float fx4;
    float fx5;
    float fx6;

    public int index { get { return indx; } set { indx = value; } }
    public EnDropTypeEffect drop_item_effect { get { return effectIndex; } set { effectIndex = (EnDropTypeEffect)value; } }
    public float effect1 { get { return fx1; } set { fx1 = value; } }
    public float effect2 { get { return fx2; } set { fx2 = value; } }
    public float effect3 { get { return fx3; } set { fx3 = value; } }
    public float effect4 { get { return fx4; } set { fx4 = value; } }
    public float effect5 { get { return fx5; } set { fx5 = value; } }
    public float effect6 { get { return fx6; } set { fx6 = value; } }
}