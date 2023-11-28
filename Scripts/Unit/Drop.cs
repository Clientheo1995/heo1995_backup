using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Drop : MonoBehaviour
{
    public EnDropType m_dropType;
    [SerializeField] SpriteRenderer m_spriteRenderer;
    public InstanceController m_instanceController;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip specialPop;
    [SerializeField] AudioSource playSfx;

    DropItem data;
    DropItemEffect effect;

    public void SetData(InstanceController controller)
    {
        m_instanceController = controller;
        m_spriteRenderer.sprite = Resources.Load<Sprite>($"TempImage/Item{(int)m_dropType}");

        List<DropItem> drops = new List<DropItem>();
        foreach (DropItem item in DataManager.Instance.DropItemInfo.Values)
        {
            if (item.drop_item_2nd_type == EnDrop1stType.is1stItems)
            {
                drops.Add(item);
            }
        }

        List<float> rates = new List<float>();
        for (int i = 0; i < drops.Count; i++)
        {
            rates.Add(drops[i].item_per);
        }

        int index = WeightedRandom.Picker(rates);

        if (index == -1)
        {
            data = null;
            m_dropType = EnDropType.None;
        }
        else if (drops[index].index == 200001)
        {
            drops.Clear();
            foreach (DropItem item in DataManager.Instance.DropItemInfo.Values)
            {
                if (item.drop_item_2nd_type == EnDrop1stType.is2ndItems)
                {
                    drops.Add(item);
                }
            }

            rates.Clear();
            for (int i = 0; i < drops.Count; i++)
            {
                rates.Add(drops[i].item_per);
            }

            index = WeightedRandom.Picker(rates);
            data = drops[index];
            effect = DataManager.Instance.DropItemEffectInfo[data.drop_item_effect];
            m_dropType = EnDropType.Utility;
        }
        else if (drops[index].index == 200002)
        {
            data = drops[index];
            effect = DataManager.Instance.DropItemEffectInfo[data.drop_item_effect];
            m_dropType = EnDropType.Currency;
        }
        else if (drops[index].index == 200003)
        {
            data = null;
            m_dropType = EnDropType.None;
        }
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (DataManager.Instance.KILLALL)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<Crypture>().CheckSkill(EnSkillConditionType.get);

            switch (m_dropType)
            {
                case EnDropType.Utility:
                    playSfx.clip = specialPop;
                    playSfx.Play();
                    switch (effect.drop_item_effect)
                    {
                        case EnDropTypeEffect.Utility_freeze:
                            StartCoroutine(ActivateBuff(effect.effect2));
                            break;
                        case EnDropTypeEffect.Utility_damageUp:
                            StartCoroutine(ActivateBuff(effect.effect2));
                            break;
                        case EnDropTypeEffect.Utility_defUp:
                            StartCoroutine(ActivateBuff(effect.effect2));
                            break;
                        case EnDropTypeEffect.Utility_hpUp:
                            StartCoroutine(ActivateBuff(effect.effect2));
                            break;
                        default:
                            break;
                    }
                    break;
                case EnDropType.Currency:
                    playSfx.clip = coin;
                    playSfx.Play();
                    Debug.Log($"UserData Add Currency{effect.effect1}");
                    StartCoroutine(Dying());
                    break;
                case EnDropType.None:
                    Debug.Log("NONE !!!");
                    StartCoroutine(Dying());
                    break;
                default:
                    StartCoroutine(Dying());
                    break;
            }
        }
    }

    IEnumerator Dying()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    IEnumerator ActivateBuff(float time)
    {
        if (effect.drop_item_effect == EnDropTypeEffect.Utility_freeze)
        {
            m_instanceController.Freeze(true);
            yield return new WaitForSeconds(time);
            m_instanceController.Freeze(false);
        }
        else
        {
            m_instanceController.FirstCrypture.AddItemBuff(effect.drop_item_effect, effect.effect1, effect.effect2, effect.effect3, effect.effect4, effect.effect5, effect.effect6);
            yield return new WaitForSeconds(time);
            m_instanceController.FirstCrypture.AddItemBuff(effect.drop_item_effect, -effect.effect1, -effect.effect2, -effect.effect3, -effect.effect4, -effect.effect5, -effect.effect6);
        }

        Destroy(gameObject);
    }
}
