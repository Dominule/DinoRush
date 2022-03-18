using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // mezičlánek - přecházení mezi scénami

    // funkce TransitionLoad()

    // couroutine       - to je tahle věc

    public Animator transition;


    public void TransitionLoad()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        Debug.Log("started");

        yield return new WaitForSecondsRealtime(0);     //přehodit na 1 ??  //vyhodit úplně

        LevelSelector.LoadNextLevel();

    }
}
