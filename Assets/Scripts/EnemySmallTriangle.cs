using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmallTriangle : MonoBehaviour
{
    private GameManager gameManager;

    private float speed = 5f;
    private float speedRandomness = 0.7f;
    private float rotationSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed += Random.Range(-speedRandomness, speedRandomness);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, gameManager.center - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * speed * Time.deltaTime);


            if (Vector3.Distance(transform.position, gameManager.center) > 20)
            {
                Destroy(gameObject);
            }
        }
    }
}
