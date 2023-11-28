using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject Layer;
    [SerializeField] GameObject Node;
    [SerializeField] Transform content;
    public CanvasController canvas;

    void OnEnable()
    {
        if (DataManager.Instance.RecentLayer == 0)
        {
            for (int i = 0; i < content.childCount; i++)
                Destroy(content.GetChild(i).gameObject);

            DataManager.Instance.ThisStage = DataManager.Instance.StageInfo[40001];

            DataManager.Instance.Layers = new List<Transform>();
            MakeLayers();

            DataManager.Instance.WholeNodes = new List<MapNode>();
            MakeNodes();
        }
    }

    void MakeLayers()
    {
        for (int i = 0; i < DataManager.Instance.ThisStage.act_max; i++)
        {
            Transform layer = Instantiate(Layer, content).transform;
            DataManager.Instance.Layers.Add(layer);
            layer.SetAsFirstSibling();
        }
    }

    void MakeNodes()
    {
        List<float> stageTypePick = new List<float>();

        stageTypePick.Add(DataManager.Instance.ThisStage.battle_per);
        stageTypePick.Add(DataManager.Instance.ThisStage.event_per);
        stageTypePick.Add(DataManager.Instance.ThisStage.shop_per);
        stageTypePick.Add(DataManager.Instance.ThisStage.rest_per);

        List<Transform> layers = DataManager.Instance.Layers;

        for (int i = 0; i < layers.Count - 1; i++)
        {
            int nodeCount = Random.Range(2, 5);
            for (int j = 0; j < nodeCount; j++)
            {
                MapNode newNode = Instantiate(Node, DataManager.Instance.Layers[i].transform).GetComponent<MapNode>();
                DataManager.Instance.WholeNodes.Add(newNode);

                if (i > 0)
                {
                    if (nodeCount == 2)
                    {
                        if (layers[i - 1].childCount == 2)
                        {
                            if (j < layers[i - 1].childCount)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(j));
                            }
                            if (j + 1 < layers[i - 1].childCount)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(j + 1));
                            }
                        }

                        if (layers[i - 1].childCount == 4)
                        {
                            if (j == 0)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(0));
                                newNode.Front.Add(layers[i - 1].GetChild(1));
                            }
                            if (j == 1)
                            {
                                newNode.Front.Add(layers[i - 1].GetChild(2));
                                newNode.Front.Add(layers[i - 1].GetChild(3));
                            }
                        }
                    }
                    else if (nodeCount == 4)
                    {
                        if (j < 2)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(0));
                        }
                        else
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(1));
                        }
                    }
                    else if (nodeCount < layers[i - 1].childCount)
                    {
                        if (j < layers[i - 1].childCount)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j));
                        }
                        if (j + 1 < layers[i - 1].childCount)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j + 1));
                        }
                    }
                    else if (nodeCount >= layers[i - 1].childCount)
                    {
                        if (j < layers[i - 1].childCount)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j));
                        }
                        if (j - 1 > 0)
                        {
                            newNode.Front.Add(layers[i - 1].GetChild(j - 1));
                        }
                    }
                }
                newNode.SetData((EnStageType)WeightedRandom.Picker(stageTypePick), DataManager.Instance.ThisStage.index, DataManager.Instance.ThisStage.act_max);
                newNode.canvas = canvas;
            }
        }

        MapNode boss = Instantiate(Node, DataManager.Instance.Layers[layers.Count - 1].transform).GetComponent<MapNode>();
        DataManager.Instance.WholeNodes.Add(boss);
        boss.SetData(EnStageType.Normal, DataManager.Instance.ThisStage.index, DataManager.Instance.ThisStage.act_max, true);
        boss.canvas = canvas;

        for (int i = 0; i < DataManager.Instance.Layers[layers.Count - 2].transform.childCount; i++)
        {
            boss.Front.Add(DataManager.Instance.Layers[layers.Count - 2].transform.GetChild(i));
        }
    }
}
