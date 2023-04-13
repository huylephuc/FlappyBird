using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    private void OnEnable()
    {
        GameManager.OnStateChange += SetMenuOnGameState; //subscribe event
    }

    private void OnDestroy()
    {
        GameManager.OnStateChange -= SetMenuOnGameState; //unsubscribe event
    }

    private void SetMenuOnGameState(GameState state)
    {
        startScreen.SetActive(state == GameState.StandBy);
        endScreen.SetActive(state == GameState.EndGame);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Night");
    }
}
