using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject market;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject unpause;
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
        mainMenu.SetActive(true);
        if (!GameManager.instance.DayTime)
        {
            background.texture = night;
        }
        else 
            background.texture = day;
    }

    private void SetMenuOnGameState(GameState state)
    {
        mainMenu.SetActive(state == GameState.MainMenu);
        market.SetActive(state == GameState.Market);
        startScreen.SetActive(state == GameState.StandBy);
        endScreen.SetActive(state == GameState.EndGame);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        GameManager.instance.UpdateGameState(GameState.MainMenu);
        if (GameManager.instance.DayTime)
        {
            GameManager.instance.ChangeTime(GameTime.Night);
        }
        else
            GameManager.instance.ChangeTime(GameTime.Day);
    }

    public void PlayButton()
    {
        GameManager.instance.UpdateGameState(GameState.StandBy);
    }

    public void Skin()
    {
        GameManager.instance.UpdateGameState(GameState.Market);
    }

    public void Menu()
    {
        GameManager.instance.UpdateGameState(GameState.MainMenu);
    }
}
