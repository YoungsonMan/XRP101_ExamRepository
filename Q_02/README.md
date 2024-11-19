# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다
- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.
- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안
- 실행시키니 StackOverflow가 나온다
`StackOverflowException`: The requested operation caused a stack overflow.
PlayerStatus.set_MoveSpeed (System.Single value) (at Assets/Scripts/PlayerStatus.cs:10)
    ![2024-11-19_01_StackOverflow](https://github.com/user-attachments/assets/0f5d1d62-ca82-4f37-a37c-e8448048b35a)
- 음 get set 어떻게 하는지 잘 모르겠으니까 그냥
Awake하면 0으로 초기화. 어쩃든 초기화니까 초기화
Start에서 Init()으로 속도 입력.
- 두번째문제같은경우는
x,z 값을받아 대각선/삼각형이 형성되면 빗변이 더 크기떄문에 큰속도?(값?)를 받아서 
.normalize를 이용하면 될거 같다.
음MoveSpeed.normalized 하면 될줄알았는데 빨간줄…
아~! direction뒤에 붙이니까 해결 
다시보니 방향값받아서 처리하는 변수가 `direction` 이니까… 맞네맞어
Speed는 그냥 속력만 가져오는거고.. 그렇다.
![2024-11-19_02_normalized](https://github.com/user-attachments/assets/8f0377dd-1ea2-431c-bf0a-807ff5ed21e6)
![241119_NOnormalized](https://github.com/user-attachments/assets/27a0b168-9ee5-4dd4-8cc9-c1adc8d2fef1)
normalized 없이 대각
![241119_normalized](https://github.com/user-attachments/assets/c60213fa-349a-42d1-80df-7f4a94da9fd8)
.normalized / 대각이동의 정상화

- 맥Os 유니티에서 에디터 강제종료되는것은
맥이기 떄문에… 저는 모르겠읍니다… 구글 검색할 할 수 없다면 알 수 없는 부분…
