using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateformFall : MonoBehaviour {

    // Ce script permet de faire tomber une plateforme après un certain temps quand le joueur marche dessus

    public float wait = 1f;     // Le temps que la plateforme va mettre pour tomber

    // Si le joueur touche la plateforme, on lance la coroutine "haaaaa"
    void OnCollisionEnter2D (Collision2D truc) {
        if (truc.gameObject.tag == "Player") {
            StartCoroutine(haaaaa());
        }
    }

    // Dans cette coroutine on fait dans l'ordre : 
    // 1/ Attendre (le temps défini dans "wait") 2/ On ajoute un rigidbody pour le faire tomber 3/ On désactive le collider pour pas qu'il nous gène 4/ On détruit l'objet après 1 seconde
    IEnumerator haaaaa () {
        yield return new WaitForSeconds(wait);
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,1f); 
    }
}
