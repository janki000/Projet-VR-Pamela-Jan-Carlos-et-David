using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Variable pour le Target
    public float healt = 50f;
    
    public void TakeDamege(float amount)
    {
        //si la vie de la cibles es plus <= a 0 la cible disparait
        healt -= amount;
        if (healt <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //destruction de la cible
        Destroy(gameObject);
    }
}
   
