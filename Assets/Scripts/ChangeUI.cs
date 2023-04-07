using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeUi : MonoBehaviour
{
    [SerializeField] private List<GameObject> listFantomes;
    [SerializeField] private GameObject txtPcGommes;

    private int _nbFantomes;
    private int _nbPcGommes;

    private void ChangeTxt()
    {
    }

    private void Update()
    {
        if (_nbPcGommes != 0)
        { //Remplacer 0 par GameState.Instance.variable
            txtPcGommes.GetComponent<TMP_Text>().text = _nbPcGommes.ToString();
        }

        if (_nbFantomes != 0)
        {
            for (int i = 0; i < listFantomes.Count; i += 1)
            {
                if (i < _nbFantomes)
                {
                    listFantomes[i].SetActive(true);
                }
                else
                {
                    listFantomes[i].SetActive(false);
                }
            }
        }
    }
}
