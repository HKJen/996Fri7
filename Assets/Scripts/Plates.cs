using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour
{
    [SerializeField] List<GameObject> plates = new List<GameObject>();
    
    void Start()
    {
        plates[Random.Range(0,3)].GetComponent<Collider>().isTrigger = true;
        plates[Random.Range(3,6)].GetComponent<Collider>().isTrigger = true;
        plates[Random.Range(6,9)].GetComponent<Collider>().isTrigger = true;

    }

    void Update()
    {
        
    }
}
