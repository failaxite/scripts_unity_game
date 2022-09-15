using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectCoin : MonoBehaviour {
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-2f,2f), Random.Range(3f, 5f));
    }
}
