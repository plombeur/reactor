using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour 
{
    public Shader shader;

	void Start () 
    {
        camera.SetReplacementShader(shader,null);
	}
}
