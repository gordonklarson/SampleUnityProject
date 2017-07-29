using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRoad : MonoBehaviour
{

    [SerializeField]
    private Material roadMaterial;

    [SerializeField]
    private float animationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	    if (roadMaterial == null)
	    {
	        roadMaterial = GetComponent<MeshRenderer>().materials[0];
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    roadMaterial.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0.0f);
	}
}
