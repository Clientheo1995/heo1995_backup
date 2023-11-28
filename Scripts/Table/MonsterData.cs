public class MonsterData : Unit
{
    int type;
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
    public int monster_type { get { return type; } set { type = value; } }
    public float monster_hp { get { return m_nHp; } set { m_nHp = value; } }
    public float monster_hp_regen { get { return m_fHpRegen; } set { m_fHpRegen = value; } }
    public float monster_speed { get { return m_fMoveSpeed; } set { m_fMoveSpeed = value; } }
    public float monster_def { get { return m_nDef; } set { m_nDef = value; } }
    public int skill_idx { get { return skillIdx; } set { skillIdx = value; } }
    public int attack_idx { get { return attackTypeIndex; } set { attackTypeIndex = value; } }
    public int monster_size_x { get { return m_nSizeX; } set { m_nSizeX = value; } }
    public int monster_size_y { get { return m_nSizeY; } set { m_nSizeY = value; } }
    public int monster_aggression_x { get { return aggroX; } set { aggroX = value; } }
    public int monster_aggression_y { get { return aggroY; } set { aggroY = value; } }
    public float monster_spawn_per { get { return spawnRate; } set { spawnRate = value; } }
    public float monster_spawn_minus_per { get { return spawnRateDecrease; } set { spawnRateDecrease = value; } }
    public float monster_spawn_minus_limit { get { return spawnDecreaseLimit; } set { spawnDecreaseLimit = value; } }
    public float monster_spawn_plus_per { get { return spawnRateIncrease; } set { spawnRateIncrease = value; } }
    public float monster_spawn_plus_limit { get { return spawnIncreaseLimit; } set { spawnIncreaseLimit = value; } }
    public string monster_resource { get { return resource; } set { resource = value; } }
    public string monster_name { get { return m_strName; } set { m_strName = value; } }
    public int monster_score { get { return score; } set { score = value; } }

    public void SetData(float hp, float speed, float def, float hpRegen, int sizeX, int sizeY,
        int type, int skillIndex, int attackIndex, int aggroX, int aggroY, float spawnRate, 
        float spawnRateDecrease, float spawnDecreaseLimit, float spawnRateIncrease, float spawnIncreaseLimit,
        string resource, string name, int score)
    {
        base.SetData(hp, speed, def, hpRegen, sizeX, sizeY);
        this.type = type;
        skillIdx = skillIndex;
        skillIdx = skillIndex;
        attackTypeIndex = attackIndex;
        this.aggroX = aggroX;
        this.aggroY = aggroY;
        this.spawnRate = spawnRate;
        this.spawnRateDecrease = spawnRateDecrease;
        this.spawnDecreaseLimit = spawnDecreaseLimit;
        this.spawnRateIncrease = spawnRateIncrease;
        this.spawnIncreaseLimit = spawnIncreaseLimit;
        this.resource = resource;
        m_strName = name;
        this.score = score;

    }
}
