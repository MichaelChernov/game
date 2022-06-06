using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameChar
{
    public GameObject tileHighlight;
    private bool _isMouseLeftPressed;
    private bool _isMouseRightPressed;
    private Camera _camera;
    private Vector3 _mousePosition;
    private GameManager _gameManager;
    
    [SerializeField]
    public GameChar selectedChar;
    private void Start()
    {
        _camera = Camera.main;
        _gameManager = GameManager.Instance;
        tile = GameTile.GetTile(this.transform.position);
        _isMouseLeftPressed = false;
        _isMouseRightPressed = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _isMouseLeftPressed = true;
        if (Input.GetButtonDown("Fire2"))
            _isMouseRightPressed = true;
        
        _mousePosition = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        if (!(_isMouseLeftPressed || _isMouseRightPressed)) return;

        _mousePosition.z = -_camera.transform.position.z; //inverted camera Z position
        
        var mouseWorldPosition = _camera.ScreenToWorldPoint(_mousePosition);

        var targetTile = GameTile.GetTile(mouseWorldPosition);

        if (!targetTile) return;

        if (_isMouseLeftPressed)
        {
            MouseSelect(targetTile);
        }
        
        if (_isMouseRightPressed && selectedChar)
        {
            MouseMove(targetTile);
        }
        
        _isMouseLeftPressed = false;
        _isMouseRightPressed = false;

    }

    private void MouseSelect(GameTile targetTile)
    {
        MoveTileHighlight(targetTile);
        
        //Change selected GameChar
        selectedChar = targetTile.gameChar;
    }
    
    //Action caused by right clicking the mouse to move a unit (not actually moving the mouse)
    private void MouseMove(GameTile targetTile)
    {
        if (!GameTile.IsAdjacent(tile, targetTile)) return;
        
        //Remove GameChar from tile
        tile.gameChar = null;
        
        selectedChar.gameObject.transform.position = targetTile.centerPos;
        tile = targetTile;
        tile.gameChar = selectedChar;

        MoveTileHighlight(targetTile);
        
        
    }

    private void MoveTileHighlight(GameTile targetTile)
    {
        tileHighlight.transform.position = targetTile.centerPos;
    }
}
