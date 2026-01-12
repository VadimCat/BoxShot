using UnityEngine;
using Fusion;

public class PlayerSkin : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(SetSkin))]
    private Color _skinColor { get; set; }

    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private Light _light;

    private void SetSkin()
    {
        foreach(var meshRenderer in _meshRenderers)
        {
            var propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetColor("_Color", color);
            meshRenderer.SetPropertyBlock(propertyBlock);
        }

        _light.color = color;
    }
}
