using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Ball : MonoBehaviour {
    [SerializeField] Pedal pedal;
    [SerializeField] private float xVelocity = 2f;
    [SerializeField] private float yVelocity = 5f;
    [SerializeField] AudioClip[] ballSounds;

    private Vector2 diff;
    private float heightOfBall;
    private float heightOfPedal;
    private bool hasStarted;
    private AudioSource audioSource;

    float ballY;

    // Start is called before the first frame update
    void Start() {
        diff = transform.position - pedal.transform.position;
        heightOfBall = GetComponent<SpriteRenderer>().bounds.size.y;
        heightOfPedal = pedal.GetComponent<SpriteRenderer>().bounds.size.y;
        ballY = pedal.transform.position.y + heightOfPedal + (heightOfBall / 2);
        hasStarted = false;
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!hasStarted) {
            ballOnPedal();
            launchBall();
        }
    }

    private void launchBall() {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
            hasStarted = true;
        }
    }

    private void ballOnPedal() {
//        Debug.Log(ballY + "|" + pedal.transform.position.x);
//        Vector2 targetPosition = new Vector2(pedal.transform.position.x, ballY - 0.2f);
//        transform.position = targetPosition;
        Vector2 pedalPosition = new Vector2(pedal.transform.position.x, pedal.transform.position.y);
        transform.position = pedalPosition + diff;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AudioClip randomAudio = null;
        if (ballSounds != null)
            randomAudio = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

        if (hasStarted)
            if (randomAudio != null)
                audioSource.PlayOneShot(randomAudio);
            else
                audioSource.Play();
    }
}