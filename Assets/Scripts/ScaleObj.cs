﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleObj : MonoBehaviour
{
    public float scale;
    public GameObject model;
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public GameObject model4;
    public Slider mainSlider;
    
    private void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    public void changeScale(float newScale)
    {
        scale = newScale;
    }
    
    void Update()
    {
        
    }
    
    public void ValueChangeCheck()
    {
        model.transform.localScale = new Vector3(scale * 1.5f, scale * 1.5f, scale * 1.5f);
        model1.transform.localScale = new Vector3(scale * 2, scale * 2, scale * 2);
        model2.transform.localScale = new Vector3(scale * 0.1f, scale *0.1f, scale *0.1f);
        model3.transform.localScale = new Vector3(scale * 0.001f, scale * 0.001f, scale * 0.001f);
        model4.transform.localScale = new Vector3(scale * 100f, scale * 100f, scale * 100f);
    }
}

