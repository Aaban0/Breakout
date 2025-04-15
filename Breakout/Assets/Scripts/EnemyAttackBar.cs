using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackBar : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Image playerHealthBar;
    public Image attackBar;

    private float attackMax = 100;
    private float attack = 0;

    
    void Update()
    {
        //variable attack incrases over time, miltiplied by 10 to make it faster 
        attack += Time.deltaTime * 10f;
        //changes the fill of the attack bar, divided by attackMax to get a percentage value
        attackBar.fillAmount = attack / attackMax;

        //if the attack reaches its max
        if (attack >= attackMax)
        {
            //player gets damaged and attack value is reset
            playerHealth.Damage(20);
            attack = 0;
        }
    }
}
