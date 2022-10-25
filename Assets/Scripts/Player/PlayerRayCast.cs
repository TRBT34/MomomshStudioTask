using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public LayerMask mask;
    RaycastHit hit;
    private void Update()
    {
        if (Physics.Raycast(transform.position + new Vector3(0,0,3), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0, 3), transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0, 3), transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }    
}
