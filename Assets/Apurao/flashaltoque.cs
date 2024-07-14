using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class flashaltoque : MonoBehaviour
{
    Animator animFinal;
    public MangerGame GM_delJuego;
    AudioSource ManAudio;
    public  PlayableDirector directorActivado;
    // Start is called before the first frame update
    void Start()
    {
        ManAudio = GetComponent<AudioSource>();
        animFinal= this.GetComponent<Animator>();
    }

    public IEnumerator Secuencia(){
        yield return new WaitForSeconds(3.5f);
        animFinal.enabled= true;
        ManAudio.enabled = true;
        yield return new WaitForSeconds(0.9f);
        animFinal.enabled = false;
        directorActivado.enabled = true;
        GM_delJuego.ContadorPrendido = true;
        this.gameObject.GetComponent<Light>().enabled=false;

    }
}
