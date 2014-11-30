using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    private static float PI2 = Mathf.PI / 2;
    public float lifeTime;
    public float radius = 0.2f;
    private Vector2 textureCoord;
    private float time;

    void Start()
    {
        renderer.materials[0].SetFloat("_radius", 0);
        renderer.materials[0].SetVector("_position", textureCoord);
        renderer.materials[0].SetFloat("_wave_percent", 0);
    }
    public void setTextureCoord(Vector2 coord)
    {
        this.textureCoord = coord;
    }
    void Update()
    {
        time += Time.deltaTime;
        float value;
        float alpha = PI2;

        float quartTime = 0.25f * lifeTime;
        float treeQuartTime = 0.75f * lifeTime;

        if (time <= quartTime)
            alpha = (time / quartTime) * PI2;
        else if (time >= treeQuartTime)
            alpha = PI2 + ((time - treeQuartTime) / quartTime) * PI2;

        value = Mathf.Sin(alpha) * radius;

        renderer.materials[0].SetFloat("_radius", Mathf.Clamp(value, 0, 1));
        renderer.materials[0].SetVector("_position", textureCoord);
        renderer.materials[0].SetFloat("_wave_percent", Mathf.Clamp(time*2/lifeTime,0,1.1f));
      //  renderer.materials[1].SetFloat("_radius", Mathf.Clamp(value, 0, 1));
        //renderer.materials[1].SetVector("_position", textureCoord);

        if (time >= lifeTime)
            Destroy(gameObject);
    }
}
