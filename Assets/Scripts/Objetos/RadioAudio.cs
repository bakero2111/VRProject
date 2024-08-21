using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    AudioSource EmisorSonido;
    public AudioClip TutorialSound;
    public GameObject HudRadio;
    public void PausarTutorial(){
        EmisorSonido.Pause();

    }
    public void ReiniciarTutorial(){
               EmisorSonido.PlayOneShot(TutorialSound);
    }
    public void ReanudarTutorial(){
        EmisorSonido.Play();
    }
    public void AparecerHUD(){
        HudRadio.SetActive(true);
    }
    public void DesaparecerHUD(){
        HudRadio.SetActive(false);
    }
}
