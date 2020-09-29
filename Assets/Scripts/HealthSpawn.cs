using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    public GameObject healthBox;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnHealth",0);
    }

    public void SpawnHealth()
    {
        
        for(int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-25, 70), 2, Random.Range(-20, 33));
            Instantiate(healthBox, transform.position+pos, transform.rotation);
           // yield return null;

        }

        //yield return null;
    }

   

}
