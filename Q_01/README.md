# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
- - `NullReferenceException`: Object reference not set to an instance of an object
CubeManager.SetCubePosition (System.Single x, System.Single y, System.Single z) (at Assets/Scripts/CubeManager.cs:27)
CubeManager.Awake () (at Assets/Scripts/CubeManager.cs:14)
- 참조된걸 못찾을 때? 잘못 됐을때 나오는 널레퍼런스가 나온다 
Object reference not set to an instance of an object CubManager.SetCubePosition…
CubManager.SetCubePosition… 오브젝트의 인스턴스 참조가 안되있는거 같다.
- SetCubePosition()은 컨트롤러에서 담당하고,  [SerializeField] 로 인스펙터에서 입력해두고 
바꿀수 있도록 변경
생성은 되는데 위치가 안바뀌었다.
SetCubePosition() 함수가 작동안되고있다.
    
    ![imageQ01_1](https://github.com/user-attachments/assets/2e94b1b2-4fcd-4b1a-b599-3122ce7df853)
    
- 이제 매니저에서 쓸모없는 _cubeSetPoint 없애고 리팩토링
    
    ![imageQ01_2](https://github.com/user-attachments/assets/d7f0daa5-e035-4386-986b-e36978e577e1)
    
- 잘작동
    
   ![imageQ01_3](https://github.com/user-attachments/assets/eadc30cc-0079-463b-8f07-223f6cfa3254)
