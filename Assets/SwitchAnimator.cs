using System;
using UnityEngine;

public class SwitchAnimator : MonoBehaviour
{
    [SerializeField] GameObject yellowBird;
    [SerializeField] GameObject blueBird;
    [SerializeField] GameObject redBird;
    private Animator player;

    private void OnEnable()
    {
        GameManager.OnUnitChanged += SetUnitColor;
    }

    private void OnDestroy()
    {
        GameManager.OnUnitChanged -= SetUnitColor;
    }

    private void Start()
    {
        player = Player.FindObjectOfType<Animator>();
        if (GameManager.instance.IsBlue)
        {
            player.SetBool("IsBlue", true);
        }
        if (GameManager.instance.IsRed)
        {
            player.SetBool("IsRed", true);
        }
    }

    private void SetUnitColor(Color color)
    {
        yellowBird.SetActive(color == Color.Yellow);
        blueBird.SetActive(color == Color.Blue);
        redBird.SetActive(color == Color.Red);
    }
    public void ChangeYellowBird()
    {
        GameManager.instance.ChangeColor(Color.Yellow);
        player.SetBool("IsBlue", false);
        player.SetBool("IsRed", false);
    }

    public void ChangeBlueBird()
    {
        GameManager.instance.ChangeColor(Color.Blue);
        player.SetBool("IsBlue", true);
        player.SetBool("IsRed", false);
    }

    public void ChangeRedBird()
    {
        GameManager.instance.ChangeColor(Color.Red);
        player.SetBool("IsBlue", false);
        player.SetBool("IsRed", true);
    }
}
