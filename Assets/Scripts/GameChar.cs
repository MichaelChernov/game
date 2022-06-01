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
    
    public GameCell currentCell { get; set; }

    private bool _isAttacking;
    private Grid _grid;

    private GameChar()
    {
        _grid = FindObjectOfType<Grid>();
        currentCell = _grid.WorldToCell(this.transform.position);
    }

    public void Attack(GameChar enemy)
    {
        float damage = 0;
        //main combat loop
        while (_isAttacking)
        {
            damage = this.charType.CalcCounterMultiplier(enemy.charType) * this.currentCell.attackMultiplier *
                     enemy.currentCell.defenseMultiplier;
            enemy.health -= damage;
            
            
        }
    }

    public void Move(Vector3Int cell)
    {
        var cellCenter = _grid.GetCellCenterWorld(cell);
        transform.position = cellCenter;

        this.transform.position = cellCenter;
    }
    
    //BUG: fix being able to move to a diagonal non adjacent tile 
    private static bool IsAdjacent(Vector3Int cell1, Vector3Int cell2)
    {
        return Math.Abs(cell1.x - cell2.x) <= 1 && Math.Abs(cell1.y - cell2.y) <= 1;
    }
}
