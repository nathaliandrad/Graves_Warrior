using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FattyEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    public Animator anim;
    bool attacking;

    //[Header("Sounds")]
    //public AudioSource speaker;
    //public AudioClip roarSound;
    //public AudioClip roarSound2;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine("Idle");

    }

    public IEnumerator Idle()
    {
        while (distance > 6)
        {
            agent.stoppingDistance = 2.5f;
            float range = 3f;
            Vector3 pos = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
            agent.SetDestination(transform.position + pos);

            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }
        StartCoroutine("Attacking");
    }

    public void Update()
    {
        anim.SetFloat("fattyEnemyWalkSpeed", agent.velocity.magnitude);
    }


    public IEnumerator Attacking()
    {
       
        // yield return null;
        attacking = true;
        while (attacking)
        {
            while (distance > 3)
            {
                agent.SetDestination(player.position);
                yield return new WaitForSeconds(0.2f);
            }

            

            //#region SettingRandomSounds
            //float t = 0;
            //while (t < 0.01f)
            //{
            //    t += Time.deltaTime;

            //    int rand = Random.Range(0, 2);
            //    if (rand == 1)
            //    {
            //        speaker.PlayOneShot(roarSound, 0.2f);
            //        // print("roar sound 1");
            //    }
            //    else
            //    {
            //        speaker.PlayOneShot(roarSound2, 0.2f);
            //        //   print("roar sound 2");
            //    }


            //    yield return null;
            //}
            //#endregion
             yield return new WaitForSeconds(0.5f);
            anim.SetBool("fattyAttackEnemy", true);

            yield return new WaitForSeconds(2f);
            while (distance < 3)
            {
                yield return new WaitForSeconds(2f);

            }
            anim.SetBool("fattyAttackEnemy", false);
        }

    }

    //public IEnumerator AttackAnimationInterval()
    //{
    //    anim.SetBool("attackEnemy", true);
    //    yield return new WaitForSeconds(1f);
    //    anim.SetBool("attackEnemy", false);
    //    yield return new WaitForSeconds(2f);
    //    anim.SetBool("attackEnemy", true);

    //}

    public float distance
    {
        get
        {
            return Vector3.Distance(transform.position, player.position);
        }
    }

    public void StopIddleAttack()
    {
        StopCoroutine("Idle");
        StopCoroutine("Attacking");
    }
}
