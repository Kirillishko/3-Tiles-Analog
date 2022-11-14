using DG.Tweening;
using UnityEngine;

public class TileView : MonoBehaviour
{
    private const float MoveDuration = 1f;
    
    [SerializeField] private TileInventory _tileInventory;
    
    private SpriteRenderer _spriteRenderer;

    public void Init(Sprite icon)
    {
        _spriteRenderer.sprite = icon;
    }

    public void Move(Vector3 position)
    {
        transform.DOMove(position, MoveDuration).
            OnComplete(_tileInventory.TryFindEqualTiles);
    }

    public void Destroy()
    {
        Debug.Log("asd");
    }
}
