# Hızlı Test Rehberi

Unity Editor'de test etmek için:

## 1. Unity Editor'de Projeyi Açın

1. Unity Hub'ı açın
2. **Add** → **cursorgame** klasörünü seçin
3. Unity sürümü seçin (2021.3 LTS veya üzeri önerilir)

## 2. Sahne Hazırlama (5 dakika)

### Ball (Top) Oluştur:
1. Hierarchy → Right Click → 2D Object → Sprite → Circle
2. İsim: `Ball`
3. Tag: `Ball` (yoksa oluştur)
4. Position: (0, 0, 0)
5. **Add Component:**
   - `Rigidbody2D` → Gravity Scale: 0
   - `Circle Collider2D` (Is Trigger kapalı)
   - `BallController` script (Assets/Scripts'ten sürükle)

### Ground (Zemin) Oluştur:
1. Hierarchy → Right Click → 2D Object → Sprite → Square
2. İsim: `Ground`
3. Tag: `Ground` (yoksa oluştur)
4. Position: (0, -5, 0)
5. Scale: (20, 1, 1)
6. **Add Component:** `Box Collider2D`

### Arrow Prefab Oluştur:
1. Hierarchy → Right Click → 2D Object → Sprite → Square
2. İsim: `Arrow`
3. Scale: (0.5, 0.2, 1)
4. **Add Component:**
   - `Rigidbody2D` → Body Type: Kinematic
   - `Circle Collider2D` → Is Trigger: ✓
   - `Arrow` script → Speed: 5
5. Project penceresine sürükle → Prefab olarak kaydet
6. Hierarchy'den sil

### ArrowSpawner Oluştur:
1. Hierarchy → Right Click → Create Empty → İsim: `ArrowSpawner`
2. **Add Component:** `ArrowSpawner`
3. Arrow Prefab'ı sürükle

### GameManager Oluştur:
1. Hierarchy → Right Click → Create Empty → İsim: `GameManager`
2. **Add Component:** `GameManager`

### Canvas ve UI:
1. Hierarchy → Right Click → UI → Canvas
2. Canvas içinde:
   - Panel → İsim: `StartPanel` → İçinde Button → `StartButton`
   - Panel → İsim: `GameOverPanel` → İçinde Text (`FinalScoreText`) ve Button (`RestartButton`)
   - Text → İsim: `ScoreText` → Anchor: Top-Left
   - Text → İsim: `LevelText` → Anchor: Top-Right
3. GameManager'a tüm UI referanslarını sürükle

## 3. Test!

1. **Play** butonuna bas
2. **Start Button**'a tıkla
3. **Space** tuşu ile top zıplasın
4. Oklar gelmeye başlasın!

## Hızlı Kontrol Listesi:

- [ ] Ball tag'i var mı?
- [ ] Ground tag'i var mı?
- [ ] Arrow Prefab oluşturuldu mu?
- [ ] ArrowSpawner'da Prefab referansı var mı?
- [ ] GameManager'da UI referansları atandı mı?
- [ ] Canvas var mı?

## Sorun Giderme:

**Oklar spawn olmuyor:**
- GameManager'da StartGame() çağrılıyor mu kontrol et
- ArrowSpawner'da Prefab referansı var mı?

**Top zıplamıyor:**
- BallController script ekli mi?
- Rigidbody2D var mı ve Gravity Scale 0 mı?

**Çarpışma algılanmıyor:**
- Arrow'un Collider Is Trigger açık mı?
- Ball tag'i doğru mu?

