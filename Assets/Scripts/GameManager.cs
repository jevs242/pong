using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Text[] scorePlayer;
    [SerializeField]private Text _gameEnd;
    [SerializeField]private GameObject _bReset;
    public int[] score = { 0 };


    private void Start()
    {
        _gameEnd.enabled = false;
        _bReset.SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangeScore() //Function -> Update score
    {
        scorePlayer[0].text = score[0].ToString();
        scorePlayer[1].text = score[1].ToString();

        StartCoroutine(Pause());
    }

    IEnumerator Pause() //Function -> Pause the game
    {
        yield return new WaitForSeconds(1);
        if (score[0] >= 10)
        {
            _gameEnd.enabled = true;
            _gameEnd.text = "The winner is: /nPlayer 1";
            _bReset.SetActive(true);
            Time.timeScale = 0;
        }
        else if (score[1] >= 10)
        {
            _gameEnd.enabled = true;
            _gameEnd.text = "The winner is : Player 2";
            _bReset.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameReset() //Function -> Reset the level
    {
        SceneManager.LoadScene("Pong");
    }
}
