using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


/*public class LightFilterController : MonoBehaviour
{
    public Color collisionColor = Color.red; // Farbe, auf die das Licht bei Kollision ge�ndert werden soll
    public float colorChangeDuration = 1f; // Dauer der Farb�nderung
    private Light globalLight; // Referenz auf das Light-Objekt

    void Start()
    {
        
        globalLight = GetComponent<Light>();
        Debug.Log("Start");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        StartCoroutine(ChangeColor()); // Startet die Coroutine f�r die Farb�nderung
        Debug.Log("collisionDetected");
    }

    IEnumerator ChangeColor()
    {
        Color originalColor = globalLight.color; // Speichert die urspr�ngliche Farbe des Lichts
        globalLight.color = collisionColor; // �ndert die Farbe des Lichts
        yield return new WaitForSeconds(colorChangeDuration); // Wartet f�r die angegebene Dauer
        globalLight.color = originalColor; // Setzt die Farbe des Lichts zur�ck
        Debug.Log("ChangedColor");
    }
}*/