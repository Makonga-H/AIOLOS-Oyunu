using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthbar : MonoBehaviour
{
    static float health;
    public Slider slider;
    float puan�arpan�;
    public static float puan;
    private TextMeshProUGUI scorText;
    public GameObject healtbar;
    private float zaman;

    public void Start()
    {
        zaman = 0f;
        puan = 0f;
        health = slider.maxValue;
        scorText = healtbar.GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        zaman += Time.deltaTime;
        puan�arpan� = 20 - SpawnLightning.�lenK�yl�;
        if (zaman >1f)
        {
            puan += puan�arpan� * Time.deltaTime;
            zaman = 1;
        }
        slider.value = health - SpawnLightning.�lenK�yl�;
        scorText.text = puan.ToString();
       
    }

}
