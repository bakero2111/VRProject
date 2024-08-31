using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject jugarB;
    public GameObject salirB;
    


    public void Jugar()
    {

    }
    public void Salir()
    {
        Application.Quit();
    }

    void OnCollisionEnter(Collision Presion)
    {
        if (Presion.gameObject.tag == "jugarB")
        {
            Jugar();
        }
        if (Presion.gameObject.tag == "salirB")
        {
            Salir();
        }
    }
}
