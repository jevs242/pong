using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]private float initialVelocity = 4f;
    [SerializeField]private float multiplyVelocity = 1.1f;
    private Vector3 _startLocation;
    private Rigidbody2D _rb;
    private GameManager _gameManager;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _startLocation = transform.position;
        Launch();
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        _rb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    void OnCollisionEnter2D(Collision2D collider) //Funcion -> Collision
    {
        if (collider.gameObject.CompareTag("Paddle"))
        {
            _rb.velocity *= multiplyVelocity;
        }
    }
    void OnTriggerEnter2D(Collider2D other) //Funcion -> Trigger
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            if (other.gameObject.name == "GoalPlayer1")
            {
                _gameManager.score[0]++;
                _gameManager.ChangeScore();
            }
            else
            {
                _gameManager.score[1]++;
                _gameManager.ChangeScore();
            }
            StartCoroutine(ReturnBall());
        }
    }

    IEnumerator ReturnBall() //Funcion -> Return the nall to the starting location
    {
        yield return new WaitForSeconds(3);
        transform.position = _startLocation;
        Launch();
    }
}
