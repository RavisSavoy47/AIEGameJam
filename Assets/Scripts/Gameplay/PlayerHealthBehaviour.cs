using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : HealthBehaviour
{
    public Material DeathMaterial;

    public override void OnDeath()
    {
        base.OnDeath();

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer)
        {
            renderer.material = DeathMaterial;
        }
    }
}
