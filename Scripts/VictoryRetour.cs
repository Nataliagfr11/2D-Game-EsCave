using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryRetour : MonoBehaviour
{
    // Appel�e quand on clique sur le bouton �Retour Menu�
    public void GoToMenu()
    {
        // Nom de la sc�ne de menu, � adapter selon ton projet
        SceneManager.LoadScene("MenuPrincipal");
    }
}





