using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public static int GOAlive = 0;
    public Wave[] waves;
    public static List<GameObject> GO =  new List<GameObject>();
    public Transform spawnPoint;
    
    public int waveIndex;
    private float countdown = 2f;
    public float timeBetweenWaves = 5f;
   
    void Update()
    {
        if (GOAlive > 0)
		{
			return;
		}
        
		if (waveIndex == waves.Length)
		{		
			this.enabled = false;
		}
		if (countdown <= 0f)
		{
			StartCoroutine(spawnWave());
            StartCoroutine(spawnWave2());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator spawnWave(){

         Wave wave = waves[waveIndex];
         GOAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnGameObject1(wave.enemy);
            GO.Add(wave.enemy);
            print(GO);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;  
    }
     IEnumerator spawnWave2(){

         Wave wave = waves[waveIndex];
         GOAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnGameObject2(wave.enemy2);
            GO.Add(wave.enemy2);
            print(GO);
			yield return new WaitForSeconds(1f / wave.rate2);
		}

		waveIndex++;  
    }

    void SpawnGameObject1  (GameObject GO){
        Instantiate(GO, spawnPoint.position, spawnPoint.rotation);
        
    }
    void SpawnGameObject2  (GameObject GO2){
        Instantiate(GO2, spawnPoint.position, spawnPoint.rotation); 
        
    }
}
