using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    

    //3 lives - 3 images (0,1,2)
    //2 lives - 2 images (0,1,[3]
    //1 life - 1 image (0,[1],[2])
    //0 lives - 0 images ([0],[1],[2]) - Lose 

    public void LooseLife()
    {
        //Decrease the value of livesRemaining
        livesRemaining--;
        //Hide one of the life images
        lives[livesRemaining].enabled = false;

        //If out of lives loose the game
        if (livesRemaining == 0)
        {
            Debug.Log("You Lose!");
            FindObjectOfType<LevelController>().Restart();
        }
    }

    void OnMouseUp()
    {
        LooseLife();
    }
}
