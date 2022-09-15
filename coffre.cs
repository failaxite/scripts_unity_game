using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffre : MonoBehaviour
{
    // Le coffre DOIT avoir un TRIGGER sur lui (collider sur lequel on a coché la case TRIGGER)

    public GameObject objetDansLeCoffre;    // Le prefab qu'on veux faire pop quand on ouvre le coffre
    private GameObject objetSave;           // Une sauvegarde temporaire de l'objet qu'on fait pop (
    public int nombreObjet;                 // Le nombre d'ojbjet que le coffre devra faire apparaitre
    private Animator animatotor;            // L'animator pour lancer l'animation d'ouverture du coffre (si il y en a une)

    // Dans le start, on va chercher l'animator si il existe
    private void Start() {
        animatotor = GetComponent<Animator>();
    }

    // Maintenant on utilise la fonction OnTriggerEnter2D pour vérifier quand le joueur touche le coffre (le joueur doit avoir le tag "Player") 
    // Dès que le joueur entrera dans le trigger du coffre, on lance l'animation d'ouverture et on lance la fonction "duPognon"

    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Player") {
            if (animatotor != null) {
                animatotor.SetTrigger("open");
            }
            StartCoroutine(duPognon());
        }
    }

    // La fonction "duPognon" fera 2 chose: 
    // désactivation de son collider pour éviter que le joueur puisse ouvrir le coffre plusieur fois
    // apparaitre un objet du coffre toute les 0.05 secondes

    IEnumerator duPognon () {
        GetComponent<Collider2D>().enabled = false;
        for (int i = 0; i < nombreObjet; i++) {
            objetSave = Instantiate(objetDansLeCoffre, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
