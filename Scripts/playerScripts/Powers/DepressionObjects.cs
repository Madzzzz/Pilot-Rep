using UnityEngine;
using System.Collections;

public class DepressionObjects : MonoBehaviour {

    //Gjøre depression-objekter igjennomsiktige

    public bool transformed = false;
    public Shader shader1;
    public Shader shader2;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Transparent/Diffuse");

        rend.material.shader = shader1;
        rend.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void Transform()
    {
        transformed = !transformed;

        if (transformed == true)
        {
            rend.material.shader = shader2;
            rend.material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }

        if (transformed == false)
        {
            rend.material.shader = shader1;
            rend.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
