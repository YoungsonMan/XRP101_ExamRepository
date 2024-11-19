# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- - Q눌리고 AttackState로 변한뒤 데미지 줘서 몬스터 죽인후에 
다시 Idle상태로 돌아오지 않음.
    
    ![241119_Q4_AttackState01](https://github.com/user-attachments/assets/fd7af9a5-9a70-4c52-a425-3f3fad218a4f)
    
- 노트용
PlayerAttackValue = 15
NormalMonsterHP = 10
한방컷 맞음
    
    ![2024-11-19_01_NullReference](https://github.com/user-attachments/assets/cb0497be-816c-4c08-b426-b55a262a3fe5)
    
- 2초기다리고 공격하는데
공격이 계속되는가? 그래서 한방 컷으로 죽은다음에
또 때리려는데 공격할 대상이 없어져서 NullReference가 나온것이 아닐까 추측.
    
    ![241119_Q4_AttackState02](https://github.com/user-attachments/assets/df7f1111-aba4-4425-98f5-58a62a35520e)
    
- StateAttack에서 로그 찍으면서 확인하는데
친횟수가 늘으면 Exit()해서 Idle로 가게끔 하려했으나
Exit()되는 순간 다음 로그는 안찍히고StackOverflow발생
    
   ![2024-11-19_02_StackOverflow](https://github.com/user-attachments/assets/68ceed85-7cbb-449e-899c-7885af0c6153)
    
- 음 StatePattern 나는바보다…
