using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


/*public class LightFilterController : MonoBehaviour
{
    public Color collisionColor = Color.red; // Farbe, auf die das Licht bei Kollision geändert werden soll
    public float colorChangeDuration = 1f; // Dauer der Farbänderung
    private Light globalLight; // Referenz auf das Light-Objekt

    void Start()
    {
        
        globalLight = GetComponent<Light>();
        Debug.Log("Start");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        StartCoroutine(ChangeColor()); // Startet die Coroutine für die Farbänderung
        Debug.Log("collisionDetected");
    }

    IEnumerator ChangeColor()
    {
        Color originalColor = globalLight.color; // Speichert die ursprüngliche Farbe des Lichts
        globalLight.color = collisionColor; // Ändert die Farbe des Lichts
        yield return new WaitForSeconds(colorChangeDuration); // Wartet für die angegebene Dauer
        globalLight.color = originalColor; // Setzt die Farbe des Lichts zurück
        Debug.Log("ChangedColor");
    }
}*/