using UnityEngine;
using TMPro;

// program ˇumožňuje změnu jména na scéně DinoProfil

public class NameHalter : MonoBehaviour
{
    public TextMeshProUGUI NewNameText;     // nové jméno
    public TextMeshProUGUI DinoName;        // text jména zobrazující se na plátně

    public GameObject changingObject;       // přepisování jména
    public GameObject buttonOkay;           // tlačítko pro uložení nového jména
    public GameObject buttonNotOkay;        // tlačítko pro vymazání původního jména
   
    void Start()
    {
        DinoName.text = PlayerPrefs.GetString("DinoName", "Mirujem");       // načte z paměti aktuální jméno uživatele
    }


    // fce se volá při stisknutí tlačítka buttonNotOkay
    public void ChangeName()
    {
        DinoName.gameObject.SetActive(false);       // původní jméno se na plátně přestane zobrazovat
        buttonNotOkay.SetActive(false);             // stisknuté tlačítko se přestane zobrazovat
        changingObject.SetActive(true);     // zobrazení pole, kam uživatel napíše nové jméno
        buttonOkay.SetActive(true);         // zobrazí se tlačítko pro uložení nového jména 
    }


    // fce se volá při stisknutí tlačítka buttonOkay
    public void SaveName()
    {
        PlayerPrefs.SetString("DinoName", NewNameText.text);        // uložení nového jména do paměti
        changingObject.SetActive(false);        // pole pro psaní uživatele se přestane zobrazovat
        buttonOkay.SetActive(false);            // deaktivace buttonOkay
        buttonNotOkay.SetActive(true);          // aktivace buttonNotOkay
        DinoName.gameObject.SetActive(true);    // zobrazení nového jména v textovém poli
        DinoName.text = PlayerPrefs.GetString("DinoName", "Mirujem");       // zobrazení nového jména na plátně
    }
}
