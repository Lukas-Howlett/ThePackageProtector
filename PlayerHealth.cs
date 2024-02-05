using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    public int totalLives = 3;
    private int currentLives;

    public Image[] lifeImages;
    public GameObject gameOverButton;
    GameObject bgm;
    AudioSource music;
    GameObject loseSound;
    AudioSource loseAudio;
    GameObject ouch;
    AudioSource ouchSound;

    void Start()
    {
        bgm = GameObject.Find("/Sounds/BGM");
        music = bgm.GetComponent<AudioSource>();
        loseSound = GameObject.Find("/Sounds/LoseSound");
        loseAudio = loseSound.GetComponent<AudioSource>();
        ouch = GameObject.Find("/Sounds/OuchSound");
        ouchSound = ouch.GetComponent<AudioSource>();
        currentLives = totalLives;
        UpdateLifeCounter();
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Car") || other.name == "DogTrigger"){
            currentLives--;
            ouchSound.Play();
            if(currentLives <= 0){
                UpdateLifeCounter();
                GameOver();
            }else{
                UpdateLifeCounter();
            }
        }
    }

    void UpdateLifeCounter(){
        for(int i=0; i<lifeImages.Length; i++){
            if(i<currentLives){
                lifeImages[i].enabled = true;
            }else{
                lifeImages[i].enabled = false;
            }
        }
    }
    
    private void GameOver(){
        gameOverButton.gameObject.SetActive(true);
        music.Pause();
        loseAudio.Play();
        Time.timeScale = 0f;
    }
}
