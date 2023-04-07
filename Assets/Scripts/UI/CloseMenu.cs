using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}
