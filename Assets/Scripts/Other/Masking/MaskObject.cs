using UnityEngine;

/// <summary>
/// Sets render queue of the object to the specified value.
/// Useful when masking objects
/// </summary>
public class MaskObject : MonoBehaviour
{
    /// <summary>
    /// Render queue to assign to the object
    /// </summary>
    public int renderQueue = 3002;
    
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<SpriteRenderer>().material.renderQueue = renderQueue;
    }
}
