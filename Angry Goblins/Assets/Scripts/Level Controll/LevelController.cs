using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;

    Enemy[] _enemies;
    //Check to see how many Enemies there are 
    void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    //If all Enemies are all dead, go to Next Level
    void Update()
    {
        if (EnemiesAreAllDead())
            GoToNextLevel();
    }
    //Advance to next Level
    //Make sure to add Levels to scene build settings
    private void GoToNextLevel()
    {
        Debug.Log("Go To Level" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }
    //Checks to see if all Enemies are dead
    private bool EnemiesAreAllDead()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
