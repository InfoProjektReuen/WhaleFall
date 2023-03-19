using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownManager_Dash : MonoBehaviour
{
    public PlayerMovement myPlayerMovement;
    public Image imageCooldown_Dash;
    public TMP_Text textCooldown_Dash;
    private float _rCooldown_Dash;
    

    // Start is called before the first frame update
    void Start()
    {
       _rCooldown_Dash = 0f;
       textCooldown_Dash.gameObject.SetActive(false);
       imageCooldown_Dash.fillAmount = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - myPlayerMovement.lastDashTime < myPlayerMovement.cooldownTime_Dash){
            _rCooldown_Dash = myPlayerMovement.cooldownTime_Dash - (Time.time - myPlayerMovement.lastDashTime);
        }
        else{
            _rCooldown_Dash = 0f;
        }
       
        ApplyCooldown_Dash();
    }

    

    void ApplyCooldown_Dash(){
        if(_rCooldown_Dash == 0f){
            textCooldown_Dash.gameObject.SetActive(false);
            imageCooldown_Dash.fillAmount = 0f;
        }
        else{
            textCooldown_Dash.gameObject.SetActive(true);
            textCooldown_Dash.text = Mathf.RoundToInt(_rCooldown_Dash).ToString();
            imageCooldown_Dash.fillAmount = _rCooldown_Dash/myPlayerMovement.cooldownTime_Dash;
        }
    }
}
