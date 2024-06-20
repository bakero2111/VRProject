using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoLuz : MonoBehaviour
{
    public Mov_Monst_1 Monster1;
    public float DanhoLuz;
    public float vida;
    public int tiempoFeddBack;

    bool EnDaño = false;
    public Animator PersonajeHuesos;
    private void Start()
    {
        vida = DanhoLuz;
    }
    private void Update()
    {
        if (vida<=0&& vida>=-0.3f && EnDaño ==false)
        {
            InvokeRepeating("IniciarDaño", 0, 0);

            EnDaño = true;
        }
    }
    void IniciarDaño()
    {
        Debug.Log("No Vida");
        PersonajeHuesos.SetTrigger("Stuneado");
        Monster1.DetenerBajoDaño(tiempoFeddBack);
        StartCoroutine(DanhoFeedBack(tiempoFeddBack));
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
    IEnumerator DanhoFeedBack(int tempo)
    {
        yield return new WaitForSeconds(tempo);
        vida = DanhoLuz;
        EnDaño = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
}
