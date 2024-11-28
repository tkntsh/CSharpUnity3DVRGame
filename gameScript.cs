using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    //gameobjects for applications and ui
    public GameObject textScore;
    public AudioSource audioS;
    public ParticleSystem particleS;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //setting score to 0
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }

    //switch to game scene
    public void loadGameScene()
    {
        SceneManager.LoadScene("gameScene");
    }
    //switch to start scene
    public void startScene()
    {
        SceneManager.LoadScene("homeScene");
    }
    //quit button pressed
    public void exitGame()
    {
        Application.Quit();
    }

    //method to check if object has been hit on specific trigger
    void OnCollisionEnter(Collision collision)
    {
        //checking if target 1 was hit
        if (collision.gameObject.CompareTag("ball1"))
        {
            score += 100;
            updateScore();
        }
        //checking if target 2 was hit
        else if (collision.gameObject.CompareTag("ball2"))
        {
            score += 50;
            updateScore();
        }
        //checking if target 2 was hit
        else if (collision.gameObject.CompareTag("ball3"))
        {
            score += 25;
            updateScore();
        }

        //playing sound effect when ball hits target
        if (audioS != null)
        {
            audioS.Play();
        }

        //particle system plays when target is hit
        if (particleS != null)
        {
            particleS.Play();
        }
        //update score
        updateScore();
    }
    //method to update the score of player
    void updateScore()
    {
        //scoreText.text = "Score: " + score;
        textScore.GetComponent<Text>().text = "Score: " + score;
    }
}
