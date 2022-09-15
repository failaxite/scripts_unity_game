using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levier : MonoBehaviour {

    // Ce script se met sur le levier qui permettra au joueur d'ouvrir la porte
    // ATTENTION il marche en binome avec un autre script : le script "porte"

    public GameObject porte; // Il faudra drag'n drop la "porte" que l'on souhaite ouvrir dans cette variable (depuis l'éditeur)
    private bool inTrigger;

    void Update() {
        if (inTrigger) {
            if (Input.GetKeyDown(KeyCode.E)) {
                porte.GetComponent<porte>().ouverture();
                GetComponent<Animator>().SetTrigger("activation");
            }
        }
    }

    // Tant que le joueur reste dans ce trigger, si il appuis sur la touche "E" du clavier, ça lance la fonction "ouverture" qui se trouve sur cette porte
    void OnTriggerEnter2D(Collider2D truc) {        
        if (truc.tag == "Player") {
            inTrigger = true;            
        }
    }

    void OnTriggerExit2D(Collider2D truc) {
        if (truc.tag == "Player") {
            inTrigger = false;
        }
    }
}
