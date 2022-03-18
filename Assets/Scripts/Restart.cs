using UnityEngine;

// program resetuje hru na původní nastavení

public class Restart : MonoBehaviour
{
    public void GameRestart()
    {
        PlayerPrefs.SetString("DinoName", "Miri");  // jméno dinosaura

        PlayerPrefs.SetInt("generalCoins", 0);      // amoniti (peníze)
        CoinHalter.CoinChange = 0;


        // Boosters:
        PlayerPrefs.SetInt("HealthPoints", 1);      // životy
        PlayerPrefs.SetInt("newHealthPrice", 25);
        PlayerPrefs.SetInt("ScoreStars", 1);        // scoreStars
        PlayerPrefs.SetInt("newStarPrice", 25);
        PlayerPrefs.SetInt("BigAmonitValue", 5);    // hodnota amonitu
        PlayerPrefs.SetInt("newBigamonPrice", 25);
        PlayerPrefs.SetInt("AmonitBooster", 1);     // počet amonitů

        PlayerPrefs.SetInt("scoreBooster", 1);  // vypočítávání score
        PlayerPrefs.SetInt("highscore", 0);     // highscore


        // Levely:
        PlayerPrefs.SetInt("Poprve", 1);        // level 1
        for (int i = 2; i < 10; i++)                 // levely 2-40
        {
            PlayerPrefs.SetInt("UnLocked" + i, 0);
        }

        PlayerPrefs.SetString("selectedDino", "Brontosaurus");  // vybraný dinosaurus v GamePlay


        // itemy v obchodu
        PlayerPrefs.SetInt("Triceratops", 0);
        PlayerPrefs.SetInt("T-Rex", 0);
        PlayerPrefs.SetInt("Velociraptor", 0);
        PlayerPrefs.SetInt("Styracosaurus", 0);

    }

}
