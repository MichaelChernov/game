using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cultures
{
    Roman,
    Nordic,
    Germanic,
    Gaelic
}
public class Faction : MonoBehaviour
{
    public GameCell capitalCell { get; set; }
    public Cultures primaryCulture { get; set; }
}
