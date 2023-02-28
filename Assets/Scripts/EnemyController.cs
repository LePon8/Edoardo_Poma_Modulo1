using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemies")]
    //velocit� enemy
    [SerializeField] float enemySpeed;

    [SerializeField] int Hp;
    [SerializeField] Slider HPBar;
    public int currentHP;


    [Header("Enemies Shooter")]
    //Velocit� proiettile 
    [SerializeField] float bulletSpeed;
    //Ogni quanto spawnare un proiettile
    [SerializeField] float shootTime;
    [SerializeField] float shootVelocity;
    //Posizione in cui spawnare il proiettile
    [SerializeField] GameObject shootPoint;
    //Proiettile da spawnare
    [SerializeField] GameObject bulletPrefab;

    Rigidbody rbEnemy;

    Character_Controller CH;

    private void Awake()
    {
        currentHP = Hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();

        CH = FindObjectOfType<Character_Controller>();

        HPBar.maxValue = currentHP;
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
        //Quando il tempo � uguale a 3 istanzio un proiettile e resetto il tempo a zero
        if(shootTime >= shootVelocity)
        {
            GameObject objectToInstantiate = Instantiate(bulletPrefab, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), Quaternion.identity);
            objectToInstantiate.GetComponent<Rigidbody>().AddForce(Vector3.left * bulletSpeed);
            shootTime = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            currentHP -= 1;
            HPBar.value = currentHP;
            other.gameObject.SetActive(false);

            if(currentHP <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Limit"))
        {
            CH.Damage();
        }
    }
}
