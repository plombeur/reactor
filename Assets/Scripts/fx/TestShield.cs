using UnityEngine;
using System.Collections;

public class TestShield : MonoBehaviour
{
    public Material shieldMaterial;
    public float lifeTime;
    public float radius = 0.2f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            collider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
            GameObject impact = new GameObject("Shield Impact");
            MeshRenderer mesh = impact.AddComponent<MeshRenderer>();
            mesh.material = shieldMaterial;
            MeshFilter filter = impact.AddComponent<MeshFilter>();
            filter.mesh = GetComponent<MeshFilter>().mesh;
            Shield shield = impact.AddComponent<Shield>();
            shield.lifeTime = lifeTime;
            shield.radius = radius;
            impact.transform.parent = transform;
            impact.transform.localPosition = Vector3.zero;
            impact.transform.localScale = new Vector3(1, 1, 1);
            impact.transform.localRotation = Quaternion.Euler(Vector3.zero);
            shield.setTextureCoord(hit.textureCoord);
        }
        transform.rotation = Quaternion.LookRotation(Vector3.forward);

    }
    void FixedUpdate()
    {
        
       
    }
    void OnGUI()
    {

    }
}
