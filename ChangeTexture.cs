using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private Material[] materials;

    private Renderer cubeRender;

    private int randomMaterialIndex;

    private void Start()
    {
        cubeRender = cube.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeCubeTexture);
    }

    private void ChangeCubeTexture()
    {
        randomMaterialIndex = Random.Range(0, materials.Length);
        cubeRender.material = materials[randomMaterialIndex];
    }
}
