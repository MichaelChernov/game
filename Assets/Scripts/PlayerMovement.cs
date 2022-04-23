using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public int maxRaycastHits;
    private bool _isMouseClicked;
    private Camera _camera;
    private Vector3 _mousePosition;
    private RaycastHit2D[] _hits;
    private Vector3 _playerPosition;
    private Grid _grid;

    private Tilemap _tilemap;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _hits = new RaycastHit2D[maxRaycastHits];
        _playerPosition = this.gameObject.transform.position;
        _tilemap = FindObjectOfType<Tilemap>();
        _grid = FindObjectOfType<Grid>();
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

        float invertedCameraZ = -_camera.transform.position.z;
        var mouseWorldPosition = _camera.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, invertedCameraZ));

        var cellPosition = _grid.WorldToCell(mouseWorldPosition);

        var cellCenter = _grid.GetCellCenterWorld(cellPosition);
        
        transform.position = cellCenter;
    } 
}
