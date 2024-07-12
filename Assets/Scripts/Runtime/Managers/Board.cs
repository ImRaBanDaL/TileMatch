using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Project Dependency")]
    [SerializeField] Tile tilePrefab; //Tile spawnlayabilmek için.

    [Header("Scene Dependency")]
    [SerializeField] Transform tileParent; //Tile'ýn spawnlanacaðý parent'ý.

    public Tile[] Tiles { get; private set; } //Tile instantiate yapýldýktan sonra tutulacaðý için bir array olþturuyoruz. Daha sonra bu listeye ulaþabilmek gerekecek. Bu yüzdne dýþarýdan okunabilir ama deðiþtirilemez olarak ayarlamamýz gerekiyor. Bunu get ve set ile yapýyoruz.

    private void Awake()
    {
        TouchEvents.OnElementTapped += TileTapped;
        PrepareTiles();
    }

    void OnDestroy()
    {
        TouchEvents.OnElementTapped -= TileTapped;
    }


    void PrepareTiles()
    {
        var tileCount = 5;
        Tiles = new Tile[tileCount]; //TODO: Change with level tile amount

        for (int i = 0; i < tileCount; i++)
        {
            Tiles[i] = Instantiate(tilePrefab, tileParent);
        }
    }

    void TileTapped(ITouchable touchable)
    {
        var tappedTile = touchable.gameObject.GetComponent<Tile>();
    }
    
}
