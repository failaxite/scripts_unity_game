using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {
    public string SceneName;
    public float loadWaitTime;
    private bool waiting;

    public void loadingScene() {
        waiting = true;
        StartCoroutine(waitTime());
        StartCoroutine(goLoad());
    }

    IEnumerator waitTime () {
        yield return new WaitForSeconds(loadWaitTime);
        waiting = false;
    }

    IEnumerator goLoad() {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone) {
            if (asyncOperation.progress >= 0.9f) {
                if (!waiting)
                    asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
