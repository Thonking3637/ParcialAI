using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : SBAgent
{
    private Transform target;
    private int wavePointIndex = 0;

   

   

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
        
		maxSteer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

      
        velocity +=  SteeringBehaviours.Separate(this,SpawnManager.GO, 3f);  
        velocity +=SteeringBehaviours.Seek(this, Waypoints.points[wavePointIndex]);   
        transform.position +=  velocity * Time.deltaTime;

         if(Vector3.Distance(transform.position,  target.position) <= 0.2f){
             GoNextPoint();
             
         }    

         
    }

    public void GoNextPoint(){
        if(wavePointIndex  >= Waypoints.points.Length - 1){
           FinalRecorrido();
            return;
        }
        wavePointIndex++;
		target = Waypoints.points[wavePointIndex];
    }

    public void FinalRecorrido(){
        SpawnManager.GOAlive--;
         Destroy(gameObject);
    }

}
