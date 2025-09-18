using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatKey : MonoBehaviour
{
    public float floatAmplitude = 0.2f; // hauteur de l’oscillation
    public float floatSpeed = 2f;       // vitesse de l’oscillation

    private Vector3 startPos;

    void Start()
    {
        // On stocke la position initiale
        startPos = transform.position;
    }

    void Update()
    {
        // Oscillation sur Y : sinusoïde
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        // On conserve x et z initiaux
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}

