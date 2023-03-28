using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject pipePrefab;

    void Start()
    {
        mainMenu.SetActive(false);
        startScreen.SetActive(false);
        InvokeRepeating("SpawnPipe", 2f, 2f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        mainMenu.SetActive(false);
        startScreen.SetActive(true);
    }

    void SpawnPipe()
    {
        Instantiate(pipePrefab, pipePrefab.transform.position, Quaternion.identity);
    }
}
