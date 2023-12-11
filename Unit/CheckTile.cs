using UnityEngine;

public class CheckTile : MonoBehaviour
{
    TileEventListener m_Listener;   
    EnTileType m_tileType;

    public void SetData(TileEventListener listener, EnTileType tileType)
    {
        m_Listener = listener;
        m_tileType = tileType;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            m_Listener.CallEvent(collision);
        }
        if (collision.CompareTag("Player"))
        {
            m_Listener.CallEvent(collision);
        }
    }
}
