using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    private GameManager gameManager;

    private float speed = 4f;
    private float speedRandomness = 0.7f;
    private float rotationSpeed = 1f;
    private float boostTime = 1f;

    private float speedBooterTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
        speed += Random.Range(-speedRandomness, speedRandomness);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (speedBooterTimer > 0)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime * 2);
                speedBooterTimer -= Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, gameManager.center) < 2 && speedBooterTimer <= 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, gameManager.center - transform.position), 5 * rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, gameManager.center - transform.position), rotationSpeed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, gameManager.center) > 20)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bar"))
        {
            transform.rotation = other.transform.rotation;
            speedBooterTimer = boostTime;
        }
    }
}
