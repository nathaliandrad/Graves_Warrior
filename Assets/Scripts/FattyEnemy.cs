using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FattyEnemy : MonoBehaviour
{
    [Header("UI")]
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image playerSpecialBar;
    public Text damageText;
    public Animator anim;
    public Animator damageAnimator;
    public Transform textDamageCanvas;

    [Header("Sound")]
    public AudioSource speaker;
    public AudioClip slaySound;
    public AudioClip diedEnemySound;

    [Header("General")]
    public Rigidbody rigi;
    //bool enemyCount;
    GameObject playerGameObj;
    public int maxHealth;
    int health;
    int damage;

    [Header("Game Objects")]
    public GameObject cristals;
    public GameObject test;
    Vector3 dir;
    public Transform player;
    public Renderer rend;
    // public Renderer rendi;
    public GameObject bossObj;
   
 


    // Start is called before the first frame update
    void Start()
    {

   

     player = GameObject.FindWithTag("Player").transform;
        // enemyCount = false;
        playerSpecialBar.fillAmount = 0;
        //maxHealth = 4;
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);

        //playerGameObj = GameObject.Find("Player");
        cristals = GameObject.Find("expSpawnPoint");

    }

  public  void FixedUpdate()
    {
        textDamageCanvas.rotation = Camera.main.transform.rotation;
        slider.transform.rotation = Camera.main.transform.rotation;

    }

    public void HitEnemy()
    {

        damage = Random.Range(5, 21);

        EnemyGeneralDamage();

    }


    public void HitEnemySpecial()
    {
        dir = transform.position - player.transform.position;
        rigi.AddForce(dir * 300);

        damage = Random.Range(21, 41);
        EnemyGeneralDamage();

    }

    public void EnemyGeneralDamage()
    {
        if (anim.GetBool("fattyDeath") != true)
        {
            if (health > 0)
            {
                #region GettingHit
                CallingDifferentShakes();
                StartCoroutine("FlashRed");
                health -= damage;
                damageText.text = damage.ToString();
                damageAnimator.Play("DamageAnim", 0, 0);
                speaker.PlayOneShot(slaySound);
                playerSpecialBar.fillAmount += 0.1f;
                //  print("Enemy Health: " + health);
                slider.value = health;
                fill.color = gradient.Evaluate(slider.value);
                #endregion
                #region hiAnimation
                //int randomHit = Random.Range(0, 2);
                //if (randomHit == 0)
                //{
                    anim.SetTrigger("fattyHit");
                //}
                //else
                //{
                //    anim.SetTrigger("Hit2");
                //}
                #endregion
            }
            else if (health <= 0)
            {
             
                anim.SetBool("fattyDeath", true);
                gameObject.SendMessage("StopIddleAttack");
                slider.gameObject.SetActive(false);
                test.SendMessage("SpawnCristals");
                speaker.PlayOneShot(diedEnemySound, 0.4f);
                Destroy(gameObject, 4f);
                bossObj.SendMessage("EnemyCount");
            }

        }

    }

    public void CallingDifferentShakes()
    {
        if (damage >= 20)
        {
            Camera.main.SendMessage("Shake", 0.8f);
        }
        else if (damage >= 10 && damage < 20)
        {
            Camera.main.SendMessage("Shake", 0.5f);
        }
        else if (damage < 10)
        {
            Camera.main.SendMessage("Shake", 0.3f);
        }

    }


    IEnumerator FlashRed()
    {
       // GetComponent<Renderer>().material.color = kubus.GetComponent<Renderer>().material.GetColor("_Color");
        rend.material.SetColor("_Color", Color.red);
        //rendi.material.SetColor("_EmissionColor", Color.red);
        yield return new WaitForSeconds(0.3f);
        rend.material.SetColor("_Color", Color.gray);
       // rendi.material.SetColor("_EmissionColor", Color.black);

    }
}
