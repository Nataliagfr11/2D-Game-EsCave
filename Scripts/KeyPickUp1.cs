using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifier si c’est le Player (tag = "Player")
        if (collision.CompareTag("Player"))
        {
            // Obtenir le script du joueur pour indiquer qu’il a récupéré la clé
            PlayerMovementIntermediaire player = collision.GetComponent<PlayerMovementIntermediaire>();
            if (player != null)
            {
                // Dans PlayerMovement, on mettra une variable hasKey = true
                player.hasKey = true;
            }

            // Détruire l’objet Key pour qu’il disparaisse visuellement
            Destroy(gameObject);
        }
    }
}

