using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBuff : MonoBehaviour
{
    PlayerHealth health;
    Transform player;
    public int heal = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            health.currentHealth += heal;
            Destroy(gameObject);
        }
    }
}
