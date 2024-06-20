using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaGM : MonoBehaviour
{
    public List<GameObject> InterruptoresRunas;
    int PuntosMaximos;
    int PuntosVan;
    public Desintegracion simbolo1;
    public void Start()
    {
        PuntosMaximos = InterruptoresRunas.Count;
    }
    public void SubirPunto()
    {
        PuntosVan++;
        if (PuntosMaximos<=PuntosVan)
        {
            Debug.Log("Quemarse Hechizo");
            simbolo1.Desintegrar();
        }
    }
}
