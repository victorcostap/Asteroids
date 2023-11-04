using UnityEngine;

public class MatchScreenBg : MonoBehaviour
{
    private Vector2 _screenResolution;
    private Camera _camera;
    private float _objectWidth;
    private float _objectHeight;
    private float _aspectRatio;
    public Material material;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("No main camera found.");
            return;
        }

        if (!material.HasProperty("_MainTex"))
        {
            Debug.LogError("Material does nto have MainTex");
        }

        _screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_screenResolution.Equals(new Vector2(Screen.width, Screen.height))) return;
        
        MatchPlaneToScreenSize();
        _screenResolution.x = Screen.width;
        _screenResolution.y = Screen.height;
    }

    private void MatchPlaneToScreenSize()
    {
        var planeHeightScale = 2.0f * _camera.orthographicSize / 10.0f;
        var planeWidthScale = planeHeightScale * _camera.aspect;
        gameObject.transform.localScale = new Vector3(planeWidthScale, planeHeightScale, 1);
        material.SetTextureScale("_MainTex", new Vector2(planeWidthScale, planeHeightScale));
    }
}
