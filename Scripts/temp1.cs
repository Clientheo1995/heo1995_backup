using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class temp1 : MonoBehaviour
{
    public void Resume()
    {
        if (Time.timeScale <= 0)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0f;
    }
}
