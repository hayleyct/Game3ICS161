using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawner : MonoBehaviour {

    [SerializeField] private Transform LeftSpawner;
    [SerializeField] private Transform RightSpawner;
    [SerializeField] private GameObject NormalZombie;
    public float startCounter = 2f; 
    public float LCounter = 0f;
    public float RCounter = 0f;
    public Text LTimerText;
    public Text RTimerText;

	// Use this for initialization
	void Start () {
        setLCounterText();
        setRCounterText();
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
            Instantiate(NormalZombie, LeftSpawner.position, Quaternion.identity);
            LCounter = startCounter;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RCounter <= 0)
        {
            Instantiate(NormalZombie, RightSpawner.position, Quaternion.Euler(0, 180, 0));
            RCounter = startCounter;
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
