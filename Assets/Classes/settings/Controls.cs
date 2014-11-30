using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Controls : SettingsObject
{
    public const string FORWARD = "forward";
    public const string BACKWARD = "backward";
    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string CAMERA_ROTATE_LEFT = "camera_rotate_left";
    public const string CAMERA_ROTATE_RIGHT = "camera_rotate_right";
    public const string FLASHLIGHT = "flashlight";

    public Controls(string path): base(path, getControlsTemplate())
    {
      
    }
    public void moveAxis(out float vertical, out float horizontal)
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(getSetting(FORWARD).getKey()))
            vertical += 1;
        if (Input.GetKey(getSetting(BACKWARD).getKey()))
            vertical -= 1;
        if (Input.GetKey(getSetting(LEFT).getKey()))
            horizontal -= 1;
        if (Input.GetKey(getSetting(RIGHT).getKey()))
            horizontal += 1;

        horizontal = Mathf.Clamp(horizontal, -1, 1);
        vertical = Mathf.Clamp(vertical, -1, 1);

        float length = Mathf.Sqrt(Mathf.Pow(vertical, 2) + Mathf.Pow(horizontal, 2));
        vertical = vertical / length;
        horizontal = horizontal / length;
    }
    public bool getKeyDown(string settingKey)
    {
        return Input.GetKeyDown(getSetting(settingKey).getKey());
    }
    public bool getKey(string settingKey)
    {
        return Input.GetKey(getSetting(settingKey).getKey());
    }
    public float scrollAxis()
    {
        return Input.GetAxisRaw("Axis3");
    }
    public static List<Setting> getControlsTemplate()
    {
        List<Setting> settings = new List<Setting>();
        settings.Add(new Setting(FORWARD, KeyCode.Z));
        settings.Add(new Setting(BACKWARD, KeyCode.S));
        settings.Add(new Setting(LEFT, KeyCode.Q));
        settings.Add(new Setting(RIGHT, KeyCode.D));
        settings.Add(new Setting(CAMERA_ROTATE_LEFT, KeyCode.A));
        settings.Add(new Setting(CAMERA_ROTATE_RIGHT, KeyCode.E));
        settings.Add(new Setting(FLASHLIGHT, KeyCode.F));
        return settings;
    }
}

