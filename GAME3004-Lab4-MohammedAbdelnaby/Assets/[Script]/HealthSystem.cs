using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private Slider HealthBar;

    [Range(0.0f, 100.0f)]
    [SerializeField]
    private float Health;


    public void TakeDamage(float dmg)
    {
        HealthBar.value -= (dmg / 100.0f);
    }

    public void Heal(float heal)
    {
        HealthBar.value += (heal / 100.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            TakeDamage(10.0f);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10.0f);
        }
    }
}
