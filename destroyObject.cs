using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour {

    public Object trucADetruire;
    public float tempsAvantDestruction;

    public void destroy () {
        Destroy(trucADetruire, tempsAvantDestruction);
    }
}
