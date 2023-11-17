using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{    

    public float rotationSpeed = 10;
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

    // private void OnTriggerEnter(Collider other){
    //     if(other.gameObject.tag.Equals("Enemy")){
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //     }
    // }

    private void ProcessMovementShip()
    {
        var rotation = rotationSpeed * Input.GetAxis("Rotation") * Time.deltaTime;
        var thrust = thrustForce * Input.GetAxis("Thrust") * Time.deltaTime;
        Transform transform1;
        (transform1 = transform).Rotate(Vector3.forward, -rotation);
        
        _rigidbody.AddForce(transform1.right*thrust);
    }
}
