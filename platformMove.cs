using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {

    // Ce script permet de faire déplacer une plateforme d'un point A à un point B.

    public float speed = 2f;                                        // Vitesse de déplacement de la plateforme
    [SerializeField, Range(0.1f, 50f)] private float pointA = 5f;   // Position du point A du chemin de la plateforme
    [SerializeField, Range(0.1f, 50f)] private float pointB = 5f;   // Position du point B du chemin de la plateforme
    [SerializeField, Range(0f, 360f)] private float RotationPath;   // Permet de faire pivoter le chemin de la plateforme
    private Vector2 directionAngle;                                 // Variable pour tranformer l'angle RotationPath (en degré) vers une direction (Vector2)
    private Vector3 point1Position;                                 // Sert a transformer la position du point A en coordonnées X/Y/Z
    private Vector3 point2Position;                                 // Sert a transformer la position du point B en coordonnées X/Y/Z
    private bool retour;                                            // booléen qui nous sert a faire demi tour

    // Ici on va enregistrer les positions des point 1 et 2 en utilisant l'angle de rotation et la distance qu'on a choisie
    void Start() {
        directionAngle = (Vector2)(Quaternion.Euler(0, 0, RotationPath) * Vector2.right);
        point1Position = transform.position + (Vector3)directionAngle * pointA;
        point2Position = transform.position - (Vector3)directionAngle * pointB;
    }

    
    void Update() {
        // Si "retour" est faux, alors on se déplace vers le "pointA", et quand on est à moins de 0.05 mètre, "retour" devient vrai
        if (!retour) {
            transform.position = Vector2.MoveTowards(transform.position, point1Position, speed * Time.deltaTime);

            if (Vector2.Distance (transform.position, point1Position) < 0.05f) {
                retour = true;
            }
        }
        // Si "retour" est vrai, alors on se déplace vers le "pointB", et quand on est à moins de 0.05 mètre, "retour" devient faux
        if (retour) {
            transform.position = Vector2.MoveTowards(transform.position, point2Position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, point2Position) < 0.05f) {
                retour = false;
            }
        }
    }

    //Si notre joueur touche cette plateform, il deviendra automatiquement son "enfant" et donc la suivra partout
    void OnCollisionEnter2D(Collision2D truc) {
        if (truc.gameObject.tag == "Player") {
            truc.transform.parent = transform;
        }
    }

    //Si notre joueur quitte cette plateform, il arrêtera d'être son "enfant" et donc ne bougera plus avec la plateforme
    void OnCollisionExit2D(Collision2D truc) {
        if (truc.gameObject.tag == "Player") {
            truc.transform.parent = null;
        }
    }

    void OnDrawGizmos() {
        if (!Application.IsPlaying(gameObject)) {
            directionAngle = (Vector2)(Quaternion.Euler(0, 0, RotationPath) * Vector2.right);
            point1Position = transform.position + (Vector3)directionAngle * pointA;
            point2Position = transform.position - (Vector3)directionAngle * pointB;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point1Position, 0.2f);
        Gizmos.DrawSphere(point2Position, 0.2f);
        Gizmos.DrawLine(point1Position, point2Position);
    }
}
