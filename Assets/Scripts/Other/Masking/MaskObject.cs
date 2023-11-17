using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    public int renderQueue = 3002;
    
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<SpriteRenderer>().material.renderQueue = renderQueue;
    }
}
