using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class MenuScript : MonoBehaviour
{
    private GameObject _menu;
    private DateTime _lastTimeOpened;
    private DateTime _lastTimeClosed;
    //the amount of time that needs to have passed before the menu can be closed or opened again via key input
    private int _deltaMilliseconds = 500;

    // Start is called before the first frame update
    void Start()
    {
        _menu = GameObject.Find("PauseMenu");
        _menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            //opening / closing the menu if the time set in _deltaMilliseconds has passed since the last opening / closing
            if(!_menu.activeSelf)
            {
                if(_lastTimeClosed.AddMilliseconds(_deltaMilliseconds) < System.DateTime.Now)
                {
                    _menu.SetActive(true);
                    Time.timeScale = 0;
                    
                    //setting the time when the menu got opened
                    _lastTimeOpened = System.DateTime.Now;
                }
            }
            else if(_lastTimeOpened.AddMilliseconds(_deltaMilliseconds) < System.DateTime.Now)
            {
                _lastTimeClosed = System.DateTime.Now;
                Return();
            }
        }
    }

    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Return(){
        Time.timeScale = 1;
        _menu.SetActive(false);
    }
}
