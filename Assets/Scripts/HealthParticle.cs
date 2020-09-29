using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticle : MonoBehaviour
{
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject,3f);
        }
    }
}
