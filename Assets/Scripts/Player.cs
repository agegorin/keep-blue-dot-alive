using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject bar;
    [SerializeField] public GameObject shotPrefab;

    private float speed = 10;
    private float rotationSpeed = 50;
    private float maxDistance = 4;
    private float minDistance = 1;
    private float shotLoadingSpeed = 1;
    private float barPositionBorder = 11;

    private GameManager gameManager;
    private float barBaseDistance;
    private float shotLoading = 0;
    private SpriteRenderer barSprite;
    private HSBColor baseColor;
    private Vector3 basePosition;
    private AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shotSound = gameObject.GetComponent<AudioSource>();

        basePosition = transform.position;

        barBaseDistance = bar.transform.localPosition.y;
        barSprite = bar.GetComponent<SpriteRenderer>();
        baseColor = new HSBColor(barSprite.color);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target;
        if(gameManager.isGameActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            target = new Vector3(ray.origin.x, ray.origin.y);
        }
        else
        {
            target = basePosition;
        }

        // Player position
        float distanceToCenter = Vector3.Distance(target, gameManager.center);
        if (distanceToCenter < minDistance)
        {
            target = gameManager.center + (target - gameManager.center).normalized * minDistance;
        }
        else if (distanceToCenter > maxDistance)
        {
            target = gameManager.center + (target - gameManager.center).normalized * maxDistance;
        }
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

        // Player rotation
        Vector3 direction = gameManager.center - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.deltaTime);

        // Bar position
        float newDistanceToCenter = Vector3.Distance(transform.position, gameManager.center) / transform.localScale.y;
        if (newDistanceToCenter > barPositionBorder)
        {
            bar.transform.localPosition = new Vector3(0, newDistanceToCenter + barBaseDistance - barPositionBorder, 0);

            shotLoading += shotLoadingSpeed * Time.deltaTime;

            if (shotLoading > 1)
            {
                Shoot();
            }

            HSBColor newColor = new HSBColor(baseColor.h, baseColor.s, baseColor.b);
            newColor.h += (1 - baseColor.h) * shotLoading;
            barSprite.color = newColor.ToColor();
        }
        else
        {
            bar.transform.localPosition = new Vector3(0, barBaseDistance, 0);

            ResetBar();
        }
    }

    void Shoot()
    {
        Instantiate(shotPrefab, bar.transform.position, bar.transform.rotation);
        shotSound.Play();
        ResetBar();
    }

    void ResetBar()
    {
        shotLoading = 0;
        barSprite.color = baseColor.ToColor();
    }
}
