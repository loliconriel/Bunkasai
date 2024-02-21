using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Topping : MonoBehaviour
{
    [SerializeField]
    private GameObject Content;

    private GameObject TargetList;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(action);
        
    }
    private void action()
    {
        foreach (Transform item in TargetList.transform)
        {
            if (item.childCount == 1)
            {
                Transform Dish = item.GetChild(0).transform;
                bool Toppingcheck = true;
                foreach(Transform Topping in Dish.transform)
                {
                    if(Topping.name == Content.name + "(Clone)")
                    {
                        Toppingcheck = false;
                        break;
                    }
            }
                
                if (Toppingcheck)
                {
                    GameObject a = Instantiate(Content, Dish.transform);

                    Transform parentTransform = Dish.transform;

                    List<Transform> children = new List<Transform>();

                    for (int i = 0; i < parentTransform.childCount; i++)
                    {
                        Transform child = parentTransform.GetChild(i);
                        children.Add(child);
                    }

                    children.Sort((x, y) => x.name.CompareTo(y.name));

                    for (int i = 0; i < children.Count; i++)
                    {
                        children[i].SetSiblingIndex(i);
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }

            
        }
    }
    public void SetTargetList(GameObject Target)
    {
        this.TargetList = Target;
    }

}
