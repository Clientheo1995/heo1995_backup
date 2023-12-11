using System.Collections.Generic;

using UnityEngine;

public class Parts
{
    public List<PartData> m_listParts;//리스트구현이 맞나
    float m_nAddition;
    public Color m_color = Color.magenta;
    public int TotalDMG;

    public void AddPart(int index)
    {
        if (m_listParts == null) m_listParts = new List<PartData>();
        PartData newPart = DataManager.Instance.PartInfo[index];
        if (newPart != null) m_listParts.Add(newPart);
    }

    public void RemovePart(SpineParts partType)
    {
        if (m_listParts == null) return;
        for (int i = 0; i < m_listParts.Count; i++)
        {
            if (m_listParts[i].parts_type == partType)
            {
                m_listParts.RemoveAt(i);
            }
        }
    }

    public void ChangePart(SpineParts partType, int index)
    {
        RemovePart(partType);
        AddPart(index);
    }

    public float Wing(float moveSpeed)
    {
        return moveSpeed + (int)(moveSpeed * MakeAddition(SpineParts.back));
    }

    public int Tail()
    {
        for (int i = 0; i < m_listParts.Count; i++)
        {
            if (m_listParts[i].parts_type == SpineParts.tail)
            {
                return m_listParts[i].parts_attack_idx1;
            }
        }
        return 0;
    }

    public int Hat_Ear()
    {
        for (int i = 0; i < m_listParts.Count; i++)
        {
            if (m_listParts[i].parts_type == SpineParts.tail)
            {
                return m_listParts[i].parts_attack_idx1;//어떤상황에서 인덱스2를 쓰는지 알아야함
            }
        }

        return -1;
    }

    public AttackType GetAttackType()
    {
        for (int i = 0; i < m_listParts.Count; i++)
        {
            if (m_listParts[i].parts_type == SpineParts.tail)
            {
                if (m_listParts[i].parts_attack_idx1 == 0) continue;
                return DataManager.Instance.AttackTypeInfo[m_listParts[i].parts_attack_idx1];//어떤상황에서 인덱스2를 쓰는지 알아야함
            }
        }

        return null;
    }

    public float Eye(float maxHp)
    {
        return maxHp + maxHp * MakeAddition(SpineParts.eye);
    }

    public float Mouth(float def)
    {
        return def + def * MakeAddition(SpineParts.mouth);
    }

    public float MakeUp(float crit)
    {
        return crit + crit * MakeAddition(SpineParts.pattern);
    }

    public float Background(float hpRegen)
    {
        return hpRegen + hpRegen * MakeAddition(SpineParts.background);
    }

    public void SetAddition(Color color)
    {
        if (color.r.Equals(color.g) ||
            color.b.Equals(color.g) ||
            color.r.Equals(color.b))
        {
            m_nAddition = 0.05f;
        }
        else if (color.r.Equals(color.g) && color.r.Equals(color.b))
        {
            m_nAddition = 0.1f;
        }
    }

    float MakeAddition(SpineParts part)
    {
        for (int i = 0; i < m_listParts.Count; i++)
        {
            if (m_listParts[i].parts_type == part)
            {
                switch (m_listParts[i].parts_rarity_type)
                {
                    case EnGrade.none:
                        Debug.Log($"facter({PartData.None + m_nAddition}) = rarity({PartData.None}) + Addition({m_nAddition}) ↓아래의 factor");
                        return PartData.None + m_nAddition;
                    case EnGrade.common:
                        Debug.Log($"facter({PartData.Common + m_nAddition}) = rarity({PartData.Common}) + Addition({m_nAddition})");
                        return PartData.Common + m_nAddition;
                    case EnGrade.uncommon:
                        Debug.Log($"facter({PartData.Uncommon + m_nAddition}) = rarity({PartData.Uncommon}) + Addition({m_nAddition})");
                        return PartData.Uncommon + m_nAddition;
                    case EnGrade.rare:
                        Debug.Log($"facter({PartData.Rare + m_nAddition}) = rarity({PartData.Rare}) + Addition({m_nAddition})");
                        return PartData.Rare + m_nAddition;
                    case EnGrade.epic:
                        Debug.Log($"facter({PartData.Epic + m_nAddition}) = rarity({PartData.Epic}) + Addition({m_nAddition})");
                        return PartData.Epic + m_nAddition;
                }
            }
        }
        return PartData.None;
    }
}
