using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSelector : MonoBehaviour
{
    string selected;

    public GameObject Dino1;
    public GameObject Dino2;
    public GameObject Dino3;
    public GameObject Dino4;
    public GameObject Dino5;
    //  přidat další dinosaury
    
    // Start is called before the first frame update
    void Start()
    {
        selected = PlayerPrefs.GetString("selectedDino", "Brontosaurus");
        Debug.Log(selected);


        if (selected == "Brontosaurus")
        {
            Dino1.SetActive(true);
        }
        else if (selected == "Triceratops")
        {
            Dino2.SetActive(true);
        }
        else if (selected == "T-Rex")
        {
            Dino3.SetActive(true);
        }
        else if (selected == "Velociraptor")
        {
            Dino4.SetActive(true);
        }
        else if (selected == "Styracosaurus")
        {
            Dino5.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
