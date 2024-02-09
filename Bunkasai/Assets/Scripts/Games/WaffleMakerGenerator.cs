using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffleMakerGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject Content;
    [SerializeField]
    int ZeroAmount;
    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        foreach(Transform transform in transform)
        {
            Destroy(transform.gameObject);
        }
        for(int i = 0; i < GameManager.GetUpgrade(2) + ZeroAmount; i++)
        {
            RectTransform Maker = Instantiate(Content, transform).GetComponent<RectTransform>();
            if (i == 0)
            {
                Maker.anchorMin = new Vector2(0.05f, 0.05f);
                Maker.anchorMax = new Vector2(0.45f, 0.45f);
            }
            else if(i == 1)
            {
                Maker.anchorMin = new Vector2(0.55f, 0.05f);
                Maker.anchorMax = new Vector2(0.95f, 0.45f);
            }
            else if (i == 2)
            {
                Maker.anchorMin = new Vector2(0.05f, 0.55f);
                Maker.anchorMax = new Vector2(0.45f, 0.95f);
            }
            else
            {
                Maker.anchorMin = new Vector2(0.55f, 0.55f);
                Maker.anchorMax = new Vector2(0.95f, 0.95f);
            }
        }
    }
}
