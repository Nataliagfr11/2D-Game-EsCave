using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger1 : MonoBehaviour
{
    public GameObject winPanel; // Le panneau avec "You Win!" et le bouton

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si c'est le joueur
        if (collision.CompareTag("Player"))
        {
            // R�cup�re le script PlayerMovement
            PlayerMovementIntermediaire player = collision.GetComponent<PlayerMovementIntermediaire>();
            // V�rifie � la fois qu'il existe ET qu'il a la cl�
            if (player != null && player.hasKey)
            {
                // S'il a la cl�, on affiche le panneau de victoire
                if (winPanel != null)
                {
                    winPanel.SetActive(true);
                }
            }
            else
            {
                // Optionnel : un message disant qu'il faut la cl�
                Debug.Log("Il te faut la cl� pour gagner !");
            }
        }
    }
}






