using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyChoose : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI DifficultyDetail;
    [SerializeField] List<string> DifficultyDetailText;

    void Start()
    {
        GetComponent<TMP_Dropdown>().onValueChanged.AddListener(delegate
        {
            Change(GetComponent<TMP_Dropdown>().value);
        });
        Change(GetComponent<TMP_Dropdown>().value);
    }

    void Change(int Difficulty)
    {
        DifficultyDetail.text = DifficultyDetailText[Difficulty];
        GameManager.GameSetting(Difficulty);
    }
}
