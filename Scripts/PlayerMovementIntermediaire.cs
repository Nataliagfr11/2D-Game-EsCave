using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIntermediaire : MonoBehaviour
{
    [Header("Param�tres de Mouvement")]
    public LayerMask groundLayers;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Statut du Joueur")]
    public bool hasKey = false;
    private bool isGrounded = false;
    private bool isDead = false; // Nouveau bool�en pour suivre l'�tat de mort
    private bool isFading = false; // Nouveau bool�en pour d�tecter si l'opacit� diminue

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("R�f�rences")]
    public FadeOnKey fadeObject; // Assignez l'objet FadeOnKey dans l'inspecteur

    [Header("R�f�rences UI")]
    public GameObject deathPanel; // Assigne le DeathPanel via l'inspecteur

    // Nouvelle variable pour d�sactiver les contr�les
    private bool controlsEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (fadeObject == null)
        {
            Debug.LogError("FadeOnKey n'est pas assign� dans l'inspecteur.");
        }
    }

    void Update()
    {
        if (isDead || isFading || !controlsEnabled) // Si le personnage est mort, en train de dispara�tre, ou les contr�les sont d�sactiv�s
            return;

        float moveInput = Input.GetAxis("Horizontal");

        // D�placement du joueur
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip du sprite en fonction de la direction
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        // D�tecter la course
        bool isRunning = Mathf.Abs(moveInput) > 0.1f;

        // D�tecter le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimations(isRunning);
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

        if (collision.gameObject.CompareTag("Spikes"))
        {
            Die();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // D�tection de collision avec un objet tagu� "Door" et v�rification de la cl�
        if (other.CompareTag("Door") && hasKey && !isFading)
        {
            StartCoroutine(FadeOutAndDisable());
        }

        // D�tection de collision avec un objet tagu� "Key"
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Debug.Log("Cl� r�cup�r�e !");
            // Optionnel : d�truire ou d�sactiver l'objet cl�
            Destroy(other.gameObject);
            // Ou bien : other.gameObject.SetActive(false);

            // Appeler AcquireKey sur FadeOnKey
            if (fadeObject != null)
            {
                fadeObject.AcquireKey();
            }
            else
            {
                Debug.LogError("FadeOnKey n'est pas assign� dans l'inspecteur.");
            }
        }
    }

    void Die()
    {
        isDead = true; // Le joueur est mort
        animator.Play("Death"); // Joue l'animation de mort
        controlsEnabled = false; // D�sactive les contr�les
        rb.velocity = Vector2.zero; // Arr�te tout mouvement
        rb.isKinematic = true; // D�sactive la physique

        // Affiche le panneau de mort
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("DeathPanel n'est pas assign� dans l'inspecteur.");
        }
    }


    IEnumerator FadeOutAndDisable()
    {
        isFading = true;
        controlsEnabled = false; // D�sactive les contr�les
        rb.velocity = Vector2.zero; // Arr�te tout mouvement
        rb.isKinematic = true; // D�sactive la physique

        float fadeDuration = 1f; // Dur�e du fade en secondes
        float elapsedTime = 0f;

        Color originalColor = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Assurez-vous que l'opacit� est bien � 0
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Optionnel : D�truire le joueur ou le d�sactiver apr�s le fade
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
