using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private RawImage background;
    [SerializeField] private Texture2D day;
    [SerializeField] private Texture2D night;

    private void OnEnable() //subscribe event
    {
        GameManager.OnStateChange += SetMenuOnGameState; 
    }

    private void OnDestroy() //unsubscribe event
    {
        GameManager.OnStateChange -= SetMenuOnGameState;
    }

    private void Start()
    {
        if (!GameManager.instance.DayTime)
        {
            background.texture = day;
        }
        else 
            background.texture = night;
    }

    private void SetMenuOnGameState(GameState state)
    {
        startScreen.SetActive(state == GameState.StandBy);
        endScreen.SetActive(state == GameState.EndGame);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        GameManager.instance.UpdateGameState(GameState.StandBy);
        if (!GameManager.instance.DayTime)
        {
            GameManager.instance.ChangeTime(GameTime.Night);
        }
        else
            GameManager.instance.ChangeTime(GameTime.Day);
    }
}
