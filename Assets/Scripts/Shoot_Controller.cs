using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Controller : MonoBehaviour
{
    //Prefab da instanziare
    [SerializeField] GameObject bulletPrefabs;

    //Posizione da cui instanziare il prefab
    [SerializeField] GameObject shootPoint;

    //Forza con cui instanziare il prefab
    [SerializeField] float forzaSparo;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        //Se premobarra spaziatrice
        if (Input.GetKeyDown("space"))
        {
            //Instanzio prefab nella poszione assegnata
            GameObject objectToInstantiate = Instantiate(bulletPrefabs, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), Quaternion.identity);

            //Aggiungo una forza al prefab istanziato
            objectToInstantiate.GetComponent<Rigidbody>().AddForce(Vector3.right * forzaSparo);
            Debug.Log("Bom");
        }
    }
}
