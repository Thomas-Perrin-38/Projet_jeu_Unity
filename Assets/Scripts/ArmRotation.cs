using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public GameObject myPlayer;

	void Update () {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        mousePosition.Normalize();

        float rotationZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) {
            if (myPlayer.transform.eulerAngles.y == 0) {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);

            }else if(myPlayer.transform.eulerAngles.y == 180) {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }
}
