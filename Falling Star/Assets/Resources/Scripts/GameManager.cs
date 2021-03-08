using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float playerHealth;//The Players health.
    public GameObject player;//The Player Gameobject.

    public TMP_Text score;
    public TMP_Text winLoseText;

    [HideInInspector]
    public float playerScore;
    public bool playerWon = false;
 
    void Start()
    {
        playerHealth = 1;//At the start- Player health will equal 3.
        playerScore = 0;//At the start- Players score will be at 0.
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE: " + playerScore.ToString();//Changes the text to reflect Player score.
        winLoseText.text = "";//When the player has neither won or lost, the text says nothing.
        Debug.Log(winLoseText.text);

        if (playerHealth == 0)
        {
            Object.Destroy(player);//If the player hits zero, then they are destroyed.
            winLoseText.text = "GAME OVER";
        }

        if (playerWon== true)//If the playrWon boolean is true then-
        {
            winLoseText.text = "PLAYER WON!";//Display Player won text.
        }
    }
}
