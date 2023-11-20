using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles ship movement
/// </summary>
public class ShipMovement : MonoBehaviour
{    

    /// <summary>
    /// How fast the ship rotates
    /// </summary>
    public float rotationSpeed = 10;
    /// <summary>
    /// How fast the ship moves forward and backwards
    /// </summary>
    public float thrustForce = 5;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessMovementShip();
    }
    
    /// <summary>
    /// Gets the axis rotation and thrust and add forces to the ship accordingly
    /// </summary>
    private void ProcessMovementShip()
    {
        var rotation = rotationSpeed * Input.GetAxis("Rotation") * Time.deltaTime;
        var thrust = thrustForce * Input.GetAxis("Thrust") * Time.deltaTime;
        Transform transform1;
        (transform1 = transform).Rotate(Vector3.forward, -rotation);
        
        _rigidbody.AddForce(transform1.right*thrust);
    }
}
