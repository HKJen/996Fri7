using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] int force;

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Player")) {
            collision.collider.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
        }
    }

    
}
