using UnityEngine;
using Fusion;

public class PlayerSkin : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(UpdateRender))]
    private Color SkinColor { get; set; }

    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private Light _light;

    private void UpdateRender()
    {
        foreach(var meshRenderer in _meshRenderers)
        {
            var propertyBlock = new MaterialPropertyBlock();
            meshRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_BaseColor", SkinColor);
            meshRenderer.SetPropertyBlock(propertyBlock);
            // meshRenderer.material.color = SkinColor;
        }

        _light.color = SkinColor;
    }

    public void SetSkin(Color color)
    {
        SkinColor = color;
        UpdateRender();
    }
}
