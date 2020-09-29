using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemySpawn : MonoBehaviour
{
    public GameObject weakEnemy;
    // Start is called before the first frame update
    void Start()
    {
        float posX = Random.Range(-22f,6f);
        float posZ = Random.Range(-26f, -12f);
        float posXa = Random.Range(-22f, 6f);
        float posZa = Random.Range(-28f, -12f);
        float posXb = Random.Range(-22f, 6f);
        float posZb = Random.Range(-28f, -12f);


        float pos2Z = Random.Range(5f, 30f);
        float pos2X = Random.Range(-12f, 12f);
        float pos3X = Random.Range(18f, 71f);
        float pos3Z = Random.Range(-21f, 28f);
        Vector3 enemy1pos = new Vector3(posX, 2, posZ);
        Vector3 enemy2Pos = new Vector3(posXa, 2, posZa);
        Vector3 enemy3Pos = new Vector3(posXb, 2, posZb);

        Instantiate(weakEnemy, transform.position+ enemy1pos, transform.rotation);
        Instantiate(weakEnemy, transform.position + enemy2Pos, transform.rotation);
        Instantiate(weakEnemy, transform.position + enemy3Pos, transform.rotation);
        // Instantiate(weakEnemy, transform.position+ enemy2Pos, transform.rotation);
        //Instantiate(weakEnemy, transform.position+ enemy3Pos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
