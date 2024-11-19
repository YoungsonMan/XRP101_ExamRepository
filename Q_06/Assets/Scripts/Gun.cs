using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;


    
    public void Fire(Transform origin)
    {
        Ray ray = new(origin.position, Vector3.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            if(hit.transform.name == "Enemy")
            {
                Debug.Log($"{hit.transform.name} Hit!!");
                
            }
        }
    }

}
