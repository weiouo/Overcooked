# Overcooked
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
