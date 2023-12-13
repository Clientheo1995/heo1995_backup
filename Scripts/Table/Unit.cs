using UnityEngine;

public class Unit
{
    protected float m_nHp;
    protected float m_fMoveSpeed;
    protected float m_fTurnSpeed;
    protected float m_nDef;
    protected float m_fHpRegen;
    protected int m_nOrder;
    protected int m_nIndex;

    protected Vector3 m_vtPosition;
    protected Quaternion m_qRotation;

    protected Rigidbody2D m_RigidBody;

    public virtual void SetData(float hp, float speed, float def, float hpRegen)
    {
        m_nHp = hp;
        m_fMoveSpeed = speed;
        m_nDef = def;
        m_fHpRegen = hpRegen;
    }

    public void SetOrder()
    {
        //m_nOrder = DataManager.Instance.User.CryptureCount - 1;//로그인 시 할당되는 숫자지만, 로그라이크 특성상 상관없을듯?
    }

    public void HpRegen()
    {
        m_nHp += m_fHpRegen;
    }

    public void Damaged(float damage)
    {
        m_nHp -= (damage - m_nDef);
    }
}