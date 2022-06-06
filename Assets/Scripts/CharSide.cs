using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSide
{
    public bool canAttack { get; set; }
    public bool canDefend { get; set; }
    public float attackMultiplier { get; set; }
    public float defenseMultiplier { get; set; }
    public bool isPrimary { get; set; }
}
