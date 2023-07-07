using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi = default;
    public Text gamescore = default;
    public Text timeScore = default;
    public Text BestScore = default;
    public Text BestTime = default;

    public float Gamescore = default;
    private float surviveTime = default;
    private float BestTimenum = default;
    private float BestScorenum = default;
    private bool isGameOver = default;

    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;

        BestTimenum = PlayerPrefs.GetFloat("Best Time");
        BestScorenum = PlayerPrefs.GetFloat("Best Score");

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            surviveTime += Time.deltaTime;

            timeScore.text = (string.Format("Time : {0}", (int)surviveTime));

         if(surviveTime > BestTimenum)
            {
                BestTime.text = (string.Format("Best Time : {0}", (int)surviveTime));
            }
         
            gamescore.text = (string.Format("Score : {0}", (int)Gamescore));

         if(Gamescore > BestScorenum)
            {
                BestScore.text = (string.Format("Best Score : {0}", (int)Gamescore));
            }

        }
        //else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                GFunc.LoadScene("SampleScene");

            }


        }
    }

    public void EndGame()
    {
        
        isGameOver = true;
        gameOverUi.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("Best Time");
        float bestScore = PlayerPrefs.GetFloat("Best Score");

        Debug.LogFormat("BestTime: {0}, SurviveTime: {1}",bestTime,surviveTime);
        Debug.LogFormat("BestScore: {0}, Gamescore : {1}", bestScore,Gamescore);
       

        if (Input.GetKeyDown(KeyCode.R))
        {

            GFunc.LoadScene("SampleScene");

        }

        if (bestTime < surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("Best Time", bestTime);

        }
        if( bestScore < Gamescore)
        {
            bestScore = Gamescore;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        BestScore.text = (string.Format("Best Score : {0}", (int)bestScore));
        BestTime.text = (string.Format("Best Time : {0}", (int)bestTime));
    }
}
