using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    public Sprite[] ownerSprite = new Sprite[3];

    /* public void UpdateTileSpriteContinuously()
    {
        if (owner == TileManager.Owner.Sword)
        {
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[1];
            // Debug.Log("Test Sword");
        }

        else if (owner == TileManager.Owner.Shield)
        {
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[2];
            // Debug.Log("Test Shield");
        }

        else if (owner == TileManager.Owner.None)
        {
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[0];
            // Debug.Log("Test None");
        }
    }
    */

    private void OnMouseUp()
    {
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        if (owner == TileManager.Owner.Sword)
        {
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[1];
            // Debug.Log("Test Sword");
        }
            
        else if (owner == TileManager.Owner.Shield)
        {
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[2];
            // Debug.Log("Test Shield");
        }
            
        else if (owner == TileManager.Owner.None)
        {
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[0];
            // Debug.Log("Test None");
        }

        // Debug.Log("N/A");

        // Update to the next player in rotation
        tileManager.ChangePlayer();
    }

    public void ResetTile(int tileNumber)
    {
        Debug.Log("Tile number " + tileNumber + " has been reset.");
        owner = TileManager.Owner.None;
        this.GetComponent<SpriteRenderer>().sprite = ownerSprite[0];
    }
}
