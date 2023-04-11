using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour{
    public GameObject tweetSound;    
    public GameObject speedUpSound;
    public GameObject gameOverSound;
    public GameObject startScreen;
    public GameObject settingsScreen;
    public GameObject sfxCheck;
    public int sfxOn;

    void Start(){
        sfxOn = PlayerPrefs.GetInt("sfxOn", 1);
        sfxCheck.GetComponent<Toggle>().isOn = sfxOn == 1 ? true : false;
        updateSFX();
    }

    public void openSettings(){
        startScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void closeSettings(){
        startScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void flipSFX(){
        sfxOn = sfxCheck.GetComponent<Toggle>().isOn ? 1 : 0;
        updateSFX();
        PlayerPrefs.SetInt("sfxOn", sfxOn);
    }

    void updateSFX(){
        tweetSound.GetComponent<AudioSource>().mute = sfxOn == 1 ? false : true;
        speedUpSound.GetComponent<AudioSource>().mute = sfxOn == 1 ? false : true;
        gameOverSound.GetComponent<AudioSource>().mute = sfxOn == 1 ? false : true;
    }

}
