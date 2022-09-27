using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour {
    
    public float moveSpeedY = 2.0f;
    public float boundY = 6.0f;
    
    void Update() {
        Move();
    }

    void Move() {
        Vector2 temp = transform.position;
        temp.y += moveSpeedY * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= boundY) {
            gameObject.SetActive(false);
        }
    }
}
