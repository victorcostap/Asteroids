using UnityEngine;

/// <summary>
/// Clamps the gameObject to the screen
/// </summary>
public class ScreenMovementClamp : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _screenBounds;
    private Vector2 _screenResolution;

    private void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("No main camera found.");
            return;
        }

        _screenResolution = new Vector2(Screen.width, Screen.height);
        _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height,
            _camera.transform.position.z));
    }

    private void Update()
    {
        if (!_screenResolution.Equals(new Vector2(Screen.width, Screen.height)))
        {
            _screenResolution = new Vector2(Screen.width, Screen.height);
            _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width,
                Screen.height,
                _camera.transform.position.z)); 
        }
        
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -_screenBounds.x, _screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -_screenBounds.y, _screenBounds.y);
        transform.position = viewPos;
    }
}
