using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DañoLuz : MonoBehaviour
{
    public Mov_Monst_1 Monster1;
    public float DanhoLuz;
    public float vida;
    public int tiempoFeddBack;
    public bool BajoLuz;
    public bool EnDanho = false;
    public Animator PersonajeHuesos;
    float VelGuardada;
    float VelCambiante;
    public AudioClip ScreamDmg;
    public AudioSource ParlanteScream;
    private void Start()
    {
        vida = DanhoLuz;
        VelGuardada=this.gameObject.GetComponent<NavMeshAgent>().speed;
        VelCambiante= VelGuardada;
    }
    private void Update()
    {
        if (vida<=0 && vida>=-1.5f && EnDanho ==false)
        {
            InvokeRepeating("IniciarDanho", 0, 0);

            EnDanho = true;
            BajoLuz=false;
        }
        if(BajoLuz&&!EnDanho)
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0.78f;
        }
        else if(BajoLuz&&EnDanho){
            this.gameObject.GetComponent<NavMeshAgent>().speed = VelGuardada+1.5f;
        }
        else if(!BajoLuz&&!EnDanho){
            this.gameObject.GetComponent<NavMeshAgent>().speed = VelGuardada;
        }
    }
    public void IniciarDanho()
    {
        Debug.Log("No Vida");
        ParlanteScream.PlayOneShot(ScreamDmg);
        PersonajeHuesos.SetTrigger("Stuneado");
        Monster1.DetenerBajoDaño(tiempoFeddBack);
        StartCoroutine(DanhoFeedBack(tiempoFeddBack));
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
    IEnumerator DanhoFeedBack(int tempo)
    {
        yield return new WaitForSeconds(tempo);
        vida = DanhoLuz;
        
        EnDanho = false;
       // this.GetComponent<CapsuleCollider>().enabled = true;
    }
}
