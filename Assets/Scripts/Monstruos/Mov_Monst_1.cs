using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class Mov_Monst_1 : MonoBehaviour
{
    NavMeshAgent _Nav_Monster1;
    public float AnimacioTiempo;
    public Animator PersonajeHuesos;

    //Rigidbody Rbd1;
    NavMeshPath Camino1;
    int _Estacion = 0; //el punto que se encuentra actualmente dentro del patron de vigilancia
    float distanciaPointo;//distancia del Monstruo al Punto
    int PatronNum=0;
    bool EnMovimiento = false;

    [Header("PatronesVigi")]
    public List<GameObject> Puntos;
    public List<GameObject> PuntosSegundo;
    public List<GameObject> PuntosTercero;
    public List<GameObject> PuntosCuarto;


    bool EnDanho=false;
    [Header("Secuencia")]
    public bool SecuenciaActv=false;
    public GameObject Segundo;
    
    // Start is called before the first frame update
    void Start()
    {
        _Nav_Monster1 = this.GetComponent<NavMeshAgent>();
        //veltotal = _Nav_Monster1.speed;
        //Rbd1 = this.GetComponent<Rigidbody>();
        Camino1 = new NavMeshPath();
        if(SecuenciaActv){
            StartCoroutine(SecuenciaEnemigos());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rbd1.MovePosition(Puntos[0].transform.position);
        //_Nav_Monster1.Move();
        if (!EnDanho)
        {
            ElegirPatron();
        }
            
        
    }
    public void ElegirPatron()
    {
        if(!EnMovimiento)
        {
            Camino1 = new NavMeshPath();
            PatronNum = (int)(Random.Range(1, 4));
            Debug.Log(PatronNum);

            //EnMovimiento = true;
        }
        switch (PatronNum)
        {
            case 1:
                
                PatronCamino1();
                break;
            case 2:
                PatronCamino2();
                break;
            case 3:
                PatronCamino3();
                break;
            case 4:
                PatronCamino4();
                break;
                
            default:
                if (!EnMovimiento)
                {
                    PatronNum = (int)(Random.Range(1, 4));
                    Debug.Log(PatronNum);
                }
                break;
                
        }
    }
    void PatronCamino1()
    {
        EnMovimiento = true;
        NavMesh.CalculatePath(this.transform.position, Puntos[_Estacion].transform.position, NavMesh.AllAreas, Camino1);
        _Nav_Monster1.SetPath(Camino1);
        
        distanciaPointo = Vector3.Distance(this.transform.position, Puntos[_Estacion].transform.position);
        if (distanciaPointo <= _Nav_Monster1.stoppingDistance * 2)
        {
            if (_Estacion == 0 || _Estacion < (Puntos.Count - 1))
            {
                _Estacion++;
                PatronCamino1();
            }
            else
            {
                
                Debug.Log("llego");
                StartCoroutine(MatarProtagonista());

            }

            if( _Estacion <2)
            {
                this.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

    }
    void PatronCamino2()
    {
        EnMovimiento = true;
        NavMesh.CalculatePath(this.transform.position, PuntosSegundo[_Estacion].transform.position, NavMesh.AllAreas, Camino1);
        _Nav_Monster1.SetPath(Camino1);
        distanciaPointo = Vector3.Distance(this.transform.position, PuntosSegundo[_Estacion].transform.position);
        if (distanciaPointo <= _Nav_Monster1.stoppingDistance * 2)
        {
            if (_Estacion == 0 || _Estacion < (PuntosSegundo.Count - 1))
            {
                _Estacion++;
            }
            else
            {
                Debug.Log("llego");
                StartCoroutine(MatarProtagonista());

            }
            if (_Estacion < 2)
            {
                this.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

    }
    void PatronCamino3()
    {
        EnMovimiento = true;
        NavMesh.CalculatePath(this.transform.position, PuntosTercero[_Estacion].transform.position, NavMesh.AllAreas, Camino1);
        _Nav_Monster1.SetPath(Camino1);
        distanciaPointo = Vector3.Distance(this.transform.position, PuntosTercero[_Estacion].transform.position);
        if (distanciaPointo <= _Nav_Monster1.stoppingDistance * 2)
        {
            if (_Estacion == 0 || _Estacion < (PuntosTercero.Count - 1))
            {
                _Estacion++;
            }
            else
            {
                
                Debug.Log("llego");
                StartCoroutine(MatarProtagonista());

            }
            if (_Estacion < 2)
            {
                this.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }
    void PatronCamino4()
    {
        EnMovimiento = true;
        NavMesh.CalculatePath(this.transform.position, PuntosCuarto[_Estacion].transform.position, NavMesh.AllAreas, Camino1);
        _Nav_Monster1.SetPath(Camino1);
        distanciaPointo = Vector3.Distance(this.transform.position, PuntosCuarto[_Estacion].transform.position);
        if (distanciaPointo <= _Nav_Monster1.stoppingDistance * 2)
        {
            if (_Estacion == 0 || _Estacion < (PuntosCuarto.Count - 1))
            {
                _Estacion++;
            }
            else
            {
                
                Debug.Log("llego");
                StartCoroutine(MatarProtagonista());


            }
            if (_Estacion < 2)
            {
                this.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

    }
    public void DetenerBajoDaño(int minitempo)
    {
        EnDanho = true;
        EnMovimiento = false;
        Camino1 = new NavMeshPath();
        _Estacion = 0;
        //_Nav_Monster1.Stop(true);
        StartCoroutine(DanhoFeedBack(minitempo));
    }
    IEnumerator DanhoFeedBack(int tempo)
    {

        _Nav_Monster1.isStopped = true;

        yield return new WaitForSeconds(tempo);
        EnDanho = false;
        _Nav_Monster1.isStopped = false;
        ElegirPatron();
    }
    IEnumerator MatarProtagonista()
    {
        EnDanho = true;
        _Estacion = 0;
        EnMovimiento = false;
        Camino1 = new NavMeshPath();
        yield return new WaitForSeconds(1f);
        PersonajeHuesos.gameObject.SetActive(false);
        EnDanho = false;
        ElegirPatron();
        yield return new WaitForSeconds(2f);
        PersonajeHuesos.gameObject.SetActive(true);
    
    }
    IEnumerator SecuenciaEnemigos(){
        yield return new WaitForSeconds(20f);
        Segundo.SetActive(true);
    }
}
