using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaFeed : MonoBehaviour
{
    public GameObject ObjetivoFlecha;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.forward = ObjetivoFlecha.transform.position-this.transform.position;
    }
}
