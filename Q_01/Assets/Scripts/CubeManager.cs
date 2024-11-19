using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        // SetPosition 위치는 그냥 큐브컨트롤러에서 관리하도록하기.
    }

    private void Start()
    {
        CreateCube();
        SetCubePosition();
    }
    private void Update()
    {
      //  SetCubePosition();
      //  계속 위치바꾸는대로 적용하라그런말은 없으니
      //  돌면안되니까 그냥 스타트에서 한번만
    }

    private void SetCubePosition()
    {
      //  _cubeSetPoint.x = x;
      //  _cubeSetPoint.y = y;
      //  _cubeSetPoint.z = z;
      // 필요없음 : CubeController 에서 값입력하고 가져오는식으로 변경 
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
