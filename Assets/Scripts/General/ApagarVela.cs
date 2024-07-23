using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarVela : MonoBehaviour
{
    public GameObject _FuegoParticulas;
    public Animator _Luz;

    public void ApagarVelaAnim()
    {
        _Luz.SetTrigger("Apagar");
        _FuegoParticulas.GetComponent<Animator>().enabled = true;
    }
    public IEnumerator SecuenciaApagar()
    {
        ApagarVelaAnim();
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        _Luz.gameObject.SetActive(false);
        _FuegoParticulas.SetActive(false);
    }
}
