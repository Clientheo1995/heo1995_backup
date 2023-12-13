using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using static EventManager;

public class MapNode : MonoBehaviour
{
    //일반노드 크기 100 100 보스노드 크기 200 200
    public EnStageType stageType;
    int stageIndex;
    int layer;
    int m_nMaxMonsterCount;
    public List<Transform> Front;
    public CanvasController canvas;
    bool m_bIsSelected;
    float sizeX;
    float sizeY;
    //[SerializeField] LineRenderer line;
    [SerializeField] RectTransform rect;
    [SerializeField] Transform lines;
    [SerializeField] Image image;
    [SerializeField] RectTransform imageRect;
    [SerializeField] Transform x;

    bool isBoss = false;
    //https://github.com/silverua/slay-the-spire-map-in-unity/blob/master/Assets/Scripts/Node.cs        

    public void SetData(EnStageType stageType, int layer, int stageIndex, int monsterMaxCount, bool isBoss = false)
    {
        this.stageType = stageType;
        this.stageIndex = stageIndex;
        this.isBoss = isBoss;
        this.layer = layer;
        x.gameObject.SetActive(m_bIsSelected);

        if (isBoss)
        {
            image.sprite = Resources.Load<Sprite>($"UISprites/icon_0001");
            imageRect.localScale = Vector2.one * 2f;
        }
        else
        {
            switch (this.stageType)
            {
                case EnStageType.Normal:
                    image.sprite = Resources.Load<Sprite>($"UISprites/icon_0002");
                    break;
                case EnStageType.Event:
                    image.sprite = Resources.Load<Sprite>($"UISprites/icon_0002");
                    break;
                case EnStageType.Shop:
                    image.sprite = Resources.Load<Sprite>($"UISprites/icon_0002");
                    break;
                case EnStageType.Rest:
                    image.sprite = Resources.Load<Sprite>($"UISprites/icon_0003");
                    break;
            }
        }

        transform.GetComponent<Button>().onClick.AddListener(() =>
        {
            bool pass = false;
            for (int i = 0; i < Front.Count; i++)
            {
                if (Front[i].GetComponent<MapNode>().m_bIsSelected)
                {
                    pass = true;
                    break;
                }
            }

            if (Front.Count == 0 /*&& DataManager.Instance.RecentLayer == -1*/)
            {
                pass = true;
            }
            else if (this.layer == DataManager.Instance.RecentLayer)
            {
                Debug.Log("갈 수 없는 노드");
                return;
            }

            if (!pass) return;
            if (!m_bIsSelected)
            {
                m_bIsSelected = true;
                x.gameObject.SetActive(true);
                //해당 스테이지 셋팅 후, 기록
                DataManager.Instance.RecentLayer = this.layer;
                EventManager.Instance.OnEventSetNextStage(this.stageIndex, this, this.isBoss);
            }
            else
            {
                Debug.Log("Selected Node");
            }
        });

        StartCoroutine(MakeLines());
    }

    IEnumerator MakeLines()
    {
        yield return new WaitForSeconds(0.5f);
        if (Front.Count >= 1)
        {
            Vector2 direction = rect.position - Front[0].transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            lines.GetChild(0).GetComponent<RectTransform>().Rotate(new Vector3(0, 0, angle));
            lines.GetChild(0).gameObject.SetActive(true);
        }
        else
            lines.GetChild(0).gameObject.SetActive(false);

        if (Front.Count >= 2)
        {
            Vector2 direction = rect.position - Front[1].transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            lines.GetChild(1).GetComponent<RectTransform>().Rotate(new Vector3(0, 0, angle));
            lines.GetChild(1).gameObject.SetActive(true);
        }
        else
            lines.GetChild(1).gameObject.SetActive(false);

        if (Front.Count >= 3)
        {
            Vector2 direction = rect.position - Front[2].transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;//아래로 향해야해서 -90
            lines.GetChild(2).GetComponent<RectTransform>().Rotate(new Vector3(0, 0, angle));
            lines.GetChild(2).gameObject.SetActive(true);
        }
        else
            lines.GetChild(2).gameObject.SetActive(false);
    }
}
