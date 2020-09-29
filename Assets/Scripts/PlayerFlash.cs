using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{
    public Renderer rend;



   public IEnumerator FlashWhite()
    {

        rend.material.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(0.1f);
        rend.material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.1f);
        rend.material.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(0.1f);
        rend.material.SetColor("_EmissionColor", Color.black);

    }
}
