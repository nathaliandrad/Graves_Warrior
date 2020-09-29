using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{
    public GameObject player;
    public AudioSource speaker;
     public AudioClip hitImpactSfx;

    string enemy, weakerEnemy, fattyEnemy, boss;

    public void Start()
    {
        if(gameObject.name == "enemyHitBox")
        {
            enemy = gameObject.name;
        }
        if (gameObject.name == "enemyHitBoxWeaker")
        {
            weakerEnemy = gameObject.name;
        }
        if (gameObject.name == "fattyEnemyHitBox")
        {
            fattyEnemy = gameObject.name;
        }
        if(gameObject.name == "bossHit")
        {
            boss = gameObject.name;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        //print("Hitting Player");
        speaker.PlayOneShot(hitImpactSfx);
        if (gameObject.name == enemy)
        {
            player.SendMessage("PlayerDamage");
        }
        if (gameObject.name == weakerEnemy)
        {
            player.SendMessage("PlayerDamageWeaker");
        }
        if (gameObject.name == fattyEnemy)
        {
            player.SendMessage("PlayerDamageFatty");
        }
        if(gameObject.name == boss)
        {
            player.SendMessage("DamagePlayerFromBoss");
        }
        //if(gameObject.name == boss)
        //{
           
        //}

       
    }
}
