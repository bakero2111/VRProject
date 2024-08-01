
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public GameObject PantallaActivado;
    public GameObject PopUpButtonI;
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ActivarPopUp()
    {
        if (!PantallaActivado.activeSelf)
        {
            PantallaActivado.SetActive(true);
            PopUpButtonI.SetActive(false);
        }
    }
    public void CerrarPopUp()
    {
        if (PantallaActivado.activeSelf)
        {
            PantallaActivado.SetActive(false);
            PopUpButtonI.SetActive(true);
        }
    }

}
