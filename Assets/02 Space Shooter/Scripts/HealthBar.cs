using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    public void reduce(float currentHP, float maxHP)
    {
        transform.localScale = new Vector3(currentHP/maxHP,0.1f,1);
    }

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0.7f, 0);
    }
}
