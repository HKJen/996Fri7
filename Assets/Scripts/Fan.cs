using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] Vector3 wind;

    private void OnTriggerStay(Collider collider) {
        collider.GetComponent<Rigidbody>().AddForce(wind, ForceMode.Acceleration);
    }

}
