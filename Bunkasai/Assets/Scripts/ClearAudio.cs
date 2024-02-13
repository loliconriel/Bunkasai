using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearAudio : MonoBehaviour
{
    public void Clear()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }
}
