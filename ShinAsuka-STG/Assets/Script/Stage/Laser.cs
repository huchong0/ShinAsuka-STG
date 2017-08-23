using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    // Use this for initialization
    public int Attack;
	void Start () {

    }

    private void Awake()
    {
        Renderer meshRenderer = GetComponent<Renderer>();
        float a = 0;
        Color newColor = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g,
        meshRenderer.material.color.b, a);
        meshRenderer.material.color = newColor;
        StartCoroutine(Func());
        
    }

    // Update is called once per frame
    void Update () {

    }





    IEnumerator Func()
    {
        Renderer meshRenderer = GetComponent<Renderer>();

        for(int i=0;i<100;++i)
        {
            float a = meshRenderer.material.color.a;
            a += 0.01f;
            meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g,
            meshRenderer.material.color.b, a);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        for (int i = 0; i < 100; ++i)
        {
            float a = meshRenderer.material.color.a;
            a -= 0.01f;
            meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g,
            meshRenderer.material.color.b, a);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(gameObject);

    }
}
