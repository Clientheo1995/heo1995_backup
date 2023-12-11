using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeightedRandom
{
    public static int Picker(List<float> probList)
    {
        float total = 0f;
        for (int i = 0; i < probList.Count; i++)
        {
            total += probList[i];
        }

        float pick = Random.Range(1, total);
        float current = 0f;
        for (int i = 0; i < probList.Count; i++)
        {
            current += probList[i];
            if (pick < current)
            {
                return i;
            }
        }

        return -1;
    }

    static void Shuffle(ref int[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            int temp = deck[i];
            int randomIndex = Random.Range(0, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
}
