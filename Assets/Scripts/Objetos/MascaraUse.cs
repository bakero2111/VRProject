using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascaraUse : MonoBehaviour
{
    public GameObject PuntoCara;
    public float transicionEntrePosiciones;
    public float transicionEntreRotaciones;
    public bool EnArea;
    bool UsandoMascara;
    public void UbicarMascara()
    {
        if(EnArea&&!UsandoMascara)
        {

            this.GetComponent<Rigidbody>().useGravity = false;
            transform.parent = PuntoCara.transform;
            Quaternion rotalo = new Quaternion(0, 0, 0, 0);
            //quaternion rotalo = new quaternion(-90, 0, 0, 0);
            this.transform.DOMove(PuntoCara.transform.position, transicionEntrePosiciones);
            this.transform.DORotateQuaternion(rotalo, transicionEntreRotaciones)
            .OnComplete(() => this.transform.DOKill());
            this.GetComponent<MeshCollider>().enabled = false;
        }
        
        
    }
    public void SacarMascara()
    {
        if (UsandoMascara)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            transform.parent = null;
            this.GetComponent<MeshCollider>().enabled = true;
        }
    }
}
