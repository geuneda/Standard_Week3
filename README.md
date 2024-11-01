# Standard_Week3
 
Q1
문/입문 주차와 비교해서 입력 받는 방식의 차이와 공통점을 비교해보세요.
답/
차이 : 입문주차에서는 델리게이트와 SendMessages를 활용하여 코드를 쉽게 분리하여 사용하였고, 숙련주차에서는 Invoke Unity Events를 활용해서 값을 입력받으면 입력한 방향을 가져오고 FixedUpdate에서 Move를 호출하는 마치 델리게이트와 유사하지만 다른 방식으로 움직임을 구현했다고 생각합니다.
공통점 : InputSystem에서 기본적으로 제공하는 입력값을 바탕으로 구현을 했음. 움직임에 필요한 요소들을 잘 분리하여 수정과 확장이 용이함

문/ CharacterManager와 Player의 역할에 대해 고민해보세요.
답/
Player는 접근을 허용하는 컴포넌트를 Player에 구현해두면 CharacterManager에서 Player을 안전하게 가져와 담아둔 뒤
CharacterManager를 Instance로 만들어 다른 필요로 하는 클래스에서 접근을 쉽게 하게 도와줌

문/핵심 로직을 분석해보세요 (Move, CameraLook, IsGrounded)
답/ 
MOVE: 키를 입력하면 Event에서 OnMove를 호출하고 OnMove에서는 해당 키값이 누르고 있는 키가 맞는 지 확인 후
curMovementInput변수 에 누른 키를 바탕으로 방향을 담아주고 FixedUpdate에서 Move를 호출하여 안정적으로 움직임
CameraLook: 마우스의 Y축  "이동" 값을 이용하여 카메라의 상하 회전을 조정하고, 마우스의 Y축 "회전"값을 이용하여 카메라(컨테이너)의 좌우 회전을 조정했습니다.
isGrounded: 불값을 반환하는 메서드에 기즈모의 약간 위를 기준으로 앞뒤좌우로 레이를 아래방향으로 쏘고 ground 레이어가 검출되면 true를 반환합니다.

문/Move와 CameraLook 함수를 각각 FixedUpdate, LateUpdate에서 호출하는 이유에 대해 생각해보세요.
답/
FixedUpdate는 일정한 가격으로 호출되기때문에 물리현상과 관련된(안정적인 체감) 함수를 호출할때 유용하기 때문입니다.
LateUpdate는 Update중 가장 마지막에 호출되는 Update인데, 움직임과 관련된 현상이 일어난 후 마지막에 카메라가 움직이는것이 자연스럽게 체감되기때문입니다.

확장문제 / 강의 내용을 바탕으로 새로운 기능을 추가 구현해봅시다.
답/ 유니티참고

Q2
문/별도의 UI 스크립트를 만드는 이유에 대해 객체지향적 관점에서 생각해보세요.
답/
코드의 관리및 유지보수를 위해서 라고 생각합니다.
기능이 추가되거나, 수정될 때 해당 코드가 다른 코드에 의존하거나 결합도가 높으면 다른코드까지 함께 수정해야하는
나중의 상황을 생각하여, 별도의 스크립트로 관리해야한다고 생각합니다.

문/인터페이스의 특징에 대해 정리해보고 구현된 로직을 분석해보세요.
답/
인터페이스를 구현해놓으면 해당 인터페이스를 상속받는 클래스는 인터페이스에 선언된 메서드를 구현하게 강제해준다.
이를 이용하여, 이번 강의에서는 ItemObject 클래스에 IInteractable 인터페이스를 상속시켰고 이를 ItemObject에서 구현하고,
ItemObject를 상호작용가능한 오브젝트들에 컴포넌트로 추가하여 사용하였습니다.

문/핵심 로직을 분석해보세요. (UI 스크립트 구조, CampFire, DamageIndicator)
답/
플레이어의 상태에 따라 UI를 조정하는 Condition
플레이어와 UI 클래스 사이를 연결하기 위한 UICondition
피격 상태에 따라 UI를 조정하는 DamageIndicator
아이템 슬롯을 관리하는 ItemSlot
이벤토리 관리를 위한 UIInventory
이렇게 UI들을 이름과 목적이 뚜렷하게 잘 구분하여 구현되어있습니다.
CampFire의 구현방식은 IDamagalbe형식의 리스트를 만들어놓고, 플레이어가 트리거에 들어오면 데미지를 주는 리스트를 추가하고, 나갔을때 지우는 방식으로 만들어놓은 뒤
InvokeRepeating을 이용하여, 딜레이 없이 계속해서 리스트에 담긴 데미지를 주는 메서드를 호출합니다.
DamageIndicator는 플레이어가 데미지를 입었을 때 발동하는 이벤트(onTakeDamage)를 구독하여 데미지를 입을 때 마다 데미지를 입는 효과를 발동시켰으며, 
해당 효과는 캔버스의 이미지를 이용하여 잠깐 화면색을 바꾸는 방법으로 효과를 만들었습니다.



Q3
문/Interaction 기능의 구조와 핵심 로직을 분석해보세요.
답/
레이캐스트를 0.05초마다 발동하여 카메라 시야의 중앙으로 레이를 쏘고, 인터렉션이 가능한 오브젝트를 레이어마스크를 통해 확인하고 발견되면 IInteractable 인터페이스가 포함된 스크립트와 해당 오브젝트를 가져오고 아이템을 획득하거나 아이템 설명을 출력합니다.

문/Inventory 기능의 구조와 핵심 로직을 분석해보세요.
답/
아이템 획득시 스크립터블 오브젝트로 만들어둔 ItemData 타입으로 변수에 담아둔 뒤 비어있는 아이템 슬롯을 반환해주는 함수를 이용하여 해당 슬롯에 넣어주고 획득한 아이템 데이터를 비워준다.
