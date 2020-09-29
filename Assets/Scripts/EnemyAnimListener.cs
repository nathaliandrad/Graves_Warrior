using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimListener : MonoBehaviour
{
    public GameObject enemyHitBox;
 

    public void ShowEnemyHitBox()
    {
        enemyHitBox.SetActive(true);
       
    }

    public void HideEnemyHitBox()
    {
        enemyHitBox.SetActive(false);
    }
}
