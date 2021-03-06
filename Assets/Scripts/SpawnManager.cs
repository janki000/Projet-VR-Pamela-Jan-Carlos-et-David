﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables pour le SpawnManager
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int waveNumber = 3;
    public GameObject powerupPrefab;
    
    //position
    private float spawnPosZ = 40;
    private float spawnPosX = 45;

    
    void Start()
    {
        //un nombre d'enemie en vagues envoyé
        SpawnEnemyWave(waveNumber);

    }
   
    void Update()
    {
        // premiere vague elimine, evoyer la prochaine avec plus d'enemie
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition = GenerateSpawnPosition();

             //Instantiate( prefab , position , rotation )
            Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, Random.Range(spawnPosZ, spawnPosZ));
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
            
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
    //Position aleatoire d'apparition des ennemies
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;

        
    }
    


}
