using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Scope : MonoBehaviour
{
    //TODO: customize scopes per weapon (unique FOV and HUD images (iron sights too))

    public GameObject scopeHUD;

    public float scopedFOV = 10f;
    private float normalFOV;

    private Camera mainCamera;
    private Animator animator;
    private bool isScoped = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("L1"))
        {
            isScoped = !isScoped;
            animator.SetBool("IsScoped", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnscoped();
        }
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeHUD.SetActive(true);
        ToggleMask();
        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void OnUnscoped()
    {
        scopeHUD.SetActive(false);
        ToggleMask();
        mainCamera.fieldOfView = normalFOV;
    }

    void ToggleMask()
    {
        //XOR the weapons layer bit in the cullingMask bit mask
        mainCamera.cullingMask ^= 1 << LayerMask.NameToLayer("Weapons");
    }
}
