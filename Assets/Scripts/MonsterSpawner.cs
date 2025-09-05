using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform leftPos, rightPos; //spawning sites kinda

    [SerializeField]
    private GameObject[] monsterReference; //which monsters to spawn will be added to this array

    private GameObject spawnedMonster; //spawning the monsters
    private int randomIndex; //determining the index of the spawned monster
    private int randomSide; //determining the side of the spawned monster

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() //IEnumerator so that we can call the method again and again rather than only at the start
    {
        while (true)
        {
            yield return new WaitForSeconds (Random.Range (1, 5)); //returning spawnedMonsters after a random time duration b/w 1-5 sec 
            randomIndex = Random.Range (0, monsterReference.Length); //will choose a random monster from array based as its array index
            randomSide = Random.Range (0, 2); //will spawn at one of the either sides; 0(left side) or 1(right side)
            spawnedMonster = Instantiate (monsterReference [randomIndex]); 
            //instantiate will make a copy of the monster at the chosen randomIndex in the monsterReference array  

            if (randomSide == 0) //left side
            {
                spawnedMonster.transform.position = leftPos.position; //spawn monster on the position of the left game object
                spawnedMonster.GetComponent<Enemies>().speed = Random.Range (4, 10);  
                //set a +ve random speed of the spawned monster to have it move towards the +ve X-axis
            }
            else //right side
            {
                spawnedMonster.transform.position = rightPos.position; //spawn monster on the position of the right game object
                spawnedMonster.GetComponent<Enemies>().speed = -Random.Range (4, 10);  
                //set a -ve random speed of the spawned monster to have it move towards the -ve X-axis

                spawnedMonster.transform.localScale = new Vector3 (-1f, 1f, 1f); //-1f on X-axis so monster would face left
            }
        }
    }

}
