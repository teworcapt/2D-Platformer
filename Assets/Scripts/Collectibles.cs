using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public bool speed, health;
    public int speedBoost, healthBoost, duration;
    private int baseMovespeed;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        baseMovespeed = player.moveSpeed;
        StartCoroutine(BackToBaseSpeed());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed)
        {
            player.moveSpeed += speedBoost;
        }
        
        if (health)
        {
            player.healthPoints+= healthBoost;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed= baseMovespeed;
    }
}
