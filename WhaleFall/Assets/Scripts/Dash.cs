using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
    [SerializeField] private float dashDistance = 10f;

    void Update()
    {
        if(CanMove(transform.forward, dashDistance)){
            handleDash();
        }
    }

    
    private bool CanMove(Vector2 dir, float distance){
        return (Physics2D.Raycast(transform.position, dir, distance).collider == null);
    }
    
    private void handleDash(){
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
            
            transform.position += transform.forward * dashDistance;
        }
    }
}
