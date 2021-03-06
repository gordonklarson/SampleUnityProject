﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TicTacToeGame : Game
{
    /// <summary>
    /// UI object to set default focus to.
    /// </summary>
    [SerializeField]
    private GameObject defaultFocus;

    /// <summary>
    /// Array of Button objects representing the grid
    /// </summary>
    [SerializeField]
    private Button[] buttons;

    /// <summary>
    /// Array of Text objects overlayed over each grid button
    /// </summary>
    [SerializeField]
    private Text[] ButtonTextArray;

    /// <summary>
    /// UI text displaying who's turn it currently is.
    /// </summary>
    [SerializeField]
    private Text playerTurnText;


    /// <summary>
    /// Object to activate when the human player  wins the game.
    /// </summary>
    [SerializeField]
    private GameObject winScreen;

    /// <summary>
    /// Array representing the board state. 0 = empty grid, 1 = 'X', 2 = 'O'
    /// </summary>
    private int[] board = new int[9] {0,0,0,
                                      0,0,0,
                                      0,0,0};

    /// <summary>
    /// Is it currently the human player's turn
    /// </summary>
    private bool isPlayerTurn = true;

    public override void OnEnable()
    {
        base.OnEnable();
        EventSystem.current.SetSelectedGameObject(defaultFocus, null);
        
    }

    public void Start()
    {
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", 2.0f);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            EventSystem.current.SetSelectedGameObject(defaultFocus, null);
        }
    }

    /// <summary>
    /// Called when the player selects a grid
    /// </summary>
    /// <param name="index">Index of the grid selected by the player</param>
    public void OnButtonClick(int index)
    {
        if (board[index] == 0)
        {
            board[index] = 1;
            if (CheckForWin())
            {
                GameOver();
            }
            else
            {
                SetPlayerTurn(false);
                StartCoroutine(CPUTurn());
            }
        }
    }

    /// <summary>
    /// Process the computer controlled players turn.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CPUTurn()
    {
        bool choiceMade = false;
        int choice;
        playerTurnText.text = "Opponent";
        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        do
        {
            choice = Random.Range(0, 9);
            if (board[choice] == 0)
            {
                board[choice] = 2;
                ButtonTextArray[choice].text = "O";
                choiceMade = true;
            }
        } while (!choiceMade);

        if (CheckForWin())
        {
            GameOver();
        }
        else
        {
            SetPlayerTurn(true);
        }
    }

    /// <summary>
    /// Set whether it is currently the human player's turn or not.
    /// </summary>
    /// <param name="switchToPlayer">True if it is the human player's turn, false otherwise.</param>
    private void SetPlayerTurn(bool switchToPlayer)
    {
        isPlayerTurn = switchToPlayer;

        if (isPlayerTurn)
        {
            playerTurnText.text = "Player";
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = switchToPlayer;
        }
        EventSystem.current.SetSelectedGameObject(defaultFocus, null);
    }

    /// <summary>
    /// Check if a player has won the game
    /// </summary>
    /// <returns>true if the game has been won, false otherwise</returns>
    private bool CheckForWin()
    {
        bool win = false;

        //Check diaganols
        if (board[0] + board[4] + board[8] > 0)
        {
            win |= board[0] == board[4] && board[0] == board[8];
        }

        if (!win && board[2] + board[4] + board[6] > 0)
        {
            win |= board[2] == board[4] && board[2] == board[6];
        }

        if (!win)
        {
            //CheckRows
            for (int i = 0; i < 3; i++)
            {
                //Check row
                if (board[i * 3] != 0)
                {
                    win |= board[i * 3] == board[i * 3 + 1] && board[i * 3] == board[i * 3 + 2];
                }
                //Check column
                if (board[i] != 0)
                {
                    win |= board[i] == board[i + 3] && board[i] == board[i + 6];
                }
            }
        }

        return win;
    }

    public override void SettingsKnobTurned(float amount)
    {
        imageEffectValue += amount;
        GameManager.Instance.GetScreenMaterial().SetFloat("_Strength", (Mathf.Cos(Mathf.Deg2Rad * imageEffectValue) + 1.0f));
    }

    public override void GameOver()
    {
        gameOver = true;
        gameAssets.SetActive(false);
        if (isPlayerTurn)
        {
            winScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(true);
        }

    }

    public override void Reset()
    {
        gameOver = false;
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        board = new[]
                {
                    0, 0, 0,
                    0, 0, 0,
                    0, 0, 0
                };

        for (int i = 0; i < ButtonTextArray.Length; i++)
        {
            ButtonTextArray[i].text = "";
        }

        SetPlayerTurn(true);
        gameAssets.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultFocus, null);
    }
}
