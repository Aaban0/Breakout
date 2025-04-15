using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthCurrent = 100;
    public float healthMax = 100;

    public void Damage(float damage)
    {
        //clamps the health so it does not exceed 100 & blelow 0 
        healthCurrent = Mathf.Clamp(healthCurrent, 0, healthMax);

        //passes in parameter damage, when called it will take away from the players health
        healthCurrent -= damage;
        //changes the fill of the healthbar to the value of health / 100 to get a percentace value 
        healthBar.fillAmount = healthCurrent / healthMax;
    }
}
