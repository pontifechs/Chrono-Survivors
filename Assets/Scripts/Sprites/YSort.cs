using UnityEngine;

public class YSort : MonoBehaviour
{
    [SerializeField] bool dynamic;

    // Start is called before the first frame update
    void Start()
    {
        updatedSortOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (dynamic)
        {
            updatedSortOrder();
        }
    }

    private void updatedSortOrder()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
    }
}
