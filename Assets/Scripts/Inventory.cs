using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, ITake
{
    public List<Sprite> sprites = new List<Sprite>();

    public List<item> items = new List<item>();

    public List<Transform> cells = new List<Transform>();

  
    private void Start()
    {
        foreach(Transform it in transform.GetChild(1))
        {
            cells.Add(it);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//по нажатие на кнопки включаем и выключаем инвентарь
        {
            foreach (Transform item in transform)
            {
                if (item.gameObject.activeSelf) item.gameObject.SetActive(false);
                else item.gameObject.SetActive(true);
            }
        }
    }
    public void Add(int index, int counts)//добавляем подобранные прдмет в инвентарь
    {
        items.Add(new item { sprite = sprites[index], count = counts });
        UpdateCellsInf();
    }
    public void UpdateCellsInf()//обнолвяем ячейки в инвентаре
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].mycell = cells[i];
            items[i].mycell.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].count.ToString();
            items[i].mycell.GetChild(0).GetComponent<Image>().sprite = items[i].sprite;

            //enable
            items[i].mycell.GetChild(1).gameObject.SetActive(true);
            items[i].mycell.GetChild(0).gameObject.SetActive(true);
        }
    }
}
public interface ITake
{
     void Add(int index, int counts);
}
[System.Serializable]
public class item
{
    public Sprite sprite;
    public int count;
    public Transform mycell;
}
