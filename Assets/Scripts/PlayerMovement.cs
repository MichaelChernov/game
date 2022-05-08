using System;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private bool _isMouseClicked;
    private Camera _camera;
    private Vector3 _mousePosition;
    private Grid _grid;
    private Vector3Int _myCell;
    private GameManager _gameManager;
    private PlayerEncounter _playerEncounter;
    public float xOffset;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _grid = FindObjectOfType<Grid>();
        _myCell = _grid.WorldToCell(this.transform.position);
        _gameManager = GameManager.Instance;
        _gameManager.GameCharTracker.Add(this.gameObject, _myCell);
        _playerEncounter = GetComponent<PlayerEncounter>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        
        _isMouseClicked = true;
        _mousePosition = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        if (!_isMouseClicked) return;
        
        _isMouseClicked = false;
        
        _mousePosition.z = -_camera.transform.position.z; //inverted camera Z position
        
        var mouseWorldPosition = _camera.ScreenToWorldPoint(_mousePosition);
        
        var cellPosition = _grid.WorldToCell(mouseWorldPosition);

        _myCell = _grid.WorldToCell(this.transform.position);

        if (IsAdjacent(_myCell, cellPosition))
        {
            MovePlayer(cellPosition);
        }

    }

    private void MovePlayer(Vector3Int cell)
    {
        var cellCenter = _grid.GetCellCenterWorld(cell);
        transform.position = cellCenter;

        _gameManager.GameCharTracker[this.gameObject] = cell;

        var charsInCell = _gameManager.CharsInCell(cell);

        if (charsInCell != null)
        {
            foreach (var gameChar in charsInCell)
            {
                if (gameChar != this.gameObject)
                {
                    cellCenter.x += xOffset;
                    this.transform.position = cellCenter;
                    EnterEncounter(gameChar.GetComponent<EnemyEncounter>());
                }
            }
        }
    }
    
    //BUG: fix being able to move to a diagonal non adjacent tile 
    private static bool IsAdjacent(Vector3Int cell1, Vector3Int cell2)
    {
        return Math.Abs(cell1.x - cell2.x) <= 1 && Math.Abs(cell1.y - cell2.y) <= 1;
    }

    private void EnterEncounter(EnemyEncounter enemy)
    {
        _playerEncounter.enabled = true;
        _playerEncounter.enemy = enemy;
        this.enabled = false;
    }
}
