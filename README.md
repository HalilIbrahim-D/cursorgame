# Flappy Bird Tarzı Top ve Ok Oyunu

Unity ve C# ile geliştirilmiş mobil oyun. Flappy Bird benzeri bir mekanik ile çalışır.

## Oyun Mekanikleri

- **Top Kontrolü**: Dokunma ile top zıplar
- **Ok Saldırıları**: Ekranın sağından topa doğru eğik atışla gelen oklar
- **Level Sistemi**: Level arttıkça ok sayısı ve hızı artar
- **Amaç**: Topu oklardan korumak

## Kurulum

1. Unity Editor'da yeni bir 2D proje oluşturun
2. Bu scriptleri `Assets/Scripts/` klasörüne ekleyin
3. Scene'de aşağıdaki GameObject'leri oluşturun:

### Gerekli GameObject'ler:

1. **Ball** (Top)
   - Tag: "Ball"
   - Rigidbody2D component
   - Circle Collider2D (Trigger değil)
   - Sprite Renderer (top görseli)

2. **ArrowSpawner** (Boş GameObject)
   - ArrowSpawner.cs script ekleyin
   - Arrow Prefab referansını atayın

3. **Arrow Prefab**
   - Arrow.cs script ekleyin
   - Rigidbody2D (Kinematic)
   - Circle Collider2D (Is Trigger = true)
   - Sprite Renderer (ok görseli)

4. **GameManager** (Boş GameObject)
   - GameManager.cs script ekleyin
   - UI elementlerini referans olarak atayın

5. **Ground** (Zemin)
   - Tag: "Ground"
   - Box Collider2D
   - Sprite Renderer

6. **UI Elements**
   - Canvas oluşturun
   - Start Panel (Start Button)
   - Game Over Panel (Restart Button)
   - Score Text
   - Level Text
   - Final Score Text

## Script Ayarları

### BallController
- Jump Force: 5
- Gravity: 9.81
- Max Velocity: 10

### ArrowSpawner
- Arrow Prefab: Oluşturduğunuz prefab
- Spawn Interval: 2
- Min Spawn Interval: 0.5
- Spawn X: 10 (ekranın sağı)
- Spawn Y Min/Max: -4 / 4

### GameManager
- Score Increase Interval: 1
- Points Per Second: 10
- Score Per Level: 100
- Speed Increase Per Level: 0.5
- Max Arrows Per Spawn: 3

## Kontroller

- **Mobil**: Ekrana dokunma
- **PC Test**: Space tuşu

## Özellikler

- Dokunma ile zıplama
- Dinamik ok takibi (top her zaman hedef)
- Level bazlı zorluk artışı
- Skor sistemi
- UI yönetimi
