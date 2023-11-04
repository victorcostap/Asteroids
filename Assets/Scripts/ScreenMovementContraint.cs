﻿using UnityEngine;

public class ScreenMovementContraint : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _screenBounds;

    private float _objectWidth;
    private float _objectHeight;

    private void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("No main camera found.");
            return;
        }

        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;

        _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height,
            _camera.transform.position.z));
    }

    private void Update()
    {
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -_screenBounds.x, _screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -_screenBounds.y, _screenBounds.y);
        transform.position = viewPos;
    }
}
