using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger1 : MonoBehaviour
{
    public GameObject winPanel; // Le panneau avec "You Win!" et le bouton

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si c'est le joueur
        if (collision.CompareTag("Player"))
        {
            // Récupère le script PlayerMovement
            PlayerMovementIntermediaire player = collision.GetComponent<PlayerMovementIntermediaire>();
            // Vérifie à la fois qu'il existe ET qu'il a la clé
            if (player != null && player.hasKey)
            {
                // S'il a la clé, on affiche le panneau de victoire
                if (winPanel != null)
                {
                    winPanel.SetActive(true);
                }
            }
            else
            {
                // Optionnel : un message disant qu'il faut la clé
                Debug.Log("Il te faut la clé pour gagner !");
            }
        }
    }
}






