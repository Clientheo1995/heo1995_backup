public class MonsterData : Unit
{
    EnMonsterType type;
    int skillIdx;
    int attackTypeIndex;
    int aggroX;
    int aggroY;
    float spawnRate;
    float spawnRateDecrease;
    float spawnDecreaseLimit;
    float spawnRateIncrease;
    float spawnIncreaseLimit;
    string resource;
    string m_strName;
    int score;

    public int index { get { return m_nIndex; } set { m_nIndex = value; } }
    public EnMonsterType monster_type { get { return type; } set { type = (EnMonsterType)value; } }
    public float monster_hp { get { return m_nHp; } set { m_nHp = value; } }
    public float monster_hp_regen { get { return m_fHpRegen; } set { m_fHpRegen = value; } }
    public float monster_speed { get { return m_fMoveSpeed; } set { m_fMoveSpeed = value; } }
    public float monster_def { get { return m_nDef; } set { m_nDef = value; } }
    public int skill_idx { get { return skillIdx; } set { skillIdx = value; } }
    public int attack_idx { get { return attackTypeIndex; } set { attackTypeIndex = value; } }
    public float monster_spawn_per { get { return spawnRate; } set { spawnRate = value; } }
    public float monster_spawn_minus_per { get { return spawnRateDecrease; } set { spawnRateDecrease = value; } }
    public float monster_spawn_minus_limit { get { return spawnDecreaseLimit; } set { spawnDecreaseLimit = value; } }
    public float monster_spawn_plus_per { get { return spawnRateIncrease; } set { spawnRateIncrease = value; } }
    public float monster_spawn_plus_limit { get { return spawnIncreaseLimit; } set { spawnIncreaseLimit = value; } }
    public string monster_resource { get { return resource; } set { resource = value; } }
    public string monster_name { get { return m_strName; } set { m_strName = value; } }
    public int monster_score { get { return score; } set { score = value; } }
}
