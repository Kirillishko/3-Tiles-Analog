using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TileView : MonoBehaviour
{
    private const float MoveDuration = 1f;
    
    [SerializeField] private TileInventory _tileInventory;
    [SerializeField] private Image _image;

    private Tile _tile;

    public void Init(TileInventory tileInventory, Sprite icon)
    {
        _tileInventory = tileInventory;
        _image.sprite = icon;

        var endScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(endScale, 0.3f);
    }

    public void Move(Vector3 position, bool withChecks = true)
    {
        var move = transform.DOMove(position, MoveDuration);
        
        if (withChecks)
            move.OnComplete(_tileInventory.TryFindEqualTiles);
    }

    public void Destroy()
    {
        Debug.Log("asd");
    }
}
