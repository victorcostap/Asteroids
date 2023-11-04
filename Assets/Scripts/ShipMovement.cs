using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{    

    public float rotationSpeed = 10;
    public float thrustForce = 5;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = rotationSpeed * Input.GetAxis("Rotation") * Time.deltaTime;
        float thrust = thrustForce * Input.GetAxis("Thrust") * Time.deltaTime;
        transform.Rotate(Vector3.forward, -rotation);
        
        var cameraTransform = Camera.main.transform;
        _rigidbody.AddForce(transform.right*thrust);
    }

    private void OnCollisionEnter(Collision collider){
        if(collider.gameObject.tag.Equals("Enemy")){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
