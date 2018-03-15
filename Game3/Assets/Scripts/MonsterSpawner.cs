using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawner : MonoBehaviour {

    [SerializeField] private Transform LeftSpawner;
    [SerializeField] private Transform RightSpawner;
    [SerializeField] private GameObject Zombie1;
    [SerializeField] private GameObject Zombie2;
    public float startCounter = 2f;
    public float LCounter = 0f;
    public float RCounter = 0f;
    public Text LTimerText;
    public Text RTimerText;

    private GameObject [] arrows;
    private int curZombie;

    private GameObject [] zombies;

    // Use this for initialization
    void Start () {
        setLCounterText();
        setRCounterText();

        arrows = new GameObject[2];
        for (int i = 0; i < 2; i++) {
            arrows[i] = transform.Find("Arrow " + i).gameObject;
            arrows[i].GetComponent<Renderer>().enabled = false;
        }
        arrows[0].GetComponent<Renderer>().enabled = true;
        curZombie = 0;

        zombies = new GameObject[] {Zombie1, Zombie2};
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
            Instantiate(zombies[curZombie], LeftSpawner.position, Quaternion.identity);
            LCounter = startCounter;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RCounter <= 0)
        {
            Instantiate(zombies[curZombie], RightSpawner.position, Quaternion.Euler(0, 180, 0));
            RCounter = startCounter;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            arrows[curZombie].GetComponent<Renderer>().enabled = false;
            curZombie -= 1;
            if (curZombie < 0) {
                curZombie = 1;
            }
            arrows[curZombie].GetComponent<Renderer>().enabled = true;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            arrows[curZombie].GetComponent<Renderer>().enabled = false;
            curZombie += 1;
            if (curZombie > 1) {
                curZombie = 0;
            }
            arrows[curZombie].GetComponent<Renderer>().enabled = true;
        }

    }

    public void setLCounterText()
    {
        if (LCounter < 0f)
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
        if (RCounter < 0)
        {
            RTimerText.text = "Spawn: READY";
        }
        else
        {
            RTimerText.text = "Spawn: " + RCounter.ToString("f0");
        }
    }
}
