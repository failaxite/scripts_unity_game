using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopItem : MonoBehaviour {

    public int prix;
    public Text prixText;
    public string description;
    public Text descriptionText;

    private Button monBouton;
    private coinManager coinScript;

    private lifeplayer lifeScript;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        monBouton = GetComponent<Button>();
        prixText.text = prix.ToString();
        descriptionText.text = description;

        coinScript = GameObject.FindGameObjectWithTag("Player").GetComponent<coinManager>();
        lifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<lifeplayer>();
    }

    void Update() {
        if (coinScript.coin < prix) {
            prixText.color = Color.red;
        }
        else {
            prixText.color = Color.white;
        }
    }

    public void buyCAC () {
        if (coinScript.coin > prix) {
            PlayerPrefs.SetInt("degatCAC", PlayerPrefs.GetInt("degatCAC") + 2);
            PlayerPrefs.SetInt("upgradeCAC", 1);
            monBouton.interactable = false;
            anim.SetTrigger("itemBUY");
        }            
    }
    public void buyDIST() {
        if (coinScript.coin > prix) {
            PlayerPrefs.SetInt("degatDIST", PlayerPrefs.GetInt("degatDIST") + 1);
            PlayerPrefs.SetInt("upgradeDIST", 1);
            monBouton.interactable = false;
            anim.SetTrigger("itemBUY");
        }
    }
    public void buyVIE() {
        if (coinScript.coin > prix) {
            PlayerPrefs.SetInt("playerLIFE", PlayerPrefs.GetInt("playerLIFE") + 1);
            PlayerPrefs.SetInt("upgradeLIFE", 1);
            monBouton.interactable = false;
            lifeScript.heal(10);
            anim.SetTrigger("itemBUY");
        }
    }
}
