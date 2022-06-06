using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    public Vector3 centerPos { get; set; }
    public float defenseMultiplier { get; set; }
    public float attackMultiplier { get; set; }
    public string name { get; set; }
    public Cultures culture { get; set; }
    public Faction controllingFaction { get; set; }
    public GameChar gameChar { get; set; }

    private PolygonCollider2D _collider;

    private void Start()
    {
        _collider = this.GetComponent<PolygonCollider2D>();
        centerPos = transform.position;
    }

    public static GameTile GetTile(Vector2 position)
    {
        var hit = Physics2D.Raycast (position, Vector2.down);
        if (hit.collider != null && hit.collider.CompareTag("Terrain"))
        {
            return hit.collider.gameObject.GetComponent<GameTile>();
        }

        return null;
    }
    
    public static bool IsAdjacent(GameTile tile1, GameTile tile2)
    {
        var colliders = new List<Collider2D>();
        //Check tile collision: get max amount of collisions using a list
        var resultCount = tile1._collider.OverlapCollider(new ContactFilter2D().NoFilter(), colliders);

        if (resultCount == 0) return false;
        
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out GameTile colliderGameTile) && colliderGameTile == tile2)
            {
                return true;
            }
        }

        return false;
    }
}
