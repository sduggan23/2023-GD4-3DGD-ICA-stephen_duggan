using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;                             // Creating an instance of the GameManger
    [SerializeField] private bool gameOver;
    [SerializeField] private Inventory inventory;
    [SerializeField] public int itemCount;

    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GameComplete()
    {
        Application.Quit();
        Debug.Log("Game over");
    }

    public void UpdatetemCount()
    {
        itemCount++;
        Debug.Log("Game manager item count: " + itemCount);
    }


}
