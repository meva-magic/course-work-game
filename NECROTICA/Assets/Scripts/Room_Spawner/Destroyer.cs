using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string expml = "Sword";
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer(expml))
        Destroy(other.gameObject);
    }
}
