using UnityEngine;

public class BoxBlockVisualiser : MonoBehaviour
{
    [SerializeField] private bool isBlocked;
    [SerializeField] private Material blockedMaterial;
    [SerializeField] private Material unblockedMaterial;


    private MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        SetMaterial();
    }

    public void SetBlockState(bool isBlocked)
    {
        this.isBlocked = isBlocked;
        SetMaterial();
    }

    private void Update()
    {
        SetMaterial();
    }

    private void SetMaterial()
    {
        _renderer.material = isBlocked ? blockedMaterial : unblockedMaterial;
    }
}