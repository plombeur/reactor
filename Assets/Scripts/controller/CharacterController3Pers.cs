using UnityEngine;
using System.Collections;

public class CharacterController3Pers : MonoBehaviour 
{
    public CharacterControllerIsometric controller;

	void Start () 
    {
	
	}
	
	void Update () 
    {
        float deltaVertical, deltaHorizontal;
        Settings.controls.moveAxis(out deltaVertical, out deltaHorizontal);
        controller.move(transform.forward * deltaVertical + transform.right * deltaHorizontal);
	}
}
