using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI score;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else { 
            instance = this;
        
        }
    }
    public void OnPlayerHasLost()
    {
        Time.timeScale = 0;
        Debug.Log("You lost!");
    }
    
}
