using UnityEngine;
using System.Collections;

public class FadeOnKey : MonoBehaviour
{
    [Header("Paramètres de Fade")]
    public float fadeSpeed = 1.0f;    // Vitesse d'augmentation de l'opacité

    private SpriteRenderer spriteRenderer;
    private bool isFading = false;    // Pour éviter de lancer plusieurs coroutines

    void Start()
    {
        // Récupère le SpriteRenderer attaché à cet objet
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Le composant SpriteRenderer est manquant sur cet objet.");
        }
        else
        {
            // Initialise l'opacité à 0
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    void Update()
    {
        // Aucune logique nécessaire ici si nous utilisons une méthode publique pour déclencher le fade
    }

    private IEnumerator FadeIn()
    {
        isFading = true;

        while (spriteRenderer.color.a < 1.0f)
        {
            // Augmente progressivement l'opacité
            Color color = spriteRenderer.color;
            color.a += fadeSpeed * Time.deltaTime;
            color.a = Mathf.Clamp01(color.a); // S'assure que la valeur est entre 0 et 1
            spriteRenderer.color = color;

            yield return null; // Attend le prochain frame
        }

        isFading = false; // Le fade est terminé
    }

    // Méthode publique pour démarrer le fade
    public void AcquireKey()
    {
        if (!isFading)
        {
            StartCoroutine(FadeIn());
            Debug.Log("FadeIn démarré.");
        }
    }
}
