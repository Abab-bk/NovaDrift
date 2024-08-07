﻿音乐：doranarasi

## 升级曲线：
Assets/Curves/UpLevelCurve.tres
- X = 等级
- Y = 升级所需经验

## Credit:
Atelier Magicae @Itch
Creator of Assets: Riria/Ririsaurus

## Juice
- 敌人死亡：红色爆炸
- 子弹击中：子弹颜色的爆炸
- 怪物出生动画
- BOSS死亡动画，可以让时间减速，相机聚焦
- 玩家死亡动画

## 商店
商店消费需要货币：酸酸币（一种加密货币，存在于游戏设定）

商品：
- 新的升级模块
- 新 UI 皮肤
- 日卡
- 玩家动画（死亡、出场）
- 武器皮肤

## WaveSpawner
1. 生成一个 Spawner 实例，包含 cost -> 通过 Controller
2. Spawner 选择阵型
3. Spawner 随机移动


## Bosses
### The Doctor
行为：
医生会在屏幕边缘行走，并定期（3s - 6s）进行电击疗法攻击。
- 电击疗法1：
  召唤乌云附着在屏幕边缘，发射闪电，贯通全屏，需要进行上下/左右躲闪。
- 电击疗法2：
  召唤闪电脉络，先变暗，然后变亮造成伤害

被电击疗法击中后，玩家神经缭乱 +1
- 神经缭乱1：出现古神低语
- 神经缭乱2：在 1 的基础上，屏幕中不定时出现医生的脸
- 神经缭乱3：在 2 的基础上，医生隐身，但还可以打到

地图中会随机出现电池盒，打破电池盒后会令医生麻痹，并神经缭乱 -1

### The Knight
样子为国际象棋的马
行为：
骑士会在以下四种行为中循环：
- 跳跃到玩家附近
- 切换到 剑
- 切换到 诗
- 向玩家冲刺，造成伤害（模拟骑马）冲刺要举着剑
#### 剑
- 骑士举起剑，发起近身攻击。
- 用剑挥砍或刺向玩家，造成高额伤害。
- 可能施展连击，使玩家难以躲避或反击。
#### 诗
- 骑士举起一本书，开始吟诵咒语。
- 释放魔法攻击，包括：
  - 火球子弹
  - 冰冻射线
  - 召唤小弟
  - 强化攻击

### The Emoji
行为：
会始终尝试接近玩家，同时造成以下攻击：
- 旋转并射击 -> 切换到眩晕图片
- 发射一圈子弹 -> 切换到生气图片
- 向一个方向发射子弹 -> 切换到nerd图片

### The Hero
The Hero看起来是一颗不断变化颜色的“正义之心”
The Hero会在以下四种行为中循环：
- 追逐玩家
- 拯救
- 裁决
- 牺牲
- 升华
#### 拯救
- BOSS 移动到屏幕中央
- BOSS 停止移动，面向玩家
- 试图拯救战场上的所有物体
- 向所有物体发射绳索，拉近到The Hero
- 对所有拉近的物体造成伤害
#### 裁决
- BOSS 停止移动，面向玩家
- 召唤出一个巨大天平
- 向玩家投掷罪证（子弹）
#### 牺牲
- BOSS 停止移动
- 释放多个光环
- 每个光环会出现敌人
#### 升华
- The Hero射出激光，同时旋转

### The Timer
The Timer会在以下三种行为中循环：
- 激光
- 魔法
- 虚弱
#### 激光
The Timer 移动到地图中间，蓄力并射出 5 道激光，同时旋转
#### 魔法
追逐玩家，在一定距离蓄力并产生多个魔法阵，蓄力结束后魔法阵爆炸
#### 虚弱
在蓄力期间受到一定伤害后，进入虚弱
什么也不做，虚弱一段时间
休息后，随机进入魔法或激光