using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthTextBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _healthText;
    [SerializeField]
    private PlayerHealthBehaviour _player;

    // Update is called once per frame
    void Update()
    {
        float health = _player.Health;

        if (health < 0) health = 0;

        _healthText.text = "Health: " + health;
    }
}
