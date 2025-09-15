# 🗡️ Sword

เกม 2D แนวแอคชั่นด้วย Unity  เพิ่มระบบ UI
-แสดงเลือดของตัวละคร
-ลดเลือดของตัวละครเมื่อได้รับบาดเจ็บ
-และแสดงข้อความ Game Over เมื่อตาย (จากเลป FlappyBird)

---

## 🔥 ตัวอย่างเกม

![Screenshot](https://github.com/Jessadaruk/UPdate-SwordMan/blob/main/TabHeart.png)


## 🧩 ระบบในเกม

### 🎮 การควบคุม
- ปุ่ม A / D → เดินซ้าย / ขวา
- ปุ่ม Space → กระโดด

### ❤️ ระบบพลังชีวิต (Health System)
- ตัวละครเริ่มต้นด้วยพลังชีวิตเต็ม 100
- เมื่อโดนหนาม (Spikes) จะเสียพลังชีวิต
- เมื่อพลังชีวิตเหลือ 0 ตัวละครจะตาย

### 🩸 การโดนโจมตี (Damage System)
- เมื่อโดนหนาม:
  - ตัวละครกระเด้งเล็กน้อย
  - Sprite กระพริบเป็นสีขาว (ใช้ Sprite สีขาวสลับกับปกติ)
  - มีช่วงเวลาป้องกันความเสียหาย (invincibility) สั้น ๆ เพื่อป้องกันการโดนซ้ำทันที

### 💀 ระบบความตาย (Death Animation)
- เมื่อพลังชีวิตหมด:
  - ตัวละครหยุดเคลื่อนไหว
  - ปิด Collider และ Input Control
  - เล่นอนิเมชันตาย (ต้องตั้ง Trigger ชื่อ Die ใน Animator)
 
  - ![Screenshot](https://github.com/Jessadaruk/SwordMan/blob/main/Death.png)


