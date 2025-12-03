using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoPyramidSpawner : MonoBehaviour
{
    [Header("References")]
    public MyTouchableBlocks touchableBlock;
    public GameObject tomatoPrefab;
    public Transform container;

    [Header("Placement Settings")]
    public float layerHeight = 0.02f;
    public float spacing = 0.15f;
    public float baseYOffset = 0.08f;

    private const int BASE_COUNT = 12;
    private const int MID_COUNT = 6;
    private const int TOP_COUNT = 1;

    private void Start()
    {
        if (touchableBlock == null)
            touchableBlock = GetComponent<MyTouchableBlocks>();

        GenerateTomatoes();
    }

    void GenerateTomatoes()
    {
        /* 19'DAN SONRA PİRAMİT OLMASI İÇİN
        // eski domatesleri temizle
        foreach (Transform child in container)
            Destroy(child.gameObject);

        int score = touchableBlock.score;

        // 20 ve üstünde görüntü 19 olarak sabit kalsın
        int count = Mathf.Min(score, 19);

        int baseToSpawn = Mathf.Min(count, BASE_COUNT);
        int midToSpawn = Mathf.Clamp(count - BASE_COUNT, 0, MID_COUNT);
        int topToSpawn = (count == 19) ? 1 : 0;

        SpawnBaseLayer(baseToSpawn);
        SpawnMidLayer(midToSpawn);
        if (topToSpawn == 1)
            SpawnTopLayer();
        */
        
        // 19'DAN SONRA 3X4 DOLU OLMASI İÇİN
        // eski domatesleri temizle
        foreach (Transform child in container)
            Destroy(child.gameObject);

        int score = touchableBlock.score;

        // ---------------------------------------------
        // 20 ve ÜSTÜ → HER KAT FULL 4x3 (12 adet)
        // ---------------------------------------------
        if (score >= 20)
        {
            // 1. kat
            SpawnGrid(12, 4, 3, 0);

            // 2. kat
            SpawnGrid(12, 4, 3, 1);

            // 3. kat
            SpawnGrid(12, 4, 3, 2);

            return; // piramit kısmına geçmiyoruz
        }

        // ---------------------------------------------
        // 1–19 → Normal piramit sistemi
        // ---------------------------------------------

        int count = Mathf.Min(score, 19);

        int baseToSpawn = Mathf.Min(count, BASE_COUNT);
        int midToSpawn = Mathf.Clamp(count - BASE_COUNT, 0, MID_COUNT);
        int topToSpawn = (count == 19) ? 1 : 0;

        SpawnBaseLayer(baseToSpawn);
        SpawnMidLayer(midToSpawn);

        if (topToSpawn == 1)
            SpawnTopLayer();
        
    }

    void SpawnBaseLayer(int count)
    {
        SpawnGrid(count, 4, 3, 0); // 4x3 taban
    }

    void SpawnMidLayer(int count)
    {
        SpawnGrid(count, 3, 2, 1); // 3x2 orta kat
    }

    void SpawnGrid(int count, int cols, int rows, int layerIndex)
    {
        float y = layerHeight * layerIndex;

        int spawned = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (spawned >= count)
                    return;

                Vector3 localPos = new Vector3(
                    (c - (cols - 1) / 2f) * spacing,
                    y + baseYOffset,
                    (r - (rows - 1) / 2f) * spacing
                );

                Instantiate(
                    tomatoPrefab,
                    container.TransformPoint(localPos),
                    Quaternion.identity,
                    container);

                spawned++;
            }
        }
    }

    void SpawnTopLayer()
    {
        Vector3 pos = new Vector3(0, baseYOffset + layerHeight * 2, 0);

        Instantiate(
            tomatoPrefab,
            container.TransformPoint(pos),
            Quaternion.identity,
            container
        );
    }

}
