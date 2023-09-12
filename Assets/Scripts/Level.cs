using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public List<Weight> weights;

    public void AddWeight(Weight weight)
    {
        weights.Add(weight);

        if (weights.Count == 3)
        {
            CheckValid();
        }
    }

    void CheckValid()
    {
        if (weights[0].Id == weights[1].Id && weights[0].Id == weights[2].Id)
        {
            ClearList();
        }
        else 
        {
            RemoveFromList();
        }
    }

    private void ClearList()
    {
        if (weights.Count != 3) return;

        foreach (Weight weight in weights)
        {
            if (weight != null) weight.DesTroyGameObject();
            gameObjects.Remove(weight.gameObject);
            
        }
        weights.Clear();
        GameManager.Instance.CheckLevelUp();
    }

    private void RemoveFromList()
    {
        if (weights.Count != 3) return;

        foreach (Weight weight in weights)
        {
            if (weight != null) weight.ResetPos();
        }
        weights.Clear();
    }
}