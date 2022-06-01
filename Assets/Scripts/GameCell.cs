using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public Vector3Int centerPos { get; set; }
    public float defenseMultiplier { get; set; }
    public float attackMultiplier { get; set; }
    public string name { get; set; }
    public Cultures culture { get; set; }
    public Faction controllingFaction { get; set; }
}
