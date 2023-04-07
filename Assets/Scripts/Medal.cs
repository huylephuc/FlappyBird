using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    private Image img;
    [SerializeField] private Sprite copper;
    [SerializeField] private Sprite silver;
    [SerializeField] private Sprite gold;
    [SerializeField] private ScoreManager score;

    private void Start()
    {
        img = GetComponentInParent<Image>();
        int gameScore = score.GetScore();
        if (gameScore == 0)
        {
            img.enabled = false;
        }
        if (gameScore > 0 && gameScore <= 5)
        {
            img.sprite = copper;
        }
        if (gameScore > 5 && gameScore <= 20)
        {
            img.sprite = silver;
        }
        if (gameScore > 20)
        {
            img.sprite = gold;
        }
    }
}
