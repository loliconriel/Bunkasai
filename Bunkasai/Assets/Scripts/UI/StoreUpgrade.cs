using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUpgrade : MonoBehaviour
{

    [SerializeField]
    Sprite[] image;
    [SerializeField]
    int[] UpgradeAmount;
    int NowLevel = 0;
    TextMeshProUGUI text;
    Button button;
    private void OnEnable()
    {

        NowLevel = GameManager.GetUpgrade(transform.GetSiblingIndex());
        
        if (NowLevel == -1)gameObject.SetActive(false);
        else
        {
            if (image.Length > 0) GetComponentInChildren<Image>().sprite = image[NowLevel];
            if (button == null)
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(Upgrade);
            }
            if (text == null)
            {
                text = GetComponentInChildren<TextMeshProUGUI>();
                if (image.Length > 0 && NowLevel >= image.Length - 1) text.text = "Lv.MAX";
                else text.text = "Lv." + NowLevel + " $" + UpgradeAmount[NowLevel];
            }
        }
        
            
    }
    void Upgrade()
    {
        if(NowLevel < image.Length-1)
        {
            if (GameManager.GetMoeny() >= UpgradeAmount[NowLevel])
            {
                GameManager.MinusMoney(UpgradeAmount[NowLevel]);
                GameManager.Upgrade(transform.GetSiblingIndex());
                NowLevel++;
                GetComponentInChildren<Image>().sprite = image[NowLevel];
                if (NowLevel >= image.Length-1) text.text = "Lv.MAX";
                else text.text = "Lv." + NowLevel + " $" + UpgradeAmount[NowLevel];
            }
        }
        
    }
}
