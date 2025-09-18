using UnityEngine;

public class FlipOnDirectionChange : MonoBehaviour
{
    public Transform topPoint; // Point haut
    public Transform bottomPoint; // Point bas
    public float speed = 2f; // Vitesse de d�placement
    private Vector3 targetPosition; // Position cible actuelle
    private bool isFacingRight = true; // Indique si l'objet est orient� � droite

    void Start()
    {
        // Initialiser la cible sur le point haut
        targetPosition = topPoint.position;
    }

    void Update()
    {
        // D�placer l'objet vers la cible
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // V�rifier si l'objet a atteint la cible
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Basculer la cible entre le haut et le bas
            targetPosition = targetPosition == topPoint.position ? bottomPoint.position : topPoint.position;

            // Inverser l'�chelle pour flipper l'objet
            Flip();
        }
    }

    void Flip()
    {
        // Inverser la valeur de isFacingRight
        isFacingRight = !isFacingRight;

        // Modifier l'�chelle pour inverser l'objet sur l'axe X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Inverser l'axe X
        transform.localScale = localScale;
    }
}
