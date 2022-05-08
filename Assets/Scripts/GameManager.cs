using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    public Dictionary<GameObject, Vector3Int> GameCharTracker { get; set; }
    private List<GameObject> _charsInCell;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        GameCharTracker = new Dictionary<GameObject, Vector3Int>();
        _charsInCell = new List<GameObject>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
        
    }

    public List<GameObject> CharsInCell(Vector3Int cell)
    {
        _charsInCell.Clear();
        
        foreach (var gameChar in GameCharTracker.Keys)
        {
            if (GameCharTracker[gameChar] == cell)
            {

                _charsInCell.Add(gameChar);
            }
        }

        return _charsInCell.Count == 0 ? null : _charsInCell;
    }
}
