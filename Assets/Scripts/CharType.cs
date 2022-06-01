using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BasicType
{
    LightInfantry,
    HeavyInfantry,
    MediumInfantry,
    LightCavalry,
    HeavyCavalry,
    Chariots
}

public enum PrimaryWeapon
{
    Spear,
    Sword,
    Blunt,
    Bow,
    Thrown
}

public enum CharDirections
{
    Front,
    Back,
    FrontRight,
    FrontLeft,
    BackRight,
    BackLeft
}

public class CharType : MonoBehaviour
{
    public Dictionary<CharDirections, CharDirection> sideStats { get; set; }
    public float maxHealth { get; set; }
    public int maxMovementRange { get; set; }
    public int maxAttackRange { get; set; }
    public int minAttackRange { get; set; }

    public BasicType basicType { get; set; }
    public PrimaryWeapon primaryWeapon { get; set; }
    public string name { get; set; }

    public bool canCounterAttack { get; set; }
    public bool canDefend { get; set; }
    public bool canRetreat { get; set; }
    
    //maximum number of times a character can turn during a single turn
    public int maxTurn { get; set; }

    public float CalcCounterMultiplier(CharType enemy)
    {
        return 0f;
    }

}
