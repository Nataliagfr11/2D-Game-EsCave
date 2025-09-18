using UnityEngine;

public class FlipOnDirectionChange : MonoBehaviour
{
    public Transform topPoint; // Point haut
    public Transform bottomPoint; // Point bas
    public float speed = 2f; // Vitesse de déplacement
    private Vector3 targetPosition; // Position cible actuelle
    private bool isFacingRight = true; // Indique si l'objet est orienté à droite

    void Start()
    {
        // Initialiser la cible sur le point haut
        targetPosition = topPoint.position;
    }

    void Update()
    {
        // Déplacer l'objet vers la cible
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Vérifier si l'objet a atteint la cible
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Basculer la cible entre le haut et le bas
            targetPosition = targetPosition == topPoint.position ? bottomPoint.position : topPoint.position;

            // Inverser l'échelle pour flipper l'objet
            Flip();
        }
    }

    void Flip()
    {
        // Inverser la valeur de isFacingRight
        isFacingRight = !isFacingRight;

        // Modifier l'échelle pour inverser l'objet sur l'axe X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Inverser l'axe X
        transform.localScale = localScale;
    }
}
