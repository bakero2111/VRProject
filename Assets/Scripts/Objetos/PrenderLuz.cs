using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR;
using UnityEngine.InputSystem;

//using UnityEngine.InputSystem;
public class PrenderLuz : MonoBehaviour
{
    Animator _anim;
    InputDevice TargetDivice;
    public InputActionProperty ActivarLinternaCntrol;


    public GameObject ColLinterna;

    [Header("BateriaEstado")]
    bool Prendido;
    public float BateriaTotal;
    float BateriaPorcent;
    int intentos=0;
    public List<GameObject> Puntos = new List<GameObject>();

    Material Colorrender;
    public Color RojoVino;
    public Color VerdeEsperanza;
    public float IntensidadHDR;
    
    private void Start()
    {
        _anim = this.GetComponent<Animator>();
        BateriaPorcent = BateriaTotal;
        for (intentos = 0; intentos < Puntos.Count; intentos++)
        {
            Colorrender = Puntos[intentos].GetComponent<MeshRenderer>().material;
            Colorrender.SetColor("_Color", VerdeEsperanza);
            Colorrender.EnableKeyword("_EMISSION");
            Vector4 colorHDR = new Vector4(VerdeEsperanza.r * IntensidadHDR, VerdeEsperanza.g * IntensidadHDR, VerdeEsperanza.b * IntensidadHDR, VerdeEsperanza.a);
            Colorrender.SetColor("_EmissionColor", colorHDR);
        }
    }
    
    /*
     * trigger es float
     * boton grab es 
    */
    private void FixedUpdate()
    {
         // Verifica si se presiona cualquier botón del teclado o controlador
       
        if (Prendido)
        {
            BateriaPorcent -= Time.deltaTime;
            if(BateriaPorcent< BateriaTotal * 0.75f)
            {
                Colorrender = Puntos[0].GetComponent<MeshRenderer>().material;
                Colorrender.SetColor("_Color", RojoVino);
                Colorrender.EnableKeyword("_EMISSION");
                Vector4 colorHDR = new Vector4(RojoVino.r * IntensidadHDR, RojoVino.g * IntensidadHDR, RojoVino.b * IntensidadHDR, RojoVino.a);
                Colorrender.SetColor("_EmissionColor", colorHDR);
            }
            if (BateriaPorcent < BateriaTotal * 0.5f)
            {
                Colorrender = Puntos[1].GetComponent<MeshRenderer>().material;
                Colorrender.SetColor("_Color", RojoVino);
                Colorrender.EnableKeyword("_EMISSION");
                Vector4 colorHDR = new Vector4(RojoVino.r * IntensidadHDR, RojoVino.g * IntensidadHDR, RojoVino.b * IntensidadHDR, RojoVino.a);
                Colorrender.SetColor("_EmissionColor", colorHDR);
            }
            if (BateriaPorcent < BateriaTotal * 0.25f)
            {
                Colorrender = Puntos[2].GetComponent<MeshRenderer>().material;
                Colorrender.SetColor("_Color", RojoVino);
                Colorrender.EnableKeyword("_EMISSION");
                Vector4 colorHDR = new Vector4(RojoVino.r * IntensidadHDR, RojoVino.g * IntensidadHDR, RojoVino.b * IntensidadHDR, RojoVino.a);
                Colorrender.SetColor("_EmissionColor", colorHDR);
            }
            if (BateriaPorcent < BateriaTotal * 0.05f)
            {
                Colorrender = Puntos[3].GetComponent<MeshRenderer>().material;
                Colorrender.SetColor("_Color", RojoVino);
                Colorrender.EnableKeyword("_EMISSION");
                Vector4 colorHDR = new Vector4(RojoVino.r * IntensidadHDR, RojoVino.g * IntensidadHDR, RojoVino.b * IntensidadHDR, RojoVino.a);
                Colorrender.SetColor("_EmissionColor", colorHDR);
            }
        }
        
    }

    public void AgregarBateria()
    {
        BateriaPorcent = BateriaTotal;
        for(intentos = 0; intentos < Puntos.Count; intentos++)
        {
            Colorrender = Puntos[intentos].GetComponent<MeshRenderer>().material;
            Colorrender.SetColor("_Color", VerdeEsperanza);
            Colorrender.EnableKeyword("_EMISSION");
            Vector4 colorHDR = new Vector4(VerdeEsperanza.r * IntensidadHDR, VerdeEsperanza.g * IntensidadHDR, VerdeEsperanza.b * IntensidadHDR, VerdeEsperanza.a);
            Colorrender.SetColor("_EmissionColor", colorHDR);
        }
    }
    public void PrenderLinterna()
    {
        /*
        TargetDivice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        {
            if (triggerValue > 0.1f)
            {
                ColLinterna.SetActive(true);
            }

        }
        */
        /*
        float triggerValue = ActivarLinternaCntrol.action.ReadValue<float>();
        if (triggerValue >= 0.1f)
        {
            ColLinterna.SetActive(true);
            Prendido = true;
        }
        else if(triggerValue < 0.1f&&Prendido)
        {
            
            _anim.SetTrigger("Apagar");
            StartCoroutine(LinternaApagadoNum());
        }
        */
        //
        
       // float triggerValue2d = ActivarLinternaCntrol.action.ReadValue<float>();
        /*
        if (triggerValue)
        {
            ColLinterna.SetActive(true);
            Prendido = true;
        }
        else if(!triggerValue&&Prendido)
        {
            
            _anim.SetTrigger("Apagar");
            StartCoroutine(LinternaApagadoNum());
        }
        */
        float triggerValue = ActivarLinternaCntrol.action.ReadValue<float>();
        if (triggerValue >= 0.1f)
        {
            ColLinterna.SetActive(true);
            Prendido = true;
        }
        else if(triggerValue < 0.1f&&Prendido)
        {
            
            _anim.SetTrigger("Apagar");
            StartCoroutine(LinternaApagadoNum());
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && BateriaPorcent >0)
        {
            ColLinterna.SetActive(true);
            Prendido = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ColLinterna.SetActive(false);
            Prendido = false;
        }
        */
    }
    public void ApagarLinterna()
    {
        ColLinterna.SetActive(false);
        Prendido = false;
    }
    IEnumerator LinternaApagadoNum()
    {

        yield return new WaitForSeconds(0.2f);
        ColLinterna.SetActive(false);
        Prendido = false;
    }
}
