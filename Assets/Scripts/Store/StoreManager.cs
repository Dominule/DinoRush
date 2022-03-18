using UnityEngine;
using UnityEngine.SceneManagement;      // pro překlikávání mezi scénami

// program přepíná na scénu DinoProfil

public class StoreManager : MonoBehaviour
{
    // fce přepíná na scénu DinoProfil
    public void LoadProfil()
    {
        SceneManager.LoadScene("DinoProfil");       // přepnutí na scénu DinoProfil
    }
}
