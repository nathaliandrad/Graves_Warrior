using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimListener : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject hitBox;
    public GameObject hitBoxCollection;
    public GameObject spikeNozzle;
    public GameObject firefx;
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    public GameObject attack4;
    public GameObject spinAttack;
    public GameObject spinAttack2;

    [Header("Sounds")]
    public AudioSource speaker;
    public AudioClip slaySound;
    public AudioClip spikeSound;


    public void Show()
    {
        hitBox.SetActive(true);
        speaker.PlayOneShot(slaySound);
    }
    public void Hide()
    {
        hitBox.SetActive(false);
      
    }

    public void ShowFire()
    {
        firefx.SetActive(true);
    }
    public void HideFire()
    {
        firefx.SetActive(false);
    }

    public void ShowHitBoxCollection()
    {
        hitBoxCollection.SetActive(true);
    }

    public void HideHitBoxCollection()
    {
        hitBoxCollection.SetActive(false);
    }

    public void ShowSpike()
    {
        
        spikeNozzle.SetActive(true);
        speaker.PlayOneShot(spikeSound);
    }
    public void HideSpike()
    {
        spikeNozzle.SetActive(false);
    }

    public void Attack1FxShow()
    {
        attack1.SetActive(true);
    }
    public void Attack1FxHide()
    {
        attack1.SetActive(false);
    }

    public void Attack2FxShow()
    {
        attack2.SetActive(true);
    }
    public void Attack2FxHide()
    {
        attack2.SetActive(false);
    }

    public void Attack3FxShow()
    {
        attack3.SetActive(true);
    }
    public void Attack3FxHide()
    {
        attack3.SetActive(false);
    }

    public void Attack4FxShow()
    {
        attack4.SetActive(true);
    }
    public void Attack4FxHide()
    {
        attack4.SetActive(false);
    }


    public void SpinAttackShow()
    {
        spinAttack.SetActive(true);
    }
    public void SpinAttackHide()
    {
        spinAttack.SetActive(false);
    }

    public void SpinAttackShow2()
    {
        spinAttack2.SetActive(true);
    }
    public void SpinAttackHide2()
    {
        spinAttack2.SetActive(false);
    }

}
