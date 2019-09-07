using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pedal : MonoBehaviour {
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] private bool autoPlay = false;

    private float pedalWidth;
    private Ball ball;

    // Start is called before the first frame update
    void Start() {
        pedalWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void FixedUpdate() {
//        if (autoPlay && ball != null)
//            AutoPlay();
//        else
            ByMouse();
    }

    void ByMouse() {
        float mousePositionXInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        float pedalXPosition = Mathf.Clamp(mousePositionXInUnits, pedalWidth / 2, ScreenWidthInUnits - pedalWidth / 2);
        transform.position = new Vector2(pedalXPosition, transform.position.y);
    }

    void AutoPlay() {
        transform.position = new Vector2(ball.transform.position.x, transform.position.y);
    }
}