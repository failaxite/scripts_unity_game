using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class checkPointEffect : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem smoke;
    public UnityEngine.Rendering.Universal.Light2D lumiere;
    private bool activation;

    private void Update() {
        if (activation) {
            lumiere.intensity = Mathf.MoveTowards(lumiere.intensity, 1, Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Player" && !activation) {
            fire.Play();
            smoke.Play();
            activation = true;
            StartCoroutine(endEffect());
        }
    }

    IEnumerator endEffect () {
        yield return new WaitForSeconds(5f);
        fire.Stop();
        smoke.Stop();
        activation = false;
    }
}
