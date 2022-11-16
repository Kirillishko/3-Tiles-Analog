using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data", fileName = "Icons")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<Sprite> _tileIcons;
    [SerializeField] private Sprite _backgroundIcon;
    [SerializeField] private Sprite _specialTileIcon;
    [SerializeField] private AudioClip _clip;

    public IReadOnlyList<Sprite> TileIcons => _tileIcons;
    public Sprite BackgroundIcon => _backgroundIcon;
    public Sprite SpecialTileIcon=> _specialTileIcon;
    public AudioClip Clip => _clip;
}
