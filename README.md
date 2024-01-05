# Overcooked
---
### Enviroment
- Unity Hub
---
### 遊玩機制
- 新增玩家: Q
- 移動:WASD(1P) 上下左右(2P)
- 與物件互動:E (1P) right shift(2P)
- 切食材:F (1P) right ctrl (2P)
- 暫停選單:ESC
---
### 遊戲規則
- 玩家操縱角色進行烹調，隨著時間倒數下玩家感受到手忙腳亂，即使匆忙也要盡可能做出最多漢堡吧!
---
### 廚房物件(可以拿起來的)
#### KitchenObject 
- KitchenObject(定義大物件)
  - Ingredient(食材)
  - Plate(盤子)
  - Pan(平底鍋)
---
### 廚房母物件(可以被使用的)
#### KitchenObjectParent
- IKitchenObjectParent(定義廚房母物件介面)
  - Player(玩家)
  - BaseCounter(桌子)
    - ClearCounter(基本桌子)
    - Crate(食材箱)
    - CuttingBoard(切台)
    - Stove(爐子)
    - Dishrack(盤子槽)
---
### 可編程物件(類似structure(?)
#### ScriptableObject
- KitchenObjectSO
  - IngredientSO(食材資料)
- RecipeSO(食譜資料)
