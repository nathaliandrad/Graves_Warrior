using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpCristal : MonoBehaviour
{
    GameObject playerGameObj;
  //  public GameObject breakParticle;

    IEnumerator Start()
    {
        playerGameObj = GameObject.Find("Player");
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("xpFly");
    }

    IEnumerator xpFly()
    {
        float t = 0;
      //  Instantiate(breakParticle, transform.position, transform.rotation);
        Transform refCube = Camera.main.transform.Find("xpReferenceCubeube");
        transform.parent = Camera.main.transform;

        Vector3 myPos = transform.localPosition;
        Vector3 cubeReferencePos = refCube.localPosition;
        while (t < 1)
        {
            transform.localPosition = Vector3.Lerp(myPos, cubeReferencePos, Mathf.SmoothStep(0,1,t));
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
        playerGameObj.SendMessage("SetPlayerLevel");
    }
}
