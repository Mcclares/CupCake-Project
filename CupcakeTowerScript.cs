using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeTowerScript : MonoBehaviour
{
    public int initialCost;
    // How much this tower costs when it is upgraded
    public int upgradingCost;
    // How much this tower is valuable if sold
    public int sellingValue;
    [Header("Shooting")]
    [Range(0,20)]
    [Tooltip("Максимальное расстояние до цели")]
    public float rangeRadius; // Максимальное расстояние до цели
    [Range(0,20)]
    [Tooltip("Время перезарядки")]
    public float reloadTime; // Время перезарядки
    [Tooltip("Projectile type that is fired from the Cupcake Tower ")]
    public GameObject projectilePrefab;  //Projectile type that is fired from the Cupcake Tower 
    [Tooltip("Time elapsed from the last time the Cupcake Tower has shoot")]
    private float elapsedTime;  //Time elapsed from the last time the Cupcake Tower has shot
    [Tooltip("Level of the CupCake Tower")]
    [Header("Upgrading")]
    private int upgradeLevel; //Level of the CupCake Tower
    public int UpgradeLevel { get => upgradeLevel; } 
    [Tooltip("Different sprites for the different levels of the Cupcake Tower")]
    public Sprite[] upgradeSprites;  //Different sprites for the different levels of the Cupcake Tower
    [Tooltip("Boolean to check if the tower is upgradable")]
    public bool isUpgradeable = true; //Boolean to check if the tower is upgradable
    public SpriteRenderer upgradeTower;
  


    // Start is called before the first frame update
    void Start()
    {
        upgradeTower = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime >= reloadTime) {
            elapsedTime = 0;

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
            if (hitColliders.Length != 0) {
                float min = int.MaxValue;
                int index = -1;

                for(int i = 0; i < hitColliders.Length; i++) {
                    if(hitColliders[i].tag == "Enemy") {
                        float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                        if(distance < min ) {
                            index = i;
                            min = distance;
                        }
                    }
                    

                }
                if( index == -1) return;
                // Получение направлении цели
                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;
                // Создание снаряда
                GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
                projectile.GetComponent<ProjectileScript>().direction = direction;
            }
        }
        elapsedTime += Time.deltaTime;
    }
    public void Upgrade() {
        if(!isUpgradeable) return;

        upgradeLevel++;

        if(upgradeLevel < upgradeSprites.Length) {
            isUpgradeable = false;
        }

        rangeRadius += 1f;
        reloadTime -= 0.5f;
        upgradeTower.sprite = upgradeSprites[upgradeLevel];

         sellingValue += 5;
        //Increase the upgrading cost
        upgradingCost += 10;

    }


}
