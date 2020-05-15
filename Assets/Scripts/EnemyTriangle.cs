using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriangle : MonoBehaviour
{
    private GameManager gameManager;

    private float speed = 3f;
    private float speedRandomness = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.rotation = Quaternion.LookRotation(Vector3.forward, gameManager.center - transform.position);
        //speed += Random.Range(-speedRandomness, speedRandomness);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        
            if (Vector3.Distance(transform.position, gameManager.center) > 20)
            {
                Destroy(gameObject);
            }
        }
    }
}
