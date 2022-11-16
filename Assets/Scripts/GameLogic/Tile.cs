using System;using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TileView))]
public class Tile : MonoBehaviour, IEquatable<Tile>, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private TileInventory _tileInventory;
    
    private TileView _tileView;
    private int _hashCode;
    private int _index;

    private void Awake()
    {
        _hashCode = transform.GetHashCode();
        _tileView = GetComponent<TileView>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _input.SetHashCode(_hashCode);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_input.IsEqualHashCode(_hashCode) == false)
            return;


        if (_tileInventory.TryGetFreePosition(this, out var position))
            Move(position);
    }

    public void Init(PlayerInput playerInput, TileInventory tileInventory, TileIcon tileIcon)
    {
        _input = playerInput;
        _tileInventory = tileInventory;
        _index = tileIcon.Index;
        _tileView.Init(tileInventory, tileIcon.Icon);
    }

    public void Move(Vector3 position, bool withChecks = true)
    {
        _tileView.Move(position, false);
    }

    public void Destroy()
    {
        _tileView.Destroy();
    }

    public bool Equals(Tile tile)
    {
        if (tile == null)
            return false;
        
        return _index == tile._index;
    }
}
