using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerP playerHealth;

    private void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerP>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = (int) playerHealth.GetMaxVida();
        healthBar.value = (int) playerHealth.GetVida();
    }

    public void SetHealth(int hp) {
        healthBar.value = hp;
    }
}