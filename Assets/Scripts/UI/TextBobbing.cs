using UnityEngine;

public class TextBobbing : MonoBehaviour
{
    public float verticalBobbingAmount = 0.1f;
    public float horizontalBobbingAmount = 0.1f;
    public float bobbingSpeed = 1f;
    public float updateInterval = 0.5f; // Update every 0.5 seconds

    private Vector3 _originalPosition;
    private float _timer = 0f;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        // Increment the timer
        _timer += Time.deltaTime;

        if (_timer < updateInterval) return;

        // Apply bobbing animation to the Y position of the text
        var newY = _originalPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * verticalBobbingAmount;

        // Apply bobbing animation to the X position of the text
        var newX = _originalPosition.x + Mathf.Cos(Time.time * bobbingSpeed) * horizontalBobbingAmount;

        transform.position = new Vector3(newX, newY, _originalPosition.z);

        // Reset the timer
        _timer = 0f;
    }
}