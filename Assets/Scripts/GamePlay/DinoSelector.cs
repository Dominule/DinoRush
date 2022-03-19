using UnityEngine;

public class DinoSelector : MonoBehaviour
{
    string selected;            // aktuálně vybraný dinosaurus

    // výběr objektů postavičky dinosaura
    public GameObject Dino1;
    public GameObject Dino2;
    public GameObject Dino3;
    public GameObject Dino4;
    public GameObject Dino5;

    void Start()
    {
        selected = PlayerPrefs.GetString("selectedDino", "Brontosaurus");       // načte z paměti hráčem vybraného dinosaura

        // podmínkové řešení výběru dinosaura a jeho zobrazení
        switch (selected)
        {
            case "Brontosaurus":
                Dino1.SetActive(true);
                break;
            case "Triceratops":
                Dino2.SetActive(true);
                break;
            case "T-Rex":
                Dino3.SetActive(true);
                break;
            case "Velociraptor":
                Dino4.SetActive(true);
                break;
            case "Styracosaurus":
                Dino5.SetActive(true);
                break;
        }
    }
}
