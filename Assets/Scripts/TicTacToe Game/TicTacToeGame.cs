using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TicTacToeGame : Game
{
    [SerializeField]
    private GameObject defaultFocus;

    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private Text[] ButtonTextArray;

    [SerializeField]
    private Text playerTurnText;

    private int[] board = new int[9] {0,0,0,
                                      0,0,0,
                                      0,0,0};
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

    public override void GameOver()
    {
        throw new System.NotImplementedException();
    }

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
}
