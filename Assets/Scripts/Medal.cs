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

    private void Start()
    {
        img = GetComponentInParent<Image>();
        if (Player.Score == 0)
        {
            img.enabled = false;
        }
        if (Player.Score > 0 && Player.Score <= 5)
        {
            img.sprite = copper;
        }
        if (Player.Score > 5 && Player.Score <= 20)
        {
            img.sprite = silver;
        }
        if (Player.Score > 20)
        {
            img.sprite = gold;
        }
    }
}
