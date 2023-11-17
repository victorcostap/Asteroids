using UnityEngine;

public class TextBobbing : MonoBehaviour
{
    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 1f;

    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        // Apply bobbing animation to the Y position of the text
        var newY = _originalPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;
        transform.position = new Vector3(_originalPosition.x, newY, _originalPosition.z);
    }
}