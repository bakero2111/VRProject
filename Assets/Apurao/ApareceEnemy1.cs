using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceEnemy1 : MonoBehaviour
{
    public GameObject monster111;
    void Start(){
        StartCoroutine(Activarenemigo());
    }
    IEnumerator Activarenemigo(){
        yield return new WaitForSeconds(10);
        monster111.SetActive(true);
    }
}
