using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster2 : MonoBehaviour
{
    NavMeshAgent _Nav_Monster1;
    public List<GameObject> Puntos;
    int _Estacion = 0;
    Rigidbody Rbd1;
    NavMeshPath Camino1;
    float distanciaPointo;


    // Start is called before the first frame update
    void Start()
    {
        _Nav_Monster1 = this.GetComponent<NavMeshAgent>();
        Rbd1 = this.GetComponent<Rigidbody>();
        Camino1 = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        //Rbd1.MovePosition(Puntos[0].transform.position);
        //_Nav_Monster1.Move();
        distanciaPointo = Vector3.Distance(this.transform.position, Puntos[_Estacion].transform.position);
        if (distanciaPointo <= _Nav_Monster1.stoppingDistance * 2)
        {
            if (_Estacion == 0 || _Estacion < (Puntos.Count - 1))
            {
                _Estacion++;
            }
            else
            {
                _Estacion = 0;
            }
        }
        NavMesh.CalculatePath(this.transform.position, Puntos[_Estacion].transform.position, NavMesh.AllAreas, Camino1);
        _Nav_Monster1.SetPath(Camino1);
    }
}
