using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameChar
{
    private bool _isMouseClicked;
    private Camera _camera;
    private Vector3 _mousePosition;
    private GameManager _gameManager;
    private void Start()
    {
        _camera = Camera.main;
        _gameManager = GameManager.Instance;
        _gameManager.GameCharTracker.Add(this.gameObject, currentCell);
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
            Move(cellPosition);
        }

    }
}
