using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public float totalTime = 10f;
    public float remainingTime;
    //private bool timeIsUp = false;

    public GameObject gameOverButton;
    GameObject bgm;
    AudioSource music;
    GameObject loseSound;
    AudioSource loseAudio;

    void Start()
    {
        bgm = GameObject.Find("/Sounds/BGM");
        music = bgm.GetComponent<AudioSource>();
        loseSound = GameObject.Find("/Sounds/LoseSound");
        loseAudio = loseSound.GetComponent<AudioSource>();
        remainingTime = totalTime;
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0f){
            remainingTime = 0f;
            //timeIsUp = true;
            GameOver();
        }

        countdownText.text = "Time: " + remainingTime.ToString("0.#");
    }

    private void GameOver(){
        gameOverButton.gameObject.SetActive(true);
        music.Pause();
        loseAudio.Play();
        Time.timeScale = 0f;
    }
}