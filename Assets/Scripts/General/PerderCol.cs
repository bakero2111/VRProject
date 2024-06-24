using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PerderCol : MonoBehaviour
{
    public GameObject ObjMira;
    public GameObject JugadorCam;
    public GameObject JugadorTotal;
    public GameObject ManoMonster;
    public float VelGiro;
    public bool LlevarseSujeto;
    private void Update()
    {
        if (LlevarseSujeto)
            JugadorTotal.transform.parent = ManoMonster.transform;
    }
    public void Perder()
    {
        JugadorCam.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.PositionOnly;
        JugadorCam.transform.DORotate(ObjMira.transform.position - JugadorCam.transform.position,VelGiro);
        
    }
    
}
