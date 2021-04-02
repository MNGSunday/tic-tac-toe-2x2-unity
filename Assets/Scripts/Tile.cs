using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    public Sprite[] ownerSprite = new Sprite[3];

    private void OnMouseUp()
    {
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        if (owner == TileManager.Owner.Sword)
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[1];
        else if (owner == TileManager.Owner.Shield)
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[2];
        else if (owner == TileManager.Owner.None)
            this.GetComponent<SpriteRenderer>().sprite = ownerSprite[0];

        // Update to the next player in rotation
        tileManager.ChangePlayer();
    }
}
