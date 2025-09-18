using UnityEngine;
using System.Collections;

public class FadeOnKey : MonoBehaviour
{
    [Header("Param�tres de Fade")]
    public float fadeSpeed = 1.0f;    // Vitesse d'augmentation de l'opacit�

    private SpriteRenderer spriteRenderer;
    private bool isFading = false;    // Pour �viter de lancer plusieurs coroutines

    void Start()
    {
        // R�cup�re le SpriteRenderer attach� � cet objet
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Le composant SpriteRenderer est manquant sur cet objet.");
        }
        else
        {
            // Initialise l'opacit� � 0
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    void Update()
    {
        // Aucune logique n�cessaire ici si nous utilisons une m�thode publique pour d�clencher le fade
    }

    private IEnumerator FadeIn()
    {
        isFading = true;

        while (spriteRenderer.color.a < 1.0f)
        {
            // Augmente progressivement l'opacit�
            Color color = spriteRenderer.color;
            color.a += fadeSpeed * Time.deltaTime;
            color.a = Mathf.Clamp01(color.a); // S'assure que la valeur est entre 0 et 1
            spriteRenderer.color = color;

            yield return null; // Attend le prochain frame
        }

        isFading = false; // Le fade est termin�
    }

    // M�thode publique pour d�marrer le fade
    public void AcquireKey()
    {
        if (!isFading)
        {
            StartCoroutine(FadeIn());
            Debug.Log("FadeIn d�marr�.");
        }
    }
}
