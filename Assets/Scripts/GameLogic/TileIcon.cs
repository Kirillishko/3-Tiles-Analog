using UnityEngine;

public struct TileIcon
{
  public Sprite Icon { get; }
  public byte Index { get; }

  public TileIcon(Sprite icon, byte index)
  {
    Icon = icon;
    Index = index;
  }
}
