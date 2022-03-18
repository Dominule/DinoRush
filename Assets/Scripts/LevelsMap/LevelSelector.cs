using System;
using UnityEngine;
using UnityEngine.SceneManagement;      // pro překlikávání mezi scénami
using TMPro;                            // pro TMP prvky

// program zajišťuje:

// spuštění hráčem vybraného levelu
// přístup k číslu levelu (int) pro ostatní skripty (Score, LevelManager)
// spuštění následného levelu při stisknutí tlačítka "next level"

public class LevelSelector : MonoBehaviour
{
    private static int PlusEndScore;        // číslo aktuálního levelu


    // fce vrací inteegera (static PlusEndScore)
    // fce se volá z dalších programů, zajišťuje přístup k číslu aktuálního levelu
    public static int get()
    {
        return PlusEndScore;        // vrací číslo aktuálního levelu
    }


    // fce se volá ze scény GamePlay
    // načítá další level
    public static void LoadNextLevel()
    {
        PlusEndScore += 1;      // aktuální level je vyšší o 1
        SceneManager.LoadScene("GamePlay");     // načte další level
    }


    // fce se volá při stisknutí tlačítka určeného levelu
    public static void Select(TextMeshProUGUI levelName)
    {
        PlusEndScore = Convert.ToInt32(levelName.text);     // získá číslo levelu z textu na stisknutém tlačítku
        SceneManager.LoadScene("GamePlay");     // načte vybraný level
    }

   
}
