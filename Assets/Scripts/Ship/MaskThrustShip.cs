using System;
using UnityEngine;

/// <summary>
/// Handles masking ship thrust when the ship is stopped.
/// </summary>
public class MaskThrustShip : MonoBehaviour
{
    /// <summary>
    /// Object that masks the ship thrusters
    /// </summary>
    public GameObject mask;
    
    private void Start()
    {
        mask.SetActive(true);
    }

    private void Update()
    {
        //If ship is not moving, enable mask, if not, disable.
        mask.SetActive(Math.Abs(Input.GetAxis("Rotation")) +
                        Math.Abs(Input.GetAxis("Thrust")) == 0);
    }
}
