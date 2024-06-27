using System.Collections;
using UnityEngine;

public class PerderCol : MonoBehaviour
{
    
    public GameObject ObjMira;
    public GameObject ObjMira2;
    public GameObject JugadorCam;
    public float VelGiro;
    public GameObject CuartoBoss1;
    public GameObject CuartoBoss2;
    public void PerderMonster1()
    {
        StartCoroutine(TransicionCuarto1());
    }
    public void PerderMonster2()
    {
        StartCoroutine(TransicionCuarto2());
    }
    IEnumerator TransicionCuarto1()
    {

        yield return new WaitForSeconds(1.5f);
        CuartoBoss1.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        CuartoBoss1.SetActive(false);
    }
    IEnumerator TransicionCuarto2()
    {
        yield return new WaitForSeconds(1.5f);
        CuartoBoss2.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        CuartoBoss2.SetActive(false);
    }
}
