using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScPortal : MonoBehaviour
{   
    GameObject GameManager;
    int currentSceneID;
    void Start()
    {
        currentSceneID = SceneManager.GetActiveScene().buildIndex;
        GameManager = GameObject.FindWithTag("GameManager");
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            //DontDestroyOnLoad(col.gameObject);
            //SceneManager.LoadScene(currentSceneID + 1);
            GameManager.GetComponent<Sc_GameManager>().LoadNextScene();
         }}}
