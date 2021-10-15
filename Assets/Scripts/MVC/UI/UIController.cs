using UnityEngine;
using UnityEngine.Events;

public class UIController : BaseController<UIModel>
{
    public void DisplayShop(TowerSetData towerSet, Transform parent, UnityAction<TowerData> onClick)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            GameObject.Destroy(parent.GetChild(i).gameObject);
        }
        for (int i = 0; i < towerSet.towers.Count; i++)
        {
            GameObject g = GameObject.Instantiate(Model.towerIconPrefab, parent);
            g.GetComponent<TowerIconUI>().SetComponents(towerSet.towers[i], onClick);
        }

    }

}
