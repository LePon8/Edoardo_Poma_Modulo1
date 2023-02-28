using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    //Tipo di prefab da spawnare
    [SerializeField] GameObject enemyToSpawn;

    //Ogni quanto viene spawnato
    [SerializeField] float timeSpawn;

    //Limiti entro i quali spawnare
    [SerializeField] Transform upLimitSpawn;
    [SerializeField] Transform downLimitSpawn;

    //Velocità movimento spawner
    [SerializeField] float spawnerSpeed;
    Rigidbody rbSpawner;

    float upLimit, downLimit;

    //Tempo effettivo
    float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        //Inizializzo up e down
        upLimit = upLimitSpawn.position.y;
        downLimit = downLimitSpawn.position.y;

        rbSpawner = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    

    void Spawner()
    {
        //Inizializzo il timer
        spawnTimer += Time.deltaTime;

        //Se il timer è maggiore/uguale ad ogni quanto viene spawnato il prefab
        if(spawnTimer >= timeSpawn)
        {
            //Instanzio il prefab in una posizione randomica entro i limiti assegnati
            Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(upLimit, downLimit), -0.25f);
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            //Resetto il timer a 0
            spawnTimer = 0;
        }

        rbSpawner.velocity = Vector3.right * spawnerSpeed;
    }
}
