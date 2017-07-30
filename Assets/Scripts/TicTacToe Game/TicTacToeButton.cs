using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeButton : MonoBehaviour
{

    [SerializeField]
    private Text text;

    public void OnClick()
    {
        text.text = "X";
    }
}
