using System;
using System.Collections.Generic;

public class CharacterData : Unit
{
    public int index { get { return m_nIndex; }set { m_nIndex = value; } }
    public float char_hp { get { return m_nHp; } set { m_nHp = value; } }
    public float char_move_speed { get { return m_fMoveSpeed; } set { m_fMoveSpeed = value; } }
    public float char_def { get { return m_nDef; } set { m_nDef = value; } }
    public float char_hp_regen { get { return m_fHpRegen; } set { m_fHpRegen = value; } }
    protected float m_fGachaPer;
    public float char_gacha_per { get { return m_fGachaPer; } set { m_fGachaPer = value; } }

    public int m_cryptureType;
    public int parts_char_type { get { return m_cryptureType; } set { m_cryptureType = value; } }
}
