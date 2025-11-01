# Unity Oyunu Kurulum Rehberi

## Adım 1: Unity Projesi Oluşturma

1. Unity Hub'dan yeni bir **2D Project** oluşturun
2. Proje adını belirleyin ve oluşturun

## Adım 2: Scene Hazırlama

### 2.1 Kamera Ayarları
- Main Camera'yı seçin
- Projection: Orthographic
- Size: 5 (ihtiyaca göre ayarlayın)

### 2.2 Top (Ball) Oluşturma

1. **Hierarchy** → **Right Click** → **2D Object** → **Circle** (veya **Sprite** → **Square**)
2. İsmini `Ball` yapın
3. **Tag** ekleyin: `Ball` (yoksa oluşturun)
4. **Components ekleyin:**
   - `Rigidbody2D`
     - Gravity Scale: 0 (manuel kontrol)
     - Freeze Rotation Z: ✓
   - `Circle Collider2D` (veya Box Collider2D)
     - Is Trigger: ✗ (kapalı)
   - `BallController` script (BallController.cs ekleyin)

### 2.3 Zemin (Ground) Oluşturma

1. **Hierarchy** → **Right Click** → **2D Object** → **Sprite** → **Square**
2. İsmini `Ground` yapın
3. **Tag** ekleyin: `Ground` (yoksa oluşturun)
4. Transform:
   - Position: (0, -5, 0)
   - Scale: (20, 1, 1)
5. **Box Collider2D** ekleyin

### 2.4 Ok Prefab Oluşturma

1. **Hierarchy** → **Right Click** → **2D Object** → **Sprite** → **Square** (veya arrow sprite kullanın)
2. İsmini `Arrow` yapın
3. **Components ekleyin:**
   - `Rigidbody2D`
     - Body Type: Kinematic
   - `Circle Collider2D` (veya Box Collider2D)
     - Is Trigger: ✓ (açık)
   - `Arrow` script (Arrow.cs ekleyin)
4. **Inspector**'da Speed değerini 5 yapın
5. Arrow'u **Project** penceresine sürükleyerek **Prefab** yapın
6. Hierarchy'den Arrow'u silin (prefab olarak yeterli)

### 2.5 ArrowSpawner Oluşturma

1. **Hierarchy** → **Right Click** → **Create Empty**
2. İsmini `ArrowSpawner` yapın
3. `ArrowSpawner` script ekleyin
4. **Inspector'da:**
   - Arrow Prefab: Oluşturduğunuz Arrow prefab'ını sürükleyin
   - Spawn Interval: 2
   - Min Spawn Interval: 0.5
   - Spawn X: 10
   - Spawn Y Min: -4
   - Spawn Y Max: 4

### 2.6 GameManager Oluşturma

1. **Hierarchy** → **Right Click** → **Create Empty**
2. İsmini `GameManager` yapın
3. `GameManager` script ekleyin

### 2.7 UI Oluşturma

1. **Hierarchy** → **Right Click** → **UI** → **Canvas**
2. Canvas ayarları:
   - Canvas Scaler → UI Scale Mode: Scale With Screen Size
   - Reference Resolution: 1080x1920 (mobil için)

#### Start Panel Oluşturma:
1. **Canvas** → **Right Click** → **UI** → **Panel** → İsmi `StartPanel`
2. **StartPanel** → **Right Click** → **UI** → **Button** → İsmi `StartButton`
3. **StartPanel** → **Right Click** → **UI** → **Text** → İsmi `TitleText` (opsiyonel)
   - Text: "Tap to Start" veya oyun adı

#### Game Over Panel Oluşturma:
1. **Canvas** → **Right Click** → **UI** → **Panel** → İsmi `GameOverPanel`
2. **GameOverPanel** → **Right Click** → **UI** → **Text** → İsmi `FinalScoreText`
3. **GameOverPanel** → **Right Click** → **UI** → **Button** → İsmi `RestartButton`
   - Text: "Restart"

#### In-Game UI:
1. **Canvas** → **Right Click** → **UI** → **Text** → İsmi `ScoreText`
   - Anchor: Top-Left
   - Position: (50, -50, 0)
   - Text: "Score: 0"
2. **Canvas** → **Right Click** → **UI** → **Text** → İsmi `LevelText`
   - Anchor: Top-Right
   - Position: (-50, -50, 0)
   - Text: "Level: 1"

#### GameManager UI Bağlantıları:
1. **GameManager** seçin
2. **Inspector'da GameManager script** altında:
   - Start Panel: `StartPanel` sürükleyin
   - Game Over Panel: `GameOverPanel` sürükleyin
   - Score Text: `ScoreText` sürükleyin
   - Level Text: `LevelText` sürükleyin
   - Final Score Text: `FinalScoreText` sürükleyin
   - Start Button: `StartButton` sürükleyin
   - Restart Button: `RestartButton` sürükleyin

## Adım 3: Görsel İyileştirmeler (Opsiyonel)

- Top için renkli bir sprite veya basit bir circle kullanabilirsiniz
- Ok için arrow şeklinde bir sprite ekleyebilirsiniz (Project'e sprite import edin)
- Arka plan için bir Background sprite ekleyebilirsiniz

## Adım 4: Test

1. **Play** butonuna basın
2. Space tuşu ile test edin (mobilde dokunma çalışır)
3. Oyun akışını kontrol edin

## Sorun Giderme

- **Top zıplamıyor**: BallController script'inin ekli olduğundan ve Rigidbody2D'nin Gravity Scale'inin 0 olduğundan emin olun
- **Oklar spawn olmuyor**: ArrowSpawner'da Arrow Prefab referansının atandığından emin olun
- **Çarpışma algılanmıyor**: Arrow'un Collider2D'nin Is Trigger'ının açık olduğundan emin olun
- **UI görünmüyor**: Canvas'ın Screen Space - Overlay olduğundan emin olun

## Mobil Build

1. **File** → **Build Settings**
2. Platform olarak **Android** veya **iOS** seçin
3. **Switch Platform**
4. Player Settings'den ayarları yapın
5. **Build and Run**
