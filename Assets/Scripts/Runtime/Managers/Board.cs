using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab; //Tile spawnlayabilmek için.

    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent; //Tile'ýn spawnlanacaðý parent'ý.

    /*Tile instantiate yapýldýktan sonra tutulacaðý için bir array olþturuyoruz. Daha sonra bu listeye ulaþabilmek gerekecek. Bu yüzdne dýþarýdan okunabilir ama deðiþtirilemez olarak ayarlamamýz gerekiyor. 
     * Bunu get ve set ile yapýyoruz.*/

    public Tile[] Tiles { get; private set; }


    void PrepareTile()
    {
        var tileCount = 5;
        Tiles = new Tile[tileCount]; //TODO: Change with level tile amount

        for (int i = 0; i < tileCount; i++)
        {
            Tiles[i] = Instantiate(tilePrefab, tileParent);
        }
    }
    
}
