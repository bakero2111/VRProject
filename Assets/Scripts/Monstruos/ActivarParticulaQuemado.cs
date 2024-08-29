using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarParticulaQuemado : MonoBehaviour
{
    public GameObject ParticulaQuemadoActivar;

    public void ActivarPartic()
    {
        ParticulaQuemadoActivar.SetActive(true);
    }
}
