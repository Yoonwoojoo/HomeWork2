# HomeWork2
 Chapter 3-2 Unity 게임개발 숙련 개인과제 

<br>

![image](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/f1a5b8ac-40d6-43d0-80d0-3d1fc3dac6fe)

 
<br><br>

## :airplane: 프로젝트 소개

### 1. Unity3D의 캐릭터 이동과 물리 처리를 구현

### 2. 다양한 게임 오브젝트와의 상호작용을 객체지향적으로 구현

### 3. 게임 내의 여러 상태를 UI를 통해 사용자에게 표시


#### 모든 에셋들은 CC0 라이센스로 구성되어 있습니다.

<br><br>

## :thought_balloon: 구현 기능

### 필수 요구 사항

#### 1. **기본 이동 및 점프** `Input System`, `Rigidbody ForceMode`
    - 플레이어의 이동(WASD), 점프(Space) 등을 설정
    
![HomeWork2-1 1 1](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/5ab9cf29-c2ca-422e-94e8-78170ebabb5a)
![HomeWork2-1 1 2](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/dee10ef7-f916-465e-b718-19cf4f4d7c46)

#### 2. **체력바 UI**
    - UI 캔버스에 체력바를 추가하고 플레이어의 체력을 나타내도록 설정. 플레이어의 체력이 변할 때마다 UI 갱신.

![HomeWork2-1 2 2](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/83044ce1-ac61-4ef4-892c-462b69f0066c)
![HomeWork2-1 2](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/89b5b93c-d6f0-464b-a3ba-7e323051d54c)

#### 3. **동적 환경 조사** `Raycast` `UI`
    - Raycast를 통해 플레이어가 조사하는 오브젝트의 정보를 UI에 표시.
    - 예) 플레이어가 바라보는 오브젝트의 이름, 설명 등을 화면에 표시.

![HomeWork2-1 3](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/959d953f-be67-4ffd-9b0e-4f3bb32484c4)

#### 4. **점프대** `Rigidbody ForceMode`
    - 캐릭터가 밟을 때 위로 높이 튀어 오르는 점프대 구현
    - OnCollisionEnter 트리거를 사용해 캐릭터가 점프대에 닿았을 때 
      ForceMode.Impulse를 사용해 순간적인 힘 => "ForceMode.VelocityChange" 를 활용하여 포물선 형태로 날아감
![HomeWork2-1 4](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/1b73df9f-c08d-43c9-876f-fda69032abd3)
      
#### 5. **아이템 데이터** `ScriptableObject`
    - 다양한 아이템 데이터를 `ScriptableObject`로 정의. 
    - 각 아이템의 이름, 설명, 속성 등을 `ScriptableObject`로 관리

![image](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/8e0bf6bb-63fc-4d84-97bf-69aaae1b4279)
![image](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/aa4fe758-740c-4666-8290-d721dd3da39d)

#### 6. 아이템 사용
    - 아이템 장착 및 해제 
    - 아이템 사용 및 버리기
    - 무기 장착 후 공격 기능

![HomeWork2-1 6](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/61947997-7b54-4bfb-b4bc-eff274ea88d4)
    


<br>

### 선택 요구 사항

#### 1. **추가 UI**
    - 점프나 대쉬 등 특정 행동 시 소모되는 스태미나를 표시하는 바 구현
    - 이 외에도 다양한 정보를 표시하는 UI 추가 구현
    
![HomeWork2-2 1](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/ac523382-6f2d-4329-a6db-6836179728ba)

#### 2. **3인칭 시점**
    - 기존 강의의 1인칭 시점을 3인칭 시점으로 변경하는 연습
    - 3인칭 카메라 시점을 설정하고 플레이어를 따라다니도록 설정

![HomeWork2-2 2](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/0b22f4cc-6dce-42fc-8b75-8eb33de530f7)

#### 3. **움직이는 플랫폼 구현**
    - 시간에 따라 정해진 구역을 움직이는 발판 구현
    - 플레이어가 발판 위에서 이동할 때 자연스럽게 따라가도록 설정
    
![HomeWork2-2 3 1](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/7a1e5595-ae16-4ec4-ad98-0288beb6166d)
![HomeWork2-2 3 2](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/aa69bcc3-7f68-4dc4-858e-0985f4530373)

<br>

### 그 외 추가 사항

#### 1. **미니맵 만들기** 
#### 2. **캠프 파이어 설치** 
#### 3. **시간에 따른 날씨 변화** 

<br><br>

## :notebook: 기술 스택

![image](https://github.com/Yoonwoojoo/HomeWork2/assets/167274465/ffe62350-efec-4a8c-b5c4-7babcdba1eca)
