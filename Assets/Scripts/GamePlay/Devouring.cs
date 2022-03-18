using UnityEngine;

// program zapíná objekt žraného pterodaktyla

public class Devouring : MonoBehaviour
{
    public static GameObject devouring;
    static string Dino;

    public static void devour()
    {
        Dino = PlayerPrefs.GetString("selectedDino");

        if (Score.devouredInt == 1 && Dino == "T-Rex")
            devouring = GameObject.Find("Dinosaurs/TrexGreen/TrexDevour/DevouredOrange");       //neplatí pro velociraptora !!!!
        else if (Score.devouredInt == 1 && Dino == "Velociraptor")
            devouring = GameObject.Find("Dinosaurs/VelocYellow/VelocDevour/DevouredOrange");
        else if (Score.devouredInt == 2 && Dino == "T-Rex")
            devouring = GameObject.Find("Dinosaurs/TrexGreen/TrexDevour/DevouredBlue");
        else if (Score.devouredInt == 2 && Dino == "Velociraptor")
            devouring = GameObject.Find("Dinosaurs/VelocYellow/VelocDevour/DevouredBlue");

        devouring.SetActive(true);
    }
}
