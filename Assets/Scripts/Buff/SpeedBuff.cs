using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedBuff;
    PlayerMovement movement;
    Transform player;
    public static float TimerBuff = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movement = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            movement.speed += speedBuff;
            movement.isSpeed = true;
            Destroy(gameObject);
        }
    }
}
