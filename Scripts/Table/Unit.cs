using UnityEngine;

public class Unit
{
    [SerializeField]
    [Tooltip("유닛 체력")]
    protected float m_nHp;
    [SerializeField]
    [Tooltip("유닛 이동속도")]
    protected float m_fMoveSpeed;
    [SerializeField]
    [Tooltip("유닛 회전속도")]
    protected float m_fTurnSpeed;
    [SerializeField]
    [Tooltip("유닛 방어력")]
    protected float m_nDef;
    [SerializeField]
    [Tooltip("유닛 체력 재생")]
    protected float m_fHpRegen;
    [SerializeField]
    [Tooltip("유닛 사이즈X")]
    protected int m_nSizeX;
    [SerializeField]
    [Tooltip("유닛 사이즈Y")]
    protected int m_nSizeY;

    [SerializeField]
    [Tooltip("유닛 순서")]
    protected int m_nOrder;

    protected int m_nIndex;

    protected Vector3 m_vtPosition;
    protected Quaternion m_qRotation;

    protected Rigidbody2D m_RigidBody;

    public virtual void SetData(float hp, float speed, float def, float hpRegen, int sizeX, int sizeY)
    {
        m_nHp = hp;
        m_fMoveSpeed = speed;
        m_nDef = def;
        m_fHpRegen = hpRegen;
        m_nSizeX = sizeX;
        m_nSizeY = sizeY;
    }

    public void SetOrder()
    {
        m_nOrder = DataManager.Instance.User.CryptureCount - 1;//로그인 시 할당되는 숫자지만, 로그라이크 특성상 상관없을듯?
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