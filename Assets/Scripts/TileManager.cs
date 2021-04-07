/*
Name: Marc Domingo
Student ID: 2346778
Chapman Email: mdomingo@chapman.edu
Course Number and Section: 236-03
Assignment: Project 6
This is my own work, and I did not cheat on this assignment.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The purpose of this script is to represent the concept of a game of Tic-Tac-Toe, and contains functions to simulate changing players and handles winning conditions along with "Quit" and "Reset" options.

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];

    public GameObject resetButton;
    public GameObject quitButton;

    public Text SwordPlayerScore;
    public Text ShieldPlayerScore;

    private int SwordScore = 0;
    private int ShieldScore = 0;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        won = false;
        CurrentPlayer = Owner.Sword;
    }

    /* private void Update()
    {
        for (int tileNum = 0; tileNum < 9; tileNum++)
        {
            Tiles[tileNum].UpdateTileSpriteContinuously();
        }
    }
    */

    public void ChangePlayer()
    {
        if (CheckForWinner())
        {
            resetButton.SetActive(true);
            quitButton.SetActive(true);

            if (CurrentPlayer == Owner.Sword)
            {
                SwordScore += 1;
                SwordPlayerScore.text = "Sword Player Score: " + SwordScore;
            }

            else if (CurrentPlayer == Owner.Shield)
            {
                ShieldScore += 1;
                ShieldPlayerScore.text = "Shield Player Score: " + ShieldScore;
            }

            return;
        }

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner()
    {
        // Horizontal Victories
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        // Vertical Victories
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        // Diagonal Victories
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            return true;
        }

        return false;
    }

    public void OnResetClick()
    {
        for (int tileNum = 0; tileNum < 9; tileNum++)
        {
            Tiles[tileNum].ResetTile(tileNum + 1);
        }

        resetButton.SetActive(false);
        quitButton.SetActive(false);
        won = false;
        CurrentPlayer = Owner.Sword;
        Debug.Log("The board has been reset. Sword player start!");
    }

    public void OnQuitClick()
    {
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        Debug.Log("The user has quit the application.");
        CurrentPlayer = Owner.None;
        Application.Quit();
    }
}
