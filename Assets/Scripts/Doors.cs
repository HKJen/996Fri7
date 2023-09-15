using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] List<GameObject> doors = new List<GameObject>();
    
    void Start()
    {
        // 4 doors , 3 rows 
        for (var i = 0; i < doors.Count; i += doors.Count / 3) {
            var x  = Random.Range(i, i + 4);
            RBDoor(x);
        }
    }

    
    void Update()
    {
        
    }

    public void RBDoor(int count) {
        Rigidbody rb = doors[count].gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
    }
}
