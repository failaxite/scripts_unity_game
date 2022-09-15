using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{
    // Mettre ce script sur un Object avec un Trigger (collider sur lequel on coche la case trigger)
    // On a besoin de 2 variables : La puissance du bumper, et le rigidbody qu'on va vouloir bumper
    public float puissance = 10f;
    private Rigidbody2D rb;

    // Quand un Collider rentrera dans le trigger de notre bumper, on récupère son rigidbody et on le bump vers le haut (en Y)
    void OnTriggerEnter2D(Collider2D truc) {
        rb = truc.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, puissance);
    }
}
