using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//A regiment represents the smallest group of soldiers/fighters/characters.
//The regiment will have different visible names depending on the culture/type of AI fielding the regiment
//For example: romans will field a cohort, a group of bandits will be called a band and so on...
public class CharGroup : MonoBehaviour
{
    public  List<GameChar> chars { get; set; }
    public string name { get; set; }
    public GroupType groupType { get; set; }
    public Vector3Int cellPos { get; set; }

    public void Combat(CharGroup enemy)
    {
        return;
    }

    public bool Move(Vector3Int cell)
    {
        return false;
    }
    
}
