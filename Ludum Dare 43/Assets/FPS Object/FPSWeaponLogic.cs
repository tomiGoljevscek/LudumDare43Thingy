using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWeaponLogic : MonoBehaviour
{


    //state: 0 idle, 1 walk, 2 meele swing 3 bolts, 4 stream

    [System.Serializable]
    public class Weapon
    {
        public string name;
        [Header("Shots per minute")]
        public int attackSpeed;
        [Header("Damager per shot")]
        public int damage;
        [Header("Integer parameter for ring")]
        public int ringAnimationInteger;
        //meele, bolt, stream 
        [Header("Meele:2, Bolts:3, Stream:4")]
        public int animationType;
        [Header("Range of the weapon")]
        public float range;

        [HideInInspector]
        public float timeToNextFire = 0f;
    }




    [SerializeField]
    LayerMask layerToCheckWeapon;

    public Transform rayCastStart;

    public Weapon selectedWeapon;

    FPSController fpsController;

    public bool isFiring = false;


    public List<Weapon> weapons;


    // Use this for initialization
    void Start()
    {
        selectedWeapon = weapons[0];
        fpsController = GetComponent<FPSController>();

    }

    Vector3 rayOrigin;

    // Update is called once per frame
    void Update()
    {

        rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));


        if (Input.GetMouseButtonDown(0))
        {
            ShootAction();
        }
        else
        {
            isFiring = false;
        }
           
    }


    void ShootAction()
    {
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, selectedWeapon.range, layerToCheckWeapon))
        {
            isFiring = true;

        }
        
    }


}

