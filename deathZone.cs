using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Player") {
            truc.GetComponent<lifeplayer>().vie = 0;
        }
    }
}
