using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public PlayerHealth player;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn() {
        if (player.currentHealth <= 0f)
        {
            return;
        }

        int spawnBuff = Random.Range(0, 2);

        //Memduplikasi enemy
        Factory.FactoryMethod(spawnBuff);
    }

}
