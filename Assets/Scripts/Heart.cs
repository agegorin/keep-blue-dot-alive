using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hurtSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 target = new Vector3(ray.origin.x, ray.origin.y);

        float distance = Vector3.Distance(gameManager.center, target);

        transform.position = gameManager.center + (target - gameManager.center).normalized * Mathf.Sqrt(distance) / 20;
        transform.localScale = new Vector3(gameManager.hp / gameManager.maxHp, gameManager.hp / gameManager.maxHp, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Jumper"))
        {
            gameManager.ReduceHP(1);
            hurtSound.Play();
            Destroy(other.gameObject);
        }
    }
}
