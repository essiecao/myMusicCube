using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
public class SliceObject : MonoBehaviour
{
    // public Transform planeDebug;
    // public GameObject target;
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;

    public Material crossSectionMaterial;
    public float cutForce = 2000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
          GameObject target = hit.transform.gameObject;  
          Slice(target);
          Debug.DrawLine(startSlicePoint.position, endSlicePoint.position, Color.red, 0.1f);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 planeNormal = transform.up;  
        Debug.DrawRay(endSlicePoint.position, planeNormal * 0.2f, Color.green, 0.2f);

        Material mat = crossSectionMaterial;
        Cube cubeScript = target.GetComponent<Cube>();
        if (cubeScript != null && cubeScript.crossSectionMaterial != null)
        {
            mat = cubeScript.crossSectionMaterial;
        }


        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedComponent(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedComponent(lowerHull);
            Destroy(target);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true; 
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);

    }
}
