using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashaltoque : MonoBehaviour
{
    Animator animFinal;
    // Start is called before the first frame update
    void Start()
    {
        animFinal= this.GetComponent<Animator>();
        StartCoroutine(Secuencia());
    }

    IEnumerator Secuencia(){
        yield return new WaitForSeconds(3.5f);
        animFinal.enabled= true;
        yield return new WaitForSeconds(0.9f);
        animFinal.enabled = false;
        this.gameObject.GetComponent<Light>().enabled=false;
    }
}
