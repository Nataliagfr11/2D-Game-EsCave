using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelController : MonoBehaviour
{
    // M�thode appel�e lorsque le bouton "Recommencer" est cliqu�
    public void RestartLevel()
    {
        // Recharger la sc�ne actuelle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

