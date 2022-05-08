using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Grid _grid;
    private Vector3Int _myCell;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _grid = FindObjectOfType<Grid>();
        _myCell = _grid.WorldToCell(this.transform.position);
        _gameManager = GameManager.Instance;
        _gameManager.GameCharTracker.Add(this.gameObject, _myCell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveEnemy(Vector3Int cell)
    {
        var cellCenter = _grid.GetCellCenterWorld(cell);
        transform.position = cellCenter;

        _gameManager.GameCharTracker.Add(this.gameObject, cell);
    }
}
