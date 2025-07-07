using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader3D : BaseLevelLoader
{

    [SerializeField] private GameObject bombTile;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private float cellSize;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject BuildingBlock;
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override GameObject BombTile => bombTile;
    protected override GameObject TilePrefab => tilePrefab;
    public override Transform GridParent => gridParent;
    protected override float CellSize => cellSize;
    public override RectTransform gridParentRectTransform => null; // this is for 2d class. ovveride it
    protected override GameObject buildingBlock => BuildingBlock;
    protected override void SetTilePosition(GameObject tile, int x, int y)
    {
        tile.transform.localPosition = new Vector3(x * CellSize, 0f, y * -CellSize);
    }


}
