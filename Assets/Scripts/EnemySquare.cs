using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SquareStatuses {
    NAVIGATING,
    ON_ORBIT
}

public class EnemySquare : MonoBehaviour
{
    [SerializeField] private GameObject enemySmallTrianglePrefab;

    private GameManager gameManager;
    private float speed = 3f;
    private float orbitSpeed = 1f;
    private float orbitHeight = 5f;
    private SquareStatuses status = SquareStatuses.NAVIGATING;
    private float spawnRate = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePoint = new Vector3(ray.origin.x, ray.origin.y);
            Vector3 target = mousePoint.normalized * orbitHeight;

            if (status == SquareStatuses.NAVIGATING)
            {
                transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, gameManager.center) < orbitHeight + 0.1f)
                {
                    status = SquareStatuses.ON_ORBIT;
                }
            }
            else if (status == SquareStatuses.ON_ORBIT)
            {
                Vector3 curPosition = transform.position - gameManager.center;

                var newRotation = new Quaternion();
                newRotation.SetFromToRotation(curPosition, target);
                Vector3 newPosition = Quaternion.Lerp(transform.rotation, newRotation, orbitSpeed * Time.deltaTime) * transform.position;
                transform.position = new Vector3(newPosition.x, newPosition.y, 0);
            }
        }
    }

    IEnumerator Spawner()
    {
        while (gameManager.isGameActive) // isGameOn
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(enemySmallTrianglePrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        }
    }
}
