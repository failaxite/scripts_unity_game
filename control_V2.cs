using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_V2 : MonoBehaviour {

    // IMPORTANT
    // Votre COLLIDER doit avoir un PHYSICS MATERIAL 2D avec 0 de FRICTION pour que ce script marche parfaitement (sinon votre personnage se bloquera contre les murs)
    // Pour créer un Physics Material 2D, clic droit dans l'onglet project, "create/ Physics Material 2D"
    // Puis dans la case FRICTION du physics material vous mettez 0 et enfin vous le glissez dans la case Material de votre COLLIDER

    // Maintenant on déclare nos variables
    public float speed = 5f;                // Vitesse du joueur
    public float jump = 8f;                 // Hauteur du saut
    public float longueurCheckJump = 1.1f;  // Distance à laquelle on vérifie le sol sous les pied du joueur (doit être plus grand que 1)
    private bool canJump;                   // Booléen pour savoir si on peut sauter ou non

    // Et on déclare les composants qu'on va utiliser (c'est les "COMPONENT" présent sur le personnage, visible dans l'inspector quand on sélectionne le personage)
    private Rigidbody2D rb;
    private SpriteRenderer skin;
    private Animator animatotor;
    private Collider2D monCollider;

    // La on déclare un RaycastHit, ça nous servira plustard pour vérifier si on touche le sol
    private RaycastHit2D hit;

    // Première fonction qui aura lieu qu'une seule fois, quand on lancera le jeu
    void Start() {
        // On commence par récupérer les composants (ceux qu'on a déclaré au dessus)
        rb = gameObject.GetComponent<Rigidbody2D>();
        skin = gameObject.GetComponent<SpriteRenderer>();        
        monCollider = gameObject.GetComponent<Collider2D>();
        animatotor = gameObject.GetComponent<Animator>();

        // Et on vérifie 2 choses
        // 1 - Que la rotation de notre personnage est bien vérouillé (pour pas qu'il tombe lamentablement quand on le déplace)
        // 2 - Que les raycast qu'on va effectuer ici vont ignorer le collider de notre personnage
        rb.freezeRotation = true;
        Physics2D.queriesStartInColliders = false;
    }


    // Fonction principale qui aura lieu en permanence, tout au long du jeu
    void Update() {
        // D'abord on appel des fonction qui vont servir à savoir si on peut sauter (jumpCheck) et de quel côté on regarde (lookCheck)
        jumpCheck();
        lookCheck();        

        //On regarde si le joueur a appuyé sur le bouton de saut ET si il a le droit de sauter == > si OUI, alors il saute
        if (Input.GetButtonDown("Jump") && canJump) {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        // On déplace le personnage en fonction des touches que le joueur utilise
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        // Si le joueur a bien un animator de prêt, alors on l'utilise pour animer le personnage
        if (animatotor != null) {
            animatotor.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
            animatotor.SetFloat("velocityY", rb.velocity.y);
        }        
    }

    void jumpCheck() {
        // On fait un raycast qui s'adatpe automatiquement à la taille et au positionnement de votre collider, et qui vise vers le bas
        hit = Physics2D.Raycast(transform.position, -Vector2.up, (monCollider.bounds.extents.y + Mathf.Abs(monCollider.offset.y) * transform.localScale.y) * longueurCheckJump);

        // Ca c'est juste une ligne pour dessiner le raycast dans l'éditor, histoire de pouvoir l'ajuster avec la variable "longueurCheckJump"
        Debug.DrawRay(transform.position, -Vector2.up * (monCollider.bounds.extents.y + Mathf.Abs(monCollider.offset.y) * transform.localScale.y) * longueurCheckJump, Color.red);
        
        // Si le raycast touche ET que c'est pas un trigger, c'est qu'il y a un sol sous nos pied, donc on peut sauter, sinon c'est qu'on est déjà en l'air et donc on peut pas sauter
        if (hit && !hit.collider.isTrigger) {
            canJump = true;
            animatotor.SetBool("jump", false);
        } else {
            canJump = false;
            animatotor.SetBool("jump", true);
        }        
    }

    void lookCheck() {
        //Si notre vitesse de déplacement sur l'axe horizontal (axe X) est positive alors on regarde à droite 
        //Si elle est négative on regarde à gauche
        //Si votre personnage regarde de base à gauche alors il faut inverser les valeurs "false" et "true"
        if (rb.velocity.x > 0) {
            skin.flipX = false;
        }
        if (rb.velocity.x < 0) {
            skin.flipX = true;
        }
    }
}
