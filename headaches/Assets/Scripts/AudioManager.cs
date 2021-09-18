using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //reference to audiosource
    public AudioSource themeAudio;

    //references to Theme1-4 audio clips
    //**Tempos were sped up 10% going down**
    public AudioClip Theme1;
    public AudioClip Theme2;
    public AudioClip Theme3;
    public AudioClip Theme4;

    //reference to obstacle
    public Obstacle_Behavior obstacle;

    //float to store playback time of theme audio
    private float themeAudioTime;


    //start is called before the first frame update
    void Start()
    {
        //refer to audiosource component in Game_Controller for theme song
        themeAudio = GameObject.Find("Game_Controller").GetComponent<AudioSource>();
        
        //change themes when requirements (dependant on speed) are met.
        IEnumerator NextTheme()
        {
            //search this up idk what this () => means. also, wtf is yield return lmao
            yield return new WaitUntil(() => (obstacle.obstacleSpeed >= 3 && obstacle.obstacleSpeed < 5));

            //set theme to Theme1
            themeAudio.clip = Theme1;
            themeAudio.Play();

            //*
            yield return new WaitUntil(() => (obstacle.obstacleSpeed >= 5 && obstacle.obstacleSpeed < 7));

            //set AudioTime to current AutdioTime * 0.91f to ccontinue where left off.
            themeAudioTime = themeAudio.time * 0.91f;
            themeAudio.clip = Theme2;
            //set new clip's AudioTime to AudioTime.
            themeAudio.time = themeAudioTime;
            themeAudio.Play();

            //**
            yield return new WaitUntil(() => (obstacle.obstacleSpeed >= 7 && obstacle.obstacleSpeed < 9));

            themeAudioTime = themeAudio.time * 0.91f;
            themeAudio.clip = Theme3;
            themeAudio.time = themeAudioTime;
            themeAudio.Play();

            //***
            yield return new WaitUntil(() => (obstacle.obstacleSpeed >= 9));

            themeAudioTime = themeAudio.time * 0.91f;
            themeAudio.clip = Theme4;
            themeAudio.time = themeAudioTime;
            themeAudio.Play();
        }
        StartCoroutine(NextTheme());
    }
}
