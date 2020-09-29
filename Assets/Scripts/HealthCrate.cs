using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour
{
    public MeshRenderer crateMesh;
    public BoxCollider boxCollider;
    GameObject player;
    public AudioSource speaker;
    public AudioClip breakSound;
   // public GameObject breakPartickle;

    public void Start()
    {

        player = GameObject.Find("Player");
        crateMesh = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            speaker.PlayOneShot(breakSound, 0.5f);
            //nozzleBreakParticle.SetActive(true);
            
            boxCollider.enabled = false;
            crateMesh.enabled = false;
           // Instantiate(breakPartickle, transform.position, transform.rotation);
            player.SendMessage("AddPlayerHealth");
        }
    }
}
