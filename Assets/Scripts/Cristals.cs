using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristals : MonoBehaviour
{
    public GameObject cristal;
    AudioSource speaker;
    public AudioClip xpSound;
    Vector3 myPos;
     Quaternion myRot;

    public void Start()
    {
        
        speaker = GetComponent<AudioSource>();
        
       // cristal = GetComponent<Rigidbody>();
    }
    Vector3 desPos;
    // Start is called before the first frame update
    IEnumerator SpawnCristals()
    {
        desPos = new Vector3(0, 1.6f, 0);
        myPos = transform.position;
        myRot = transform.rotation;

        // yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
          
            GameObject crist = Instantiate(cristal, myPos+ desPos, myRot);
            crist.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-50, 70), Random.Range(-40, 40), Random.Range(-50, 60)));
        }
        speaker.PlayOneShot(xpSound);
       // Destroy(gameObject);
        yield return null;
    }
}
