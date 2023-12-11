using System.Collections;

using Unity.VisualScripting;

using UnityEngine;

public class SummonObject : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] GameObject effect;
    SpriteRenderer sprite;
    float damage;

    public void SetData(EnSummonType summonType, int sizeX, int sizeY, float value = 0)//value 는 데미지나 다른값
    {
        if (sprite == null)
            sprite = transform.GetComponent<SpriteRenderer>();

        switch (summonType)
        {
            case EnSummonType.bomb://5초뒤에 터짐
                damage = value;
                sound.clip = Resources.Load<AudioClip>("Sound/etfx_explosion_fireball");
                sprite.sprite = Resources.Load<Sprite>($"TempImage/bomb");
                transform.localScale = new Vector3(sizeX * 0.5f, sizeY * 0.5f, 1f);
                StartCoroutine(Bomb());
                break;
            case EnSummonType.mine:
                damage = value;
                sound.clip = Resources.Load<AudioClip>("Sound/etfx_explosion_fireball");
                transform.localScale = new Vector3(sizeX * 0.15f, sizeY * 0.15f, 0.15f);
                sprite.sprite = Resources.Load<Sprite>($"TempImage/mushroombomb");
                StartCoroutine(Mine());
                break;
        }

    }

    IEnumerator Bomb()
    {
        yield return new WaitForSeconds(5f);//5초뒤에 없어질때 터지는 범위공격도 필요함
        Destroy(gameObject);
    }

    IEnumerator Mine()
    {
        yield return null;
    }

    void Update()
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
            Debug.Log("BOOOOOOOOOOOOOOOM!!!!!!!!");
            effect.SetActive(true);
            sound.Play();
            collision.transform.GetComponent<Crypture>().CalculateDamage(damage);
            Destroy(gameObject);
        }
    }
}