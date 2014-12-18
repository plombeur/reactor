﻿using UnityEngine;
using System.Collections;

public class CharacterControllerIsometricPlayer : MonoBehaviour
{
    public CharacterControllerIsometric controller;

    private static Plane plane = new Plane();

    public bool canFire = true;
    public bool canFlashlight = true;

    void Start()
    {

    }

    void Update()
    {

        if (canFlashlight && Settings.controls.getKeyDown(Controls.FLASHLIGHT))
            controller.setFlashLight(!controller.isFlashLight());
        else if (!canFlashlight)
            controller.setFlashLight(false);

        if (canFire && Settings.controls.getKey(Controls.FIRE))
            GetComponent<AutoFire>().firing = true;
        else
            GetComponent<AutoFire>().firing = false;

        float deltaVertical, deltaHorizontal ;
        Settings.controls.moveAxis(out deltaVertical, out deltaHorizontal);
        Vector3 moveDirVertical = Camera.main.transform.forward;
        moveDirVertical.y = 0;
        moveDirVertical.Normalize();
        Vector3 moveDirHorizontal = -Vector3.Cross(moveDirVertical, Vector3.up);
        Vector3 moveDirTotal = (moveDirVertical * deltaVertical + moveDirHorizontal * deltaHorizontal).normalized;
        controller.move(moveDirTotal);

        float distance;
        plane.SetNormalAndPosition(Vector3.up, transform.position);
        Ray mouseRay = (Camera.main.ScreenPointToRay(Input.mousePosition));
        if (plane.Raycast(mouseRay, out distance))
            controller.lookAt(mouseRay.GetPoint(distance));

        UseSystem system = GetComponent<UseSystem>();
        if (system.getUsable() != null && Input.GetKeyDown(KeyCode.E))
            system.getUsable().use();
    }
}
