using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Paramètres de Mouvement")]
    public LayerMask groundLayers;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Statut du Joueur")]
    public bool hasKey = false;
    private bool isGrounded = false;
    private bool isDead = false; // Nouveau booléen pour suivre l'état de mort
    private bool isFading = false; // Nouveau booléen pour détecter si l'opacité diminue

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("Références")]
    public FadeOnKey fadeObject; // Assignez l'objet FadeOnKey dans l'inspecteur

    // Nouvelle variable pour désactiver les contrôles
    private bool controlsEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (fadeObject == null)
        {
            Debug.LogError("FadeOnKey n'est pas assigné dans l'inspecteur.");
        }
    }

    void Update()
    {
        if (isDead || isFading || !controlsEnabled) // Si le personnage est mort, en train de disparaître, ou les contrôles sont désactivés
            return;

        float moveInput = Input.GetAxis("Horizontal");

        // Déplacement du joueur
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip du sprite en fonction de la direction
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        // Détecter la course
        bool isRunning = Mathf.Abs(moveInput) > 0.1f;

        // Détecter le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimations(isRunning);
    }

    void FixedUpdate()
    {
        float rayDistance = 0.5f;
        // Distance sous les pieds (à ajuster si nécessaire)

        // Origine du rayon = le centre du perso - un offset vertical
        // Ajuste "- 0.5f" selon la hauteur de ton sprite
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);

        // On tire un rayon vers le bas
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayDistance, groundLayers);

        // Si on touche un collider (Ground ou Pushable), isGrounded = true
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // (Optionnel) visualiser le rayon dans la Scene
        Debug.DrawLine(rayOrigin, rayOrigin + Vector2.down * rayDistance, Color.red);
    }

    void UpdateAnimations(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Détection de collision avec un objet tagué "Door" et vérification de la clé
        if (other.CompareTag("Door") && hasKey && !isFading)
        {
            StartCoroutine(FadeOutAndDisable());
        }

        // Détection de collision avec un objet tagué "Key"
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("Clé récupérée !");
            // Optionnel : détruire ou désactiver l'objet clé
            Destroy(other.gameObject);
            // Ou bien : other.gameObject.SetActive(false);

            // Appeler AcquireKey sur FadeOnKey
            if (fadeObject != null)
            {
                fadeObject.AcquireKey();
            }
            else
            {
                Debug.LogError("FadeOnKey n'est pas assigné dans l'inspecteur.");
            }
        }
    }

    void Die()
    {
        isDead = true; // Le joueur est mort
        animator.Play("Death"); // Joue l'animation de mort
        controlsEnabled = false; // Désactive les contrôles
        rb.velocity = Vector2.zero; // Arrête tout mouvement
        rb.isKinematic = true; // Désactive la physique
    }

    IEnumerator FadeOutAndDisable()
    {
        isFading = true;
        controlsEnabled = false; // Désactive les contrôles
        rb.velocity = Vector2.zero; // Arrête tout mouvement
        rb.isKinematic = true; // Désactive la physique

        float fadeDuration = 1f; // Durée du fade en secondes
        float elapsedTime = 0f;

        Color originalColor = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Assurez-vous que l'opacité est bien à 0
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Optionnel : Détruire le joueur ou le désactiver après le fade
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
