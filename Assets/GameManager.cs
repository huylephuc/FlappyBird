using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject startScreen;
    void Start()
    {
        mainMenu.SetActive(true);
        startScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        mainMenu.SetActive(false);
        startScreen.SetActive(true);
    }
}
