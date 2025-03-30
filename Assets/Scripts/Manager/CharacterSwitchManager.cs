using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CharacterSwitchManager : MonoBehaviour
{
    public GameObject redHood;
    public GameObject wolf;
    public CinemachineCamera cinemachineCam; 

    private PlayerInput redHoodInput;
    private PlayerInput wolfInput;

    [SerializeField] private bool _isWolfActive = false;

    private void Start()
    {
        redHoodInput = redHood.GetComponent<PlayerInput>();
        wolfInput = wolf.GetComponent<PlayerInput>();

        SetActiveCharacter(redHood); 
    }

    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame && _isWolfActive) 
        {
            SwitchCharacter();
        }
    }

    private void SwitchCharacter()
    {
        if (redHoodInput.enabled)
        {
            SetActiveCharacter(wolf);
        }
        else
        {
            SetActiveCharacter(redHood);
        }
    }

    private void SetActiveCharacter(GameObject character)
    {
        redHoodInput.enabled = (character == redHood);
        wolfInput.enabled = (character == wolf);

        cinemachineCam.Follow = character.transform;
    }

    private void ActivateWolf()
    {
        _isWolfActive = true;
    }
}
