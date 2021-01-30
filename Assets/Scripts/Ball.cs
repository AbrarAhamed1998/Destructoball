using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] PaddleMovement paddle1;
    [SerializeField] float xpush;
    [SerializeField] float ypush;
    [SerializeField] AudioClip[] ballSounds; 

    Vector2 paddleToBalldist;
    public bool started = false;
    AudioSource ballAudSource;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBalldist = transform.position - paddle1.transform.position;
        ballAudSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
       if (Input.GetMouseButtonDown(0))
        {
            started = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xpush, ypush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBalldist;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (started)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            ballAudSource.PlayOneShot(clip);
        }
    }
}
