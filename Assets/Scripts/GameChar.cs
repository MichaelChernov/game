using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapDirections
{
    North,
    South,
    NorthEast,
    SouthEast,
    NorthWest,
    SouthWest
}


//The game character is the smallest possible unit in the game,
//comprised of a single character.
//For example: roman legionary, bandit and so on...
public class GameChar : MonoBehaviour
{
    //Represents the character's full unique name
    public string name { get; set; }
    
    public CharType charType { get; set; }
    public float health { get; set; }
    
    public GameTile tile { get; set; }

    private bool _isAttacking;

    private CharSide[] _sides;
    public MapDirections front { get; set; }
    
    private void Start()
    {
        tile = GameTile.GetTile(this.transform.position);
        tile.gameChar = this;
        
        _sides = new CharSide[6];
        _sides[0] = new CharSide();
        _sides[1] = new CharSide();
        _sides[2] = new CharSide();
        _sides[3] = new CharSide();
        _sides[4] = new CharSide();
        _sides[5] = new CharSide();
    }

    public void Attack(GameChar enemy)
    {
        float damage = 0;
        //main combat loop
        while (_isAttacking)
        {
            damage = this.charType.CalcCounterMultiplier(enemy.charType) * this.tile.attackMultiplier *
                     enemy.tile.defenseMultiplier;
            enemy.health -= damage;
            
            
        }
    }
}
