using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownManager : MonoBehaviour
{
    public PlayerMovement myPlayerMovement;
    public Image imageCooldown_sJump;
    public TMP_Text textCooldown_sJump;
    private float _rCooldown_Dash;
    private float _rCooldown_sJump;

    // Start is called before the first frame update
    void Start()
    {
       _rCooldown_Dash = 0f;
       _rCooldown_sJump = 0f;
       textCooldown_sJump.gameObject.SetActive(false);
       imageCooldown_sJump.fillAmount = 0f;
        
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
        if (Time.time - myPlayerMovement.lastSuperJumpTime < myPlayerMovement.cooldownTime_sJump){
            _rCooldown_sJump = myPlayerMovement.cooldownTime_sJump - (Time.time - myPlayerMovement.lastSuperJumpTime);
        }
        else{
            _rCooldown_sJump = 0f;
        }
        ApplyCooldown_sJump();
    }

    void ApplyCooldown_sJump(){
        if(_rCooldown_sJump == 0f){
            textCooldown_sJump.gameObject.SetActive(false);
            imageCooldown_sJump.fillAmount = 0f;
        }
        else{
            textCooldown_sJump.gameObject.SetActive(true);
            textCooldown_sJump.text = Mathf.RoundToInt(_rCooldown_sJump).ToString();
            imageCooldown_sJump.fillAmount = _rCooldown_sJump/myPlayerMovement.cooldownTime_sJump;
        }
    }
}
