using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
