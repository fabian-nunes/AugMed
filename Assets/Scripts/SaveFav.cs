﻿using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class SaveFav : MonoBehaviour
{
    public Button fav;
    public  String favBtn;

    public GameObject txt;
   // private user user = new user("dfsdf", "123@asda.com");
    private user user = auth.user;
    void Start()
    {
        Button btn =fav.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void TaskOnClick()
    {
        RestClient.Get<user>("https://augmed-b88b9-default-rtdb.firebaseio.com/"+user.userName+".json").Then(
            response =>
            {
                Debug.Log("Passed");
                user = response;
                user.toString();
                int rep = user.findFav(favBtn);
                if (rep == 0)
                {
                    ChangeImage();
                    Debug.Log("Adicionado");
                    user.setFav(favBtn);
                    user.toString();
                    RestClient.Put("https://augmed-b88b9-default-rtdb.firebaseio.com/"+user.userName+".json", user);   
                }
                else if (rep == 1)
                {
                    ChangeImage();
                    Debug.Log("Removido");
                    user.removeFav(favBtn);
                    user.toString();
                    RestClient.Put("https://augmed-b88b9-default-rtdb.firebaseio.com/"+user.userName+".json", user);  
                }
            });
    }

    private void OnEnable()
    {
        txt.SetActive(false);
        RestClient.Get<user>("https://augmed-b88b9-default-rtdb.firebaseio.com/" + user.userName + ".json").Then(
            response =>
            {
                Debug.Log("Passed");
                user = response;
                user.toString();
                int rep = user.findFav(favBtn);
                if (rep == 0)
                {
                    fav.image.sprite = OffSprite;

                }
                else if (rep == 1)
                {
                    fav.image.sprite = OnSprite;
                }
            });
    }

    private void OnDisable()
    {
        txt.SetActive(true);
    }

    public Sprite OffSprite;
    public Sprite OnSprite;
    public void ChangeImage(){
        if (fav.image.sprite == OnSprite)
            fav.image.sprite = OffSprite;
        else {
            fav.image.sprite = OnSprite;
        }
    }
}
