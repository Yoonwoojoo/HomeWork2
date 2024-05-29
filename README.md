# HomeWork2
 Chapter 3-2 Unity 게임개발 숙련 개인과제 

<br>

![image](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/f1a5b8ac-40d6-43d0-80d0-3d1fc3dac6fe)

 
<br><br>

## :airplane: 프로젝트 소개

### 1. Unity3D의 캐릭터 이동과 물리 처리를 구현해봅니다.

### 2. 다양한 게임 오브젝트와의 상호작용을 객체지향적으로 구현해봅니다.

### 3. 게임 내의 여러 상태를 UI를 통해 사용자에게 표시합니다.


<br><br>

## :thought_balloon: 구현 기능

### 필수 요구 사항

#### 1. **기본 이동 및 점프** `Input System`, `Rigidbody ForceMode` (난이도 : ★★☆☆☆)
    - 플레이어의 이동(WASD), 점프(Space) 등을 설정

#### 2. **체력바 UI** `UI` (난이도 : ★★☆☆☆)
    - UI 캔버스에 체력바를 추가하고 플레이어의 체력을 나타내도록 설정. 플레이어의 체력이 변할 때마다 UI 갱신.

#### 3. **동적 환경 조사** `Raycast` `UI` (난이도: ★★★☆☆)
    - Raycast를 통해 플레이어가 조사하는 오브젝트의 정보를 UI에 표시.
    - 예) 플레이어가 바라보는 오브젝트의 이름, 설명 등을 화면에 표시.

#### 4. **점프대** `Rigidbody ForceMode` (난이도 : ★★★☆☆)
    - 캐릭터가 밟을 때 위로 높이 튀어 오르는 점프대 구현
    - OnCollisionEnter 트리거를 사용해 캐릭터가 점프대에 닿았을 때 
      ForceMode.Impulse를 사용해 순간적인 힘을 가함 -> "ForceMode.VelocityChange" 를 활용하여 포물선 형태로 날아감
      
#### 5. **아이템 데이터** `ScriptableObject` (난이도 : ★★★☆☆)
    - 다양한 아이템 데이터를 `ScriptableObject`로 정의. 각 아이템의 이름, 설명, 속성 등을 `ScriptableObject`로 관리
    


### 선택 요구 사항

#### 1. **추가 UI** (난이도 : ★★☆☆☆)
    - 점프나 대쉬 등 특정 행동 시 소모되는 스태미나를 표시하는 바 구현
    - 이 외에도 다양한 정보를 표시하는 UI 추가 구현
    
#### 2. **3인칭 시점** (난이도 : ★★★☆☆)
    - 기존 강의의 1인칭 시점을 3인칭 시점으로 변경하는 연습
    - 3인칭 카메라 시점을 설정하고 플레이어를 따라다니도록 설정
    
#### 3. **움직이는 플랫폼 구현** (난이도 : ★★★☆☆)
    - 시간에 따라 정해진 구역을 움직이는 발판 구현
    - 플레이어가 발판 위에서 이동할 때 자연스럽게 따라가도록 설정



### 자발적 추가 사항

#### 1. **미니맵 만들기** 
#### 2. **캠프 파이어 설치** 
#### 3. **시간에 따른 날씨 변화** 
#### 4. **아이템 장착 및 해제** 
#### 5. **아이템 사용 및 버리기** 


<br><br>

## :star2: 주요 기능

### 1. 플레이어
<table>
  <tr>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/167274465/5254bba7-b6a7-461e-b74e-abd10269cdb6" alt="WASD"></a></td>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/167274465/6c58f3e4-dd7b-4a5c-8893-5bb039b84812" alt="Aim"></a></td>
  </tr>
</table>

   - 키보드 A/W/S/D 를 이용하여 캐릭터가 움직입니다.
   - 캐릭터는 상하좌우 및 대각선으로 움직일 수 있습니다.
   - 캐릭터는 마우스 위치에 따라 회전합니다.

<br>

***
     
        
### 3. 아이템 습득
<table>
  <tr>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/6b213882-af39-4d1d-98ac-715b3fbb41d4" alt="ItemAppearDisappear"></a></td>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/4e86a9f2-b220-4d42-bef3-73fb866069d1" alt="SpeedUp"></a></td>
  </tr>
</table>

   - 스테이지가 시작되면, 10초 마다 맵의 랜덤한 위치에 아이템이 생성됩니다.
   - 아이템 종류는 총 4가지로, 각각 체력회복, 공격력 증가, 멀티샷, 이속 증가 효과를 가지고 있습니다.
   - 아이템은 생성 후 5초 뒤에 자동으로 파괴되어, 플레이어가 획득하지 못하더라도 게임 씬에 하나 이상 존재하지 않습니다.
   - 애니메이션 효과를 추가하여, 아이템은 생성 후 5초 간 제자리를 빙글빙글 돕니다. 

<br>

***
    
### 4. 아이템 장착 및 해제
<table>
  <tr>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/4958fc81-77d1-4029-a380-be86583245fd" alt="CannotGetOut"></a></td>
  </tr>
</table>

   - 게임을 조금 더 재미있게 즐기기 위해 게임 주제와 어울리는 맵 배경, 캐릭터, 총알 이미지를 추가 했습니다.
   - 플레이어와 적이 게임화면을 벗어나는 것을 막기 위해, 화면 주위에 Tilemap Collider2D를 추가한 벽을 생성하였습니다.

<br>

***
    
### 5. 플레이어 공격
<table>
  <tr>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/a189267f-d6b9-4ba4-aec6-021d03c3ea0e" alt="PlayerNormalAttack"></a></td>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/e6058f79-b86c-4c40-8365-ca04fc4b764f" alt="PurpleItemMultishot"></a></td>
  </tr>
</table>

   - 플레이어의 입력에 따라 발사체를 생성하고 조준하는 로직을 구현합니다.
   - Aim 메서드로 조준 방향을 업데이트 하고, Shoot 메서드로 공격을 실행 하게 만들고, AttackSO는 발사체의 속성을 정의합니다.
   - 아이템 정보에 접근하여, 아이템 획득 시 다양한 형태의 공격이 가능합니다.

        
### 6. 미니맵

<div align="center">

<table>
  <tr>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/13936440-77bd-4b27-8659-1ea416e4b550" alt="GotItemImageClear"></a></td>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/9efdf665-af92-4bb7-8bcf-dd8facf279c0" alt="RetryAfterClear"></a></td>
  </tr>
</table>

<table>
  <tr>
    <td><a href=""><img src="https://github.com/ZhamesK/2024-Air-Force/assets/108499207/7a405ce9-a850-4da9-8282-6b7f7e769cc7" alt="MainAfterFail"></a></td>
  </tr>
</table>

</div>

   - Start Scene에 [Start], [Off] 버튼 생성
   - 게임 화면 오른쪽 상단에 플레이어 HP Bar 추가
   - 중앙 상단에 아이템 획득 여부를 표시해주는 이미지 추가(획득 시 이미지가 더 선명해짐)
   - 왼쪽 상단에 해당 스테이지 정보 표시
   - 게임 클리어 / 실패 시 결과 화면 출력, <br> 결과 화면에 [다시하기] [메인화면] 버튼 UI 생성, 버튼 클릭 시 씬 전환
   - 플레이 시 왼쪽 하단에 [?] 버튼 생성, <br> 조작법, 스테이지 정보, 아이템 정보를 볼 수 있어서, 누구나 쉽게 플레이 가능


<br><br>


## :joystick: 기술 스택

![TechStack](https://github.com/ZhamesK/2024-Air-Force/assets/167274465/52d9c045-c684-4282-bb6d-8fc178b4915f)


<br><br>
