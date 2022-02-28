using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _speed = 7;
    [SerializeField] private bool _isPaddle1;
    private Ball _ball;

    void Start()
    {
        _ball = GameObject.Find("Ball").GetComponent<Ball>(); //Find GameObject in game with the name and gets the component
    }

    void Update()
    {
        if(_isPaddle1) //Player
        {

            if (transform.position.y <= 3.55 && transform.position.y >= -3.55) 
            {
                Vector3 movement = new Vector2(0, Input.GetAxis("Vertical"));
                transform.position += movement * Time.deltaTime * _speed;
            }
        }
        else //AI
        {
            if(_ball.transform.position.x >= -4)
            {
                if(Random.Range(0,1) == 0)
                {
                    transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, _ball.transform.position.y, _speed * Time.deltaTime));
                }
            }
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.55f, 3.55f)); //Limit
    }
}
