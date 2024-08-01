using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBucleRuna : MonoBehaviour
{
    public GameObject Rune;
    public void OnEnable()
    {
        Rune.SetActive(true);
    }
}
