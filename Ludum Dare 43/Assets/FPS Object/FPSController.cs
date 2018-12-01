using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    public int health = 100;



    //state: 0 idle, 1 walk, 2 meele swing 3 bolts, 4 stream
    [SerializeField]
    Animator animator;

    Manoeuvre.ManoeuvreFPSController manController;
    FPSWeaponLogic weaponLogic;



    


    // Use this for initialization
    void Start()
    {
        manController = GetComponent<Manoeuvre.ManoeuvreFPSController>();
        weaponLogic = GetComponent<FPSWeaponLogic>();

        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButton(0))
        {
            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }



        
        if (weaponLogic.isFiring)
        {
            animator.SetInteger("state", weaponLogic.selectedWeapon.animationType);
        }
        
        //walking check at the end
        else if (manController.Locomotion.CurrentPlayerState == Manoeuvre.PlayerStates.Walking)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }




    }





}