using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyTrianglePrefab;
    [SerializeField] private GameObject enemyCirclePrefab;
    [SerializeField] private GameObject enemySquarePrefab;

    [SerializeField] private GameObject uiTitle;
    [SerializeField] private GameObject uiStartButton;
    [SerializeField] private GameObject uiScoreText;
    [SerializeField] private GameObject uiMuteButton;
    [SerializeField] private GameObject uiMuteButtonText;

    private float spawnDistance = 11;
    private float spawnRate = 0.5f;
    private float spawnCounter = 0;
    private float spawnCounter2 = 0;
    private float spawnTimer = 0;
    private IEnumerator spawnerCoroutine;
    private float level = 0;
    private bool levelStart = true;

    public float hp = 10;
    public float maxHp = 10;
    public float score = 0;

    public bool isMute;
    public Vector3 center = Vector3.zero;
    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnerCoroutine = Spawner();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (isGameActive)
        {
            Vector3 basePos = new Vector3(0, spawnDistance, 0);

            if (level == 0)
            {
                if (levelStart)
                {
                    Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                    spawnCounter = 4;
                }
                else
                {
                    if (spawnCounter > 0)
                    {
                        Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                        spawnCounter -= 1;
                    }
                }
            }

            if (level == 1)
            {
                if (levelStart)
                {
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 60) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 120) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 240) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 300) * basePos, Quaternion.identity);
                }

            }

            if (level == 2)
            {
                if (levelStart)
                {
                    Instantiate(enemyCirclePrefab, new Vector3(0, spawnDistance, 0), Quaternion.identity);
                }
            }

            if (level == 3)
            {
                if (levelStart)
                {
                    Instantiate(enemyCirclePrefab, new Vector3(0, spawnDistance, 0), Quaternion.identity);
                    spawnCounter = 10;
                }
                else
                {
                    if (spawnCounter > 0)
                    {
                        Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                        spawnCounter -= 1;
                    }
                }
            }

            if (level == 4)
            {
                if (levelStart)
                {
                    Instantiate(enemyCirclePrefab, GetSpawnPosition(), Quaternion.identity);
                    Instantiate(enemyCirclePrefab, GetSpawnPosition(), Quaternion.identity);
                    Instantiate(enemyCirclePrefab, GetSpawnPosition(), Quaternion.identity);
                    spawnCounter = 20;
                }
                else
                {
                    if (spawnCounter > 0 && Random.Range(0, 1f) > 0.5f)
                    {
                        Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                        spawnCounter -= 1;
                    }
                }
            }

            if (level == 5)
            {
                if (levelStart)
                {
                    spawnCounter = 10;
                }
                if (spawnCounter > 0 && Random.Range(0, 1f) > 0.01f)
                {
                    Instantiate(enemyCirclePrefab, GetSpawnPosition(), Quaternion.identity);
                    spawnCounter -= 1;
                }
            }

            if (level == 6)
            {
                if (levelStart)
                {
                    spawnTimer = Time.time;
                    spawnCounter = 0;

                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 45) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 55) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 65) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 75) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 85) * basePos, Quaternion.identity);
                }
                if (spawnCounter == 0 && Time.time - spawnTimer > 0.9f)
                {
                    spawnCounter += 1;
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 95) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 105) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 115) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 125) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 135) * basePos, Quaternion.identity);
                }
                if (spawnCounter == 1 && Time.time - spawnTimer > 1.9f)
                {
                    spawnCounter += 1;
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 145) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 155) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 165) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 175) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 185) * basePos, Quaternion.identity);
                }
                if (spawnCounter == 2 && Time.time - spawnTimer > 2.9f)
                {
                    spawnCounter += 1;
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 195) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 205) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 215) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 225) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 235) * basePos, Quaternion.identity);
                }
                if (spawnCounter == 3 && Time.time - spawnTimer > 3.9f)
                {
                    spawnCounter += 1;
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 245) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 255) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 265) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 275) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 285) * basePos, Quaternion.identity);
                }
            }

            if (level == 7)
            {
                if (levelStart)
                {
                    Instantiate(enemySquarePrefab, GetSpawnPosition(), Quaternion.identity);
                }
            }

            if (level == 8)
            {
                if (levelStart)
                {
                    spawnCounter = 0;
                    spawnCounter2 = 0;
                    spawnTimer = Time.time;
                    Instantiate(enemySquarePrefab, GetSpawnPosition(), Quaternion.identity);
                }
                if (spawnCounter == 0 && Time.time - spawnTimer > 1.4f)
                {
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 60) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 120) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 240) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 300) * basePos, Quaternion.identity);
                    spawnCounter += 1;
                }
                if (spawnCounter == 1 && Time.time - spawnTimer > 2.9f)
                {
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 70) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 80) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 90) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 100) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 110) * basePos, Quaternion.identity);
                    spawnCounter += 1;
                }
                if (spawnCounter == 2 && Time.time - spawnTimer > 4.4f)
                {
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 250) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 260) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 270) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 280) * basePos, Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, Quaternion.Euler(0, 0, 290) * basePos, Quaternion.identity);
                    spawnCounter += 1;
                }
                if (spawnCounter == 3 && Time.time - spawnTimer > 5.9f)
                {
                    Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                    Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                    if (spawnCounter2 < 3)
                    {
                        spawnCounter2 += 1;
                        spawnCounter = 0;
                        spawnTimer = Time.time;
                    }
                }
            }

            if (level > 8)
            {
                if (levelStart)
                {
                    Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                }

                float rand = Random.Range(0, 1.0f);
                if (rand < 0.02)
                {
                    Instantiate(enemySquarePrefab, GetSpawnPosition(), Quaternion.identity);
                }
                else if (rand < 0.07)
                {
                    Instantiate(enemyCirclePrefab, GetSpawnPosition(), Quaternion.identity);
                }
                else if (rand < 0.33)
                {
                    Instantiate(enemyTrianglePrefab, GetSpawnPosition(), Quaternion.identity);
                }
            }

            levelStart = false;
            if (CheckLevelEnd())
            {
                level += 1;
                levelStart = true;
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void ReduceHP(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(float amount)
    {
        score += amount;
    }

    private Vector3 GetSpawnPosition()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360f)) * new Vector3(0, spawnDistance, 0);
    }

    private bool CheckLevelEnd()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Jumper").Length == 0;
    }

    public void StartGame()
    {
        hp = maxHp;
        score = 0;
        level = 0; // TODO set to 0
        levelStart = true;
        isGameActive = true;
        uiTitle.SetActive(false);
        uiStartButton.SetActive(false);
        uiMuteButton.SetActive(false);
        uiScoreText.SetActive(false);
        StartCoroutine(spawnerCoroutine);
    }

    public void GameOver()
    {
        isGameActive = false;
        hp = maxHp;

        uiTitle.SetActive(true);
        uiStartButton.SetActive(true);
        uiMuteButton.SetActive(true);
        Text scoreText = uiScoreText.GetComponent<Text>();
        scoreText.text = "Your score is " + score;
        uiScoreText.SetActive(true);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
        GameObject[] jumpers = GameObject.FindGameObjectsWithTag("Jumper");
        for (int i = 0; i < jumpers.Length; i++)
        {
            Destroy(jumpers[i].gameObject);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }
        StopCoroutine(spawnerCoroutine);
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        Text muteText = uiMuteButtonText.GetComponent<Text>();
        muteText.text = isMute ? "UNMUTE" : "MUTE";
    }
}
