using System;
using UnityEngine;

public class MaskThrustShip : MonoBehaviour
{
    public GameObject mask;
    
    private void Start()
    {
        mask.SetActive(true);
    }

    private void Update()
    {
        mask.SetActive(Math.Abs(Input.GetAxis("Rotation")) +
                        Math.Abs(Input.GetAxis("Thrust")) == 0);
    }
}
