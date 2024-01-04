using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;                         // Creating an instance of the GameManager to allow global access
    [SerializeField] private PlayerController player;           // Reference to the PlayerController
    [SerializeField] private Inventory inventory;               // Reference to the Inventory
    [SerializeField] private GameObject completeUI;             // UI object to display when the game is completed
    [SerializeField] public int itemCount;
    [SerializeField] private int timeToWait = 10;               // Time to wait before performing actions

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (instance == null)
        {
            // Set the instance to this GameManager if it doesn't exist
            instance = this;
        }
        else if (instance != this)
        {
            // Destroy any GameManager instance that is not this one
            Destroy(gameObject);
        }
    }

    public void UpdatetemCount()
    {
        itemCount++;
    }

    public void PrepareGameComplete()
    {
        player.enabled = false;
        StartCoroutine(GameComplete());
    }

    public IEnumerator GameComplete()
    {
        yield return new WaitForSeconds(timeToWait);
        completeUI.SetActive(true);
        StartCoroutine(QuitGame());


    }
    public IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(timeToWait);
        Application.Quit();
    }

}
