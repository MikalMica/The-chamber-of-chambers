using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSpriteMaterial(Material material) {
        _spriteRenderer.material = material;
    }
}
