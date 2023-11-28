using System;
using System.Collections.Generic;

public class CryptureData : Unit
{
    public int index { get { return m_nIndex; }set { m_nIndex = value; } }
    public float char_hp { get { return m_nHp; } set { m_nHp = value; } }
    public float char_move_speed { get { return m_fMoveSpeed; } set { m_fMoveSpeed = value; } }
    public float char_turning_speed { get { return m_fTurnSpeed; } set { m_fTurnSpeed = value; } }
    public float char_def { get { return m_nDef; } set { m_nDef = value; } }
    public float char_hp_regen { get { return m_fHpRegen; } set { m_fHpRegen = value; } }
    public int char_size_x { get { return m_nSizeX; } set { m_nSizeX = value; } }
    public int char_size_y { get { return m_nSizeY; } set { m_nSizeY = value; } }

    protected float m_fGachaPer;
    public float char_gacha_per { get { return m_fGachaPer; } set { m_fGachaPer = value; } }

    public int m_cryptureType;
    public int parts_char_type { get { return m_cryptureType; } set { m_cryptureType = value; } }

    public void SetData(float hp, float speed, int def, float hpRegen, int sizeX, int sizeY, float gachaPer)
    {
        base.SetData(hp, speed, def, hpRegen, sizeX, sizeY);
        m_fGachaPer = gachaPer;
    }
}
