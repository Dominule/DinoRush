using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

// program zajišťuje správné VYKRESLENÍ a FUNGOVÁNÍ systému levelů (odemčení/zamčení)


public class LevelManager : MonoBehaviour
{
    [System.Serializable]       // zajistí v unity přístup ke class Level

    // společné každému levelu
    public class Level
    {
        public string NumberLevel;      // číslo levelu ve formě stringu
        public int UnLocked;             // locked = 0       unlocked = 1

        public Button.ButtonClickedEvent OnClickEvent;      // tlačítko levelu
    }

    public GameObject LevelPrefab;      // prefab pro každý level


    // LevelContaigner bude Parent všech nově tvořených newLevelů
    // zajišťuje zobrazení levelů na plátně systematicky
    public Transform LevelContaigner1;
    public Transform LevelContaigner2;
    public Transform LevelContaigner3;
    public Transform LevelContaigner4;

    // seznam levelů, definováno v unity
    // nesmí být static - neexistoval by sem přístup, vymazaly by se levely
    public List<Level> LevelList;

    static int NumberOfNextLevel;       // číslo následujícího levelu

    static int first;       // proměnná first slouží pro první interakci hráče s hrou, odemčení 1. levelu

    void Start()
    {
        first = PlayerPrefs.GetInt("Poprve", 1);        // zjistí, jestli hráč hraje poprvé
        FillList();

    }


    // načte levely včetně jejich čísla a un/locked booleanu
    public void FillList()
    {
        // v případě, že hráč hraje poprvé
        if (first == 1)
        {            
            // všechny levely kromě prvního uzamkne
            foreach (var level in LevelList)
            {
                PlayerPrefs.SetInt("UnLocked" + (Int32.Parse(level.NumberLevel)-1), 0);
            }

            PlayerPrefs.SetInt("UnLocked" + 0 , 1);     // první level odemkne
        }


        // vykreslování jednotlivých levelů
        for (int i = 0; i < 40; i++)
        {
            Level level = LevelList[i];     // vytvoření třídy levelu


            GameObject newLevel = Instantiate(LevelPrefab) as GameObject;       // vytvoří se klon LevelPrefabu

            // z levelPrefabu se bere číslo levelu (string "1") a přenastavuje na NumberLevel (opravdové číslo levelu)
            LevelButton levelos = newLevel.GetComponentInChildren<LevelButton>();         // vytvoří se objekt třídy LevelButton (InChildren)
            levelos.LevelNumberText.text = level.NumberLevel;               // vytvoří TextMeshProGUI na tlačítku (číslo levelu)
            level.UnLocked = PlayerPrefs.GetInt("UnLocked" + i, 0);         // načítá z paměti, jestli je level un/locked
            levelos.UnLockedButton = level.UnLocked;        // vytvoří tlačítko objektu třídy LevelButton


            // pokud je level zamčený, zobrazí se na objektu obrázek zámečku
            if (level.UnLocked == 0)
            {
                levelos.LockedPanel.SetActive(true);
                levelos.unLockedPanel.SetActive(false);
            }


            // podmínkové řešení zobrazení levelů v LevelContaigneru
            if (Int32.Parse(levelos.LevelNumberText.text) <= 10)
            {
                newLevel.transform.SetParent(LevelContaigner1, false);
                // bool false zajišťuje možnost samostatného škálování objektu
                // bool true text vyškáluje stejně jako u Parent objektu, v tomto případě nežádoucí
            }
            else if (Int32.Parse(levelos.LevelNumberText.text) <= 20)
            {
                newLevel.transform.SetParent(LevelContaigner2, false);
            }
            else if (Int32.Parse(levelos.LevelNumberText.text) <= 30)
            {
                newLevel.transform.SetParent(LevelContaigner3, false);
            }
            else if (Int32.Parse(levelos.LevelNumberText.text) <= 40)
            {
                newLevel.transform.SetParent(LevelContaigner4, false);
            }
        }
    }


    // fce odemkne další level
    public static void Unlock()
    {
        NumberOfNextLevel = LevelSelector.get();    // uložení čísla levelu do proměnné

        PlayerPrefs.SetInt("UnLocked" + NumberOfNextLevel, 1);      // uloží do paměti, že další level je odemčený
        PlayerPrefs.SetInt("Poprve", 0);        // proměnnou first nastaví na nula (hráč vyhrál první level)
    }


    // fce načítá scénu DinoProfil
    public void LoadProfil()
    {
        SceneManager.LoadScene("DinoProfil");
    }

}





//      TRANSFORM

//Description

//Position, rotation and scale of an object.
//Every object in a Scene has a Transform. It's used to store and manipulate the position, rotation and scale of the object. Every Transform can have a parent, which allows you to apply position, rotation and scale hierarchically. This is the hierarchy seen in the Hierarchy pane. They also support enumerators so you can loop through children using:
//  -   může mít public metody a nějaké properties (věci na scale, position,...)

//public metoda Find() >> finds a child by n (parametr n) and returns it


//      na scalování ze "108"       https://docs.unity3d.com/ScriptReference/Transform-localScale.html      !použít
//      další užitečné info:        https://docs.unity3d.com/ScriptReference/Transform.html


//  *
// názvy levelů: 1, 2, 3, ...
//if (PlayerPrefs.GetInt(Int32.Parse(levelos.LevelNumberText.text)) == 1)
//if (Int32.Parse(levelos.LevelNumberText.text) == 1)
//{
//    Debug.Log(levelos.LevelNumberText.text);
//    level.UnLocked = 1;
//    // tady:            https://www.youtube.com/watch?v=xSDfSDTtUMs