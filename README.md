Unity 개인 프로젝트



Unity 기반의 개인 프로젝트로, 유저가 자유롭게 이동하고 점프할 수 있는 3D 컨트롤을 중심으로 체력 시스템, 점프대, 아이템 수집 및 인벤토리 시스템 등을 구현한 샘플 게임입니다.

# 주요 기능

#### 1. 캐릭터 조작 기본

- Unity Input System을 활용해 OnMove, OnInteract, OnJump 같은 이벤트 기반 입력 처리 구현

- SendMessage 대신 C# 이벤트 및 델리게이트, 바인딩 방식을 활용하여 안정성과 유지보수성 강화

- 이동은 Rigidbody 속도 기반, 카메라 회전은 플레이어 회전과 카메라 축 분리로 자연스러운 시점 제공

- 점프는 OnCollisionEnter와 ForceMode.Impulse를 활용해 구현

- PlayerManager 싱글톤을 통해 전역 플레이어 관리 및 씬 전환 간에도 유지

-----
#### 2. 체력 시스템 (UI)

- 체력바 UI를 구현하고 Add() / Subtract() 메서드로 체력 회복 및 감소 로직 적용

- 체력 회복과 데미지 처리까지 UI 동기화 기능 포함
-----

#### 3. 점프대 (JumpPad)

- 점프대에 닿은 Rigidbody 객체에 순간적으로 jumpForce 적용 (ForceMode.Impulse)

- Rigidbody가 없을 경우를 대비한 null-conditional 처리로 안정성 확보
----
#### 4. 아이템 상호작용

- 매 주기마다 Raycast를 중앙 스크린에서 쏘아 상호작용 가능한 객체 탐지 (checkRate, maxCheckDistance, layerMask 활용)

- IInteractable 인터페이스 기반으로 상호작용 프롬프트 UI 표시 및 E키 입력 시 OnInteract() 호출

- 인터랙션 후 프롬프트 숨김 및 대상 초기화
----
#### 5. 인벤토리 시스템

- Tab 키로 인벤토리 UI 열기/닫기 구현, 마우스 포커스 처리

- UIInventory 클래스가 아이템 슬롯, 이름・설명・능력치 표시, 장착/사용/버리기 버튼 로직을 담당

- 스택 가능한 아이템은 수량 증가, 빈 슬롯은 신규 추가, 인벤토리가 가득하면 버리기

- ItemData를 ScriptableObject로 정의: 이름, 설명, 타입(Equipable / Consumable / Resource), 아이콘, 드롭 프리팹, 스택 가능 여부, 최대 수량, 효과 타입 및 값 등 지정 가능

- 아이템 사용 시 효과 적용 후 수량 감소, 수량이 0이면 슬롯 초기화
---
#### 7. 기능 구현 요약 
- 기본 이동 및 점프 O
- 체력바 UI O
- 동적 환경 조사 O
- 점프대 O
- 아이템 데이터 O
- 아이템 사용 O
- 움직이는 플랫폼 구현 O
- 다양한 아이템 구현 O


---
#### 6. 트러블슈팅 경험
https://velog.io/@heeno7700/%EC%9C%BC%EC%8C%B0%EC%9C%BC%EC%8C%B0%EA%B0%9C%EC%9D%B8-3D%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8

https://velog.io/@heeno7700/%EC%9C%BC%EC%8C%B0%EC%9C%BC%EC%8C%B0%EA%B0%9C%EC%9D%B8-%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-%EC%A3%BC%EB%A7%90


#### UI 개선 및 UX 향상

씬 전환, 레벨 디자인, 적 캐릭터, 스테이지 구조 추가

