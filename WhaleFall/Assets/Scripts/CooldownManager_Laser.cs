using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownManager_Laser : MonoBehaviour
{
    public WeaponSystem myWeaponsystem;
    public Image imageCooldown_Laser;
    public TMP_Text textCooldown_Laser;
    private float _rCooldown_Laser;
    

    // Start is called before the first frame update
    void Start()
    {
       _rCooldown_Laser = 0f;
       myWeaponsystem._fireRateCounter = 1f;
       textCooldown_Laser.gameObject.SetActive(false);
       imageCooldown_Laser.fillAmount = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myWeaponsystem._fireRateCounter < myWeaponsystem.fireRate){
            _rCooldown_Laser = myWeaponsystem.fireRate - myWeaponsystem._fireRateCounter;
        }
        else{
            _rCooldown_Laser = 0f;
        }
       
        ApplyCooldown_Laser();
    }

    

    void ApplyCooldown_Laser(){
        if(_rCooldown_Laser == 0f){
            textCooldown_Laser.gameObject.SetActive(false);
            imageCooldown_Laser.fillAmount = 0f;
        }
        else{
            textCooldown_Laser.gameObject.SetActive(true);
            textCooldown_Laser.text = Mathf.RoundToInt(_rCooldown_Laser).ToString();
            imageCooldown_Laser.fillAmount = _rCooldown_Laser/myWeaponsystem.fireRate;
        }
    }
}
