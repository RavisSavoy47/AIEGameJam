using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBehaviour : MonoBehaviour
{
    private PlayerMovementBehaviour _playerMovement;
    [SerializeField]
    private BulletProjectileBehaviour _gun;

    // Start is called before the first frame update
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMovement.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        _playerMovement.MouseDirection = new Vector2(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY")).normalized;
    }

    //only fires if your clicking on the player
    private void OnMouseDown()
    {
        _gun.Fire();
    }
}
