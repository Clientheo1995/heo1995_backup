using UnityEngine;

//public class Singleton<T> where T: class, new()
//{
//    static T m_Instance = null;

//    public static T Instance
//    {
//        get
//        {
//            if (m_Instance == null)
//                m_Instance = new T();
//            return m_Instance;
//        }
//    }
//}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T m_Instance = null;
    public static T Instance
    {
        get
        {
            if (!m_Instance)
            {
                GameObject obj = GameObject.Find(typeof(T).Name);
                if (!obj)
                {
                    obj = new GameObject(typeof(T).Name);
                    m_Instance = obj.AddComponent<T>();
                }
                else
                {
                    m_Instance = obj.GetComponent<T>();
                }
            }
            return m_Instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}