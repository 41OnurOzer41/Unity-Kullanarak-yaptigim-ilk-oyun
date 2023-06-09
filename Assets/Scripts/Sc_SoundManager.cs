using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sc_SoundManager : MonoBehaviour{
    [SerializeField] public AudioSource AudioSrc;
    [SerializeField] private AudioClip Level1Music;
    [SerializeField] private AudioClip Level0Music;
    //SCENE INFORMATION
    Scene currentScene;
    void Start() {
        currentScene= SceneManager.GetActiveScene();
        //Debug.Log((float)Screen.width);
        //Debug.Log((float)Screen.height);
        changeMusicOnLevel();
    }
    public void changeMusicOnLevel(){
        currentScene= SceneManager.GetActiveScene();
        if(currentScene.buildIndex == 0){
            AudioSrc.Stop();
            this.AudioSrc.clip=Level0Music;
            AudioSrc.Play();
            AudioSrc.loop=true;
        }else if(currentScene.buildIndex == 1){
            AudioSrc.Stop();
            this.AudioSrc.clip=Level1Music;
            AudioSrc.Play();
            AudioSrc.loop=true;
        }}
    void Update(){  }}
