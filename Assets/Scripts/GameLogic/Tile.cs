using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TileView))]
public class Tile : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private TileInventory _tileInventory;
    
    private TileView _tileView;
    private Sprite _icon;
    private int _hashCode;

    private void Start()
    {
        _hashCode = transform.GetHashCode();
        _tileView = GetComponent<TileView>();
        //_tileView.Init(_icon);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _input.SetHashCode(_hashCode);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_input.IsEqualHashCode(_hashCode))
        {
            _tileView.Move(_tileInventory.GetNextPosition);
        }
    }

    public void Destroy()
    {
        _tileView.Destroy();
    }
}
