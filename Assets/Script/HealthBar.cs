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
        healthBar.maxValue = 20;
    }

    void update() {
        healthBar.value = (int) playerHealth.GetVida();
    }

    public void SetHealth(int hp) {
        healthBar.value = hp;
    }
}