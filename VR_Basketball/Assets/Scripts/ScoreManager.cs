using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("分數介面")]
    public Text scoretext;
    [Header("分數")]
    public int score;
    [Header("投進所得分數")]
    public int scoreIn = 2;

    public  AudioClip    soundin ;

    private  AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "籃球")
        {
            Addscore();
        }
        if (other.transform.root.name == "Player")
        {
            scoreIn = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            scoreIn = 2;
        }
    }

    private void Addscore() 
    {
        score += scoreIn;
        scoretext.text = "分數:" + score;
        aud.PlayOneShot(soundin, Random.Range(0.5f, 2f));
    }
}
