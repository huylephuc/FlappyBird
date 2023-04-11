using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    float updateTime = 1;
    bool enable = true;
    [SerializeField] TextMeshProUGUI fps;
    // Update is called once per frame
    private void Awake()
    {
        fps.gameObject.SetActive(enable);
    }
    void Update()
    {
        updateTime -= Time.deltaTime;
        if (updateTime <= 0)
        {
            updateTime = 1;
            fps.text = "FPS: " + ((int)(1 / Time.deltaTime)).ToString();
        }
    }
}
