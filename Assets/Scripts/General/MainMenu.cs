using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    public GameObject DirectorInicio;
    public List<GameObject> Rayos;



    public void Jugar()
    {
        DirectorInicio.GetComponent<PlayableDirector>().enabled=true;
        for (int i = 0; i < Rayos.Count; i++)
        {
            Rayos[i].SetActive(false);
        }
    }
    public void Salir()
    {
        Application.Quit();
    }

   
}
