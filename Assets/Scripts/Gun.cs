using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


    [SerializeField] private float fireRate = 0;
    [SerializeField] private float damage = 10;
    [SerializeField] private LayerMask notToHit;
    [SerializeField] private Transform bulletTrailPrefab;
    [SerializeField] private Transform flashPrefab;

    private float timeToFire = 0;

    private Transform firePoint;

    private void Awake() {
        firePoint = transform.GetChild(0);

        if(firePoint == null) {
            Debug.LogError("Pas de FirePoint");
        }
    }

	void Update () {
        if (fireRate == 0) {
            if (Input.GetMouseButton(0)) {
                Shoot();
            }
        }else if(Input.GetMouseButton(0) && Time.time > timeToFire) {
            timeToFire = Time.time +1 / fireRate;
            Shoot();
        }

	}

    private void Shoot() {
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePosition = new Vector2(mousePositionWorld.x, mousePositionWorld.y);

        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, Mathf.Infinity, notToHit);

        Effect();
        
    }

    private void Effect() {
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform clone = Instantiate(flashPrefab, firePoint.position, firePoint.rotation) as Transform;

        float size = Random.Range(0.8f, 1f);

        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
    }
}
