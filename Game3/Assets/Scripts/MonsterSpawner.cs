using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawner : MonoBehaviour {

    [SerializeField] private Transform LeftSpawner;
    [SerializeField] private Transform RightSpawner;
    [SerializeField] private Zombies[] zombies; 
    public float startCounter = 2f;
    public float LCounter = 0f;
    public float RCounter = 0f;
    public Text LTimerText;
    public Text RTimerText;
        
    private GameObject [] arrows;
    private int curZombie;
    private int numOfZombies;

    // Use this for initialization
    void Start () {
        setLCounterText();
        setRCounterText();
        numOfZombies = zombies.Length;
        arrows = new GameObject[numOfZombies];
        for (int i = 0; i < numOfZombies; i++) {
            arrows[i] = transform.Find("Arrow " + i).gameObject;
            arrows[i].SetActive(false);
        }
        arrows[0].SetActive(true);
        curZombie = 0;

    }

    // Update is called once per frame
    void Update () {
        if (LCounter > 0f)
        {
            LCounter -= Time.deltaTime;
        }
        if (RCounter > 0f)
        {
            RCounter -= Time.deltaTime;
        }

        setLCounterText();
        setRCounterText();

        if (Input.GetKeyDown(KeyCode.LeftArrow) && LCounter <= 0)
        {
            Instantiate(zombies[curZombie].prefab, LeftSpawner.position, Quaternion.identity);
            LCounter = zombies[curZombie].spawnTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RCounter <= 0)
        {
            Instantiate(zombies[curZombie].prefab, RightSpawner.position, Quaternion.Euler(0, 180, 0));
            RCounter = zombies[curZombie].spawnTime;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && numOfZombies != 1) {
            arrows[curZombie].SetActive(false);
            curZombie -= 1;
            if (curZombie < 0) {
                curZombie = 1;
            }
            arrows[curZombie].SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && numOfZombies != 1) {
            arrows[curZombie].SetActive(false);
            curZombie += 1;
            if (curZombie > 1) {
                curZombie = 0;
            }
            arrows[curZombie].SetActive(true);
        }
    }

    public void setLCounterText()
    {
        if (LCounter <= 0f)
        {
            LTimerText.text = "Spawn: READY";
        }
        else
        {
            LTimerText.text = "Spawn: " + LCounter.ToString("f0");
        }
    }

    public void setRCounterText()
    {
        if (RCounter <= 0f)
        {
            RTimerText.text = "Spawn: READY";
        }
        else
        {
            RTimerText.text = "Spawn: " + RCounter.ToString("f0");
        }
    }
}

[System.Serializable]
public class Zombies
{
    public GameObject prefab;
    public float spawnTime;
}
