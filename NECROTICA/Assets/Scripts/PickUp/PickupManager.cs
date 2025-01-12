using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [Header("Keys Status")]
    public bool yellowKeyPickedUp = false;
    public bool redKeyPickedUp = false;


    public void UpdateKeyStatus(string keyTag)
    {
        if (keyTag == "YellowKey")
        {
            yellowKeyPickedUp = true;
        }
        else if (keyTag == "RedKey")
        {
            redKeyPickedUp = true;
        }
    }
}
