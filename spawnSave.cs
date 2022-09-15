using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSave : MonoBehaviour {
    
    void Awake() {
        transform.position = new Vector3(PlayerPrefs.GetFloat("spawnX", transform.position.x), PlayerPrefs.GetFloat("spawnY", transform.position.y), PlayerPrefs.GetFloat("spawnZ", transform.position.z));
    }

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Delete)) {
            PlayerPrefs.DeleteAll();
            print("Sauvegarde supprimé");
        }
    }

    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "CheckPoint") {
            PlayerPrefs.SetFloat("spawnX", truc.transform.position.x);
            PlayerPrefs.SetFloat("spawnY", truc.transform.position.y);
            PlayerPrefs.SetFloat("spawnZ", truc.transform.position.z);
        }
    }
}
