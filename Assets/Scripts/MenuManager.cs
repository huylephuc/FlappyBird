using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    private string sceneName;
    private void OnEnable()
    {
        GameManager.OnStateChange += SetMenuOnGameState; //subscribe event
    }

    private void OnDestroy()
    {
        GameManager.OnStateChange -= SetMenuOnGameState; //unsubscribe event
    }

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    private void SetMenuOnGameState(GameState state)
    {
        startScreen.SetActive(state == GameState.StandBy);
        endScreen.SetActive(state == GameState.EndGame);
    }

    public void Restart()
    {
        if (sceneName != "Night")
            SceneManager.LoadScene("Night");
        else SceneManager.LoadScene("Day");
    }
}
