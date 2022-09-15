using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeBar : MonoBehaviour
{
    private GameObject player;
    private lifeplayer lifeScript;
    private int viePlayer;
    private int vieSave;
    public GameObject[] vieCube = new GameObject[10];
    private bool updating;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        lifeScript = player.GetComponent<lifeplayer>();
        for (int i = 0; i < transform.childCount; i++) {
            vieCube[i] = transform.GetChild(i).gameObject;         
        }
    }

    // Update is called once per frame
    void Update() {
        viePlayer = lifeScript.vie;
        if (vieSave != viePlayer && !updating) {
            updating = true;
            if (vieSave < viePlayer) {
                StartCoroutine(lifeUp(viePlayer));
            }
            if (vieSave > viePlayer) {
                StartCoroutine(lifeDown(viePlayer));
            }
        }
        
    }

    IEnumerator lifeUp (int newVieSave) {
        for (int i = vieSave; i < newVieSave; i++) {
            vieCube[i].GetComponent<Animator>().SetTrigger("go");         
            yield return new WaitForSeconds(0.05f);
        }
        vieSave = newVieSave;
        updating = false;
    }

    IEnumerator lifeDown(int newVieSave) {
        for (int i = vieSave; i > newVieSave; i--) {
            vieCube[i - 1].GetComponent<Animator>().SetTrigger("end");
            yield return new WaitForSeconds(0.05f);
        }
        vieSave = newVieSave;
        updating = false;
    }
}
