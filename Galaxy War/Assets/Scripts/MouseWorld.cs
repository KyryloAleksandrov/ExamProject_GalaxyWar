using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld Instance;
    [SerializeField] private LayerMask hexGridLayerMask;
    [SerializeField] private MapController mapController;

    private MapGridViewSingle lastMapGridViewSingle;
    //private MapGridView mapGridView;
    private GridSystem gridSystem;
    [SerializeField] GameObject visual;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gridSystem = ProjectContext.Instance.MapFunctionalService.GridSystem;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isOnGrid = Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, hexGridLayerMask);
        //Debug.Log(isOnGrid);
        if(isOnGrid)
        {
            visual.SetActive(true);
            transform.position = raycastHit.point;
            GridPosition currentGridPosition = gridSystem.GetHexGridPosition(raycastHit.point);
            if(gridSystem.IsInBounds(currentGridPosition))
            {
                if(lastMapGridViewSingle != null)
                {
                    lastMapGridViewSingle.Hide();
                }
                lastMapGridViewSingle = mapController.GetMapGridViewSingle(currentGridPosition);

                if(lastMapGridViewSingle != null)
                {
                    lastMapGridViewSingle.Show();
                }
            
                gridSystem.GetHexGridPosition(raycastHit.point);
            }
            
        }
        else
        {
            if(lastMapGridViewSingle != null)
            {
                lastMapGridViewSingle.Hide();
            }
            visual.SetActive(false);
        }
        
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.hexGridLayerMask);
        return raycastHit.point;
    }
}
