using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highscore;
    public Text highscoretext;
    public Text scoretext;
    public GameObject gameoverpanel;
    public AudioClip slicesounds;
    public AudioClip bombsound;
    private AudioSource audiosource;
    private void Start()
    {
        gethighscore();
        audiosource = GetComponent<AudioSource>();
    }
    private void gethighscore()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        highscoretext.text = "Best:" + highscore.ToString();
    }
    // Start is called before the first frame update
    public void Increasescore(int addscore)
    {
        score += addscore;
        scoretext.text = score.ToString();
        if(score>highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoretext.text = score.ToString();
        }
    }
    public void OnBombHit()
    {
        Debug.Log("Hitting bomb");
        gameoverpanel.SetActive(true);
        Time.timeScale = 0;
    }
   public void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void playslicedsound()
    {

        audiosource.PlayOneShot(slicesounds);
    }
    public void playbombslicedsound()
    {
        audiosource.PlayOneShot(bombsound);
    }
    // Update is called once per frame

}
