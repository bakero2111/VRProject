using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerEjeZ : MonoBehaviour
{
    float EjeZ;
    bool Setear=false;
    public Transform Padre;
    // Start is called before the first frame update
    private void Start()
    {
        EjeZ = this.transform.localPosition.z;
    }
    // Update is called once per frame
    private void Update()
    {
       if (Setear)
        {
            // EjeZ = this.transform.localPosition.z;
            this.transform.parent = Padre.transform;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, EjeZ);

            Debug.Log("aseda");
            
        }
    }
    public void terminarMov()
    {
        if (Setear)
        {
            Setear = false;
        }
    }
    public void EnMovimientoaa()
    {
        if(!Setear)
        {
            
            Setear = true;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Runa/Objetivo")
        {
            Debug.Log("aaaaaaaaaaaaaa");
        }
    }
}
