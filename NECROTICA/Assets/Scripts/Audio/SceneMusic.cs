using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("LevelMusic");
        AudioManager.instance.Play("Embient");
    }
}
