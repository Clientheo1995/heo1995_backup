using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    //일반노드 크기 100 100 보스노드 크기 200 200
    EnStageType stageType;
    int stageIndex;
    int m_nMaxMonsterCount;
    public List<Transform> Front;
    public CanvasController canvas;
    bool m_bIsSelected;
    float sizeX;
    float sizeY;
    //[SerializeField] LineRenderer line;
    [SerializeField] RectTransform rect;
    [SerializeField] Transform lines;
    [SerializeField] Transform x;

    bool isBoss = false;
    //https://github.com/silverua/slay-the-spire-map-in-unity/blob/master/Assets/Scripts/Node.cs        

    public void SetData(EnStageType stageType, int stageIndex, int monsterMaxCount, bool isBoss = false)
    {
        this.stageType = stageType;
        this.stageIndex = stageIndex;
        this.isBoss = isBoss;

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
            if (Front.Count == 0 && DataManager.Instance.RecentLayer == 0)
            {
                pass = true;
            }

            if (!pass) return;
            if (!m_bIsSelected)
            {
                m_bIsSelected = true;
                //해당 스테이지 셋팅 후, 기록
                canvas.SetNextStage(stageIndex, this, true);
                canvas.OffPanel(EnUIPanel.StageSelect);
                canvas.OffPanel(EnUIPanel.MainMenu);
                canvas.OnPanel(EnUIPanel.Instance);
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
        //yield return null;
        yield return new WaitForSeconds(1f);
        //Canvas.ForceUpdateCanvases();
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
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            lines.GetChild(2).GetComponent<RectTransform>().Rotate(new Vector3(0, 0, angle));
            lines.GetChild(2).gameObject.SetActive(true);
        }
        else
            lines.GetChild(2).gameObject.SetActive(false);
    }
}
