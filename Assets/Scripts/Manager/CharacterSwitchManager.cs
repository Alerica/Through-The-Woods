using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CharacterSwitchManager : MonoBehaviour
{
    public static CharacterSwitchManager Instance;
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

        Instance = this;
        SetActiveCharacter(redHood); 
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && _isWolfActive)
        {
            wolf.transform.position = redHood.transform.position;
        }
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

    public void ActivateWolf()
    {
        _isWolfActive = true;
    }
}
