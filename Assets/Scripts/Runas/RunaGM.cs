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
    public void OnEnable()
    {
        PuntosVan = 0;
        for (int i = 0; i < InterruptoresRunas.Count; i++)
        {
            InterruptoresRunas[i].SetActive(true);
        }
    }
    public void SubirPunto()
    {
        PuntosVan++;
        if (PuntosMaximos<=PuntosVan)
        {
            simbolo1.Desintegrar();
        }
    }
}
