using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemies")]
    //velocità enemy
    [SerializeField] float enemySpeed;

    [Header("Enemies Shooter")]
    //Velocità proiettile 
    [SerializeField] float bulletSpeed;
    //Ogni quanto spawnare un proiettile
    [SerializeField] float shootTime;
    [SerializeField] float shootVelocity;
    //Posizione in cui spawnare il proiettile
    [SerializeField] GameObject shootPoint;
    //Proiettile da spawnare
    [SerializeField] GameObject bulletPrefab;

    Rigidbody rbEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inizializzo il tempo
        shootTime += Time.deltaTime;
        EnemyMovement();
        ShooterController();
    }

    void EnemyMovement()
    {
        rbEnemy.velocity = Vector3.left * enemySpeed;
    }

    void ShooterController()
    {
        //Quando il tempo è uguale a 3 istanzio un proiettile e resetto il tempo a zero
        if(shootTime >= shootVelocity)
        {
            GameObject objectToInstantiate = Instantiate(bulletPrefab, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), Quaternion.identity);
            objectToInstantiate.GetComponent<Rigidbody>().AddForce(Vector3.left * bulletSpeed);
            shootTime = 0;
        }

    }
}
