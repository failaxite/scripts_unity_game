using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ajouter cette ligne pour pouvoir utiliser des élément de l'interface

public class coinManager : MonoBehaviour {

    // IL nous faut 2 variables principales: Un chiffre pour compter les gold, et un text pour l'écrire sur l'interface
    public Text coinText; // Le texte d'UI qui montrera le nombre de pièce du joueur
    public int coin; // Le nombre de pièce du joueur

    // Mais on va aussi utiliser un petit effet quand on ramasse la pièce
    public GameObject effect;

    // On commence par tout de suite mettre notre nombre de pièce dans le texte (donc 0 en gros)
    void Start() {
        coinText.text = coin.ToString();
    }


    // Ensuite quand on touche une pièce (truc qui a le tag "Coin"), 
    // on augmente notre compteur de 1, on met à jour notre texte et on détruit la pièce
    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Coin") {
            coin++;
            coinText.text = coin.ToString();
            Destroy(truc.gameObject);
            Instantiate(effect, truc.transform.position, Quaternion.identity);
        }
    }
}
