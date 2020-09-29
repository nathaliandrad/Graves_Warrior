using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public IEnumerator Shake(float intensity)
    {
        float t = 1;

        while (t > 0)
        {
            t -= Time.deltaTime * 2;
            transform.localPosition = Random.insideUnitSphere * intensity * t;
            yield return null;
        }

    }

    public IEnumerator Shake(float intensity, float duration)
    {
        float t = 1;

        while (t > 0)
        {
            t -= Time.deltaTime * duration;
            transform.localPosition = Random.insideUnitSphere * intensity * t;
            yield return null;
        }

    }
}
