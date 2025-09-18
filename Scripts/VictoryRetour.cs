using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryRetour : MonoBehaviour
{
    // Appelée quand on clique sur le bouton “Retour Menu”
    public void GoToMenu()
    {
        // Nom de la scène de menu, à adapter selon ton projet
        SceneManager.LoadScene("MenuPrincipal");
    }
}





