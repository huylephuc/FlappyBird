using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float x;

    private void Update()
    {
        if (GameManager.instance.GameEnd) return;
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(x, 0) * Time.deltaTime, rawImage.uvRect.size);
    }
}
