using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// třída připojena k prefabu levelu
// data využívá program LevelManager
public class LevelButton : MonoBehaviour
{
    public TextMeshProUGUI LevelNumberText;     // název levelu
    public GameObject LockedPanel;          // objekt zamčeného levelu
    public GameObject unLockedPanel;        // objekt odemčeného levelu
    public int UnLockedButton;        // 0 = locked       1 = unlocked
}
