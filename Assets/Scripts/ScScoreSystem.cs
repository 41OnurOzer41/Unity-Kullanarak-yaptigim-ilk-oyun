using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScScoreSystem : Singleton<ScScoreSystem>
{
    public int para=0;
    public TMP_Text paraText;
    public GameObject paraTextGO;
    // Start is called before the first frame update
    void Start(){
        paraText = paraTextGO.GetComponent<TextMeshProUGUI>();
    }
    void Update(){
        paraText.text =$"Para: {para}";
    }
    public void setGUIObjectsPara(GameObject g1)
    {
        paraTextGO = g1;
    }}
