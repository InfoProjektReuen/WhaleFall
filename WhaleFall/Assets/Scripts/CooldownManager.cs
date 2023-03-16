using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    public PlayerMovement myPlayerMovement;
    private float _rCooldown_Dash;
    private float _rCooldown_sJump;
    // Start is called before the first frame update
    void Start()
    {
       _rCooldown_Dash = 0f;
       _rCooldown_sJump = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayerMovement.cooldownTime_Dash - myPlayerMovement.lastDashTime < myPlayerMovement.cooldownTime_Dash){
            _rCooldown_Dash = myPlayerMovement.cooldownTime_Dash - myPlayerMovement.lastDashTime;
        }
        else{
            _rCooldown_Dash = 0f;
        }
        if (myPlayerMovement.cooldownTime_sJump - myPlayerMovement.lastSuperJumpTime < myPlayerMovement.cooldownTime_sJump){
            _rCooldown_sJump = myPlayerMovement.cooldownTime_sJump - myPlayerMovement.lastSuperJumpTime;
        }
        else{
            _rCooldown_sJump = 0f;
        }
    }
}
