using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the health bar object.
/// </summary>
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform player;

    /// <summary>
    /// Takes the current hit points and the start hit points of the player ship
    /// and sets the scale of the health bar accordingly.
    /// </summary>
    /// <param name="currentHP"></param>
    /// <param name="maxHP"></param>
    public void reduce(float currentHP, float maxHP)
    {
        transform.localScale = new Vector3(currentHP / maxHP, 0.1f, 1);
    }

    /// <summary>
    /// At every Frame, takes the player ship position and set the health bar right above it.
    /// </summary>
    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0.7f, 0);
    }
}