using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material crossSectionMaterial; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 2;
        
    }
}
