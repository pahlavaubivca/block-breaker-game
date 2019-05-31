using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour {
    [SerializeField] float ScreenWidthInUnits = 16f;

    private float pedalWidth;

    // Start is called before the first frame update
    void Start() {
        pedalWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float mousePositionXInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        float pedalXPosition = Mathf.Clamp(mousePositionXInUnits, pedalWidth/2, ScreenWidthInUnits - pedalWidth/2);
        transform.position = new Vector2(pedalXPosition, transform.position.y);
    }
}