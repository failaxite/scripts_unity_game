using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour {

    public Animator Item1;
    public Animator Item2;
    public Animator Item3;
    public Animator bandeNoir;

    void OnTriggerEnter2D(Collider2D truc) {
        if (truc.tag == "Player") {
            StartCoroutine(animShopStart());
        }
    }

    void OnTriggerExit2D(Collider2D truc) {
        if (truc.tag == "Player") {
            StartCoroutine(animShopEnd());
        }
    }

    IEnumerator animShopStart () {
        bandeNoir.SetTrigger("bandeON");
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.GetInt("upgradeCAC") > 0) {
            Item1.SetTrigger("itemBUY");
            Item1.GetComponent<Button>().interactable = false;
        } else {
            Item1.SetTrigger("itemON");
        }        
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.GetInt("upgradeDIST") > 0) {
            Item2.SetTrigger("itemBUY");
            Item2.GetComponent<Button>().interactable = false;
        } else {
            Item2.SetTrigger("itemON");
        }
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.GetInt("upgradeLIFE") > 0) {
            Item3.SetTrigger("itemBUY");
            Item3.GetComponent<Button>().interactable = false;
        } else {
            Item3.SetTrigger("itemON");
        }
    }

    IEnumerator animShopEnd() {
        Item1.SetTrigger("itemOFF");
        yield return new WaitForSeconds(0.1f);
        Item2.SetTrigger("itemOFF");
        yield return new WaitForSeconds(0.1f);
        Item3.SetTrigger("itemOFF");
        yield return new WaitForSeconds(0.1f);
        bandeNoir.SetTrigger("bandeOFF");
    }
}
