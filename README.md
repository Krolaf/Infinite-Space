# 🚀 Prototype Infinite Space - Exploration Spatiale 2D

## 📋 Description
Prototype Unity 2D top-down pour un jeu d'exploration spatiale. Le joueur contrôle un vaisseau qui peut se déplacer librement dans un environnement spatial avec une base station fixe.

## 🎮 Contrôles
- **WASD** ou **Flèches directionnelles** : Déplacer le vaisseau
- **Escape** : Mettre en pause/reprendre le jeu
- **Gamepad** : Stick gauche pour le mouvement

## 🏗️ Structure du Projet

### Scènes
- `Assets/Scenes/Exploration.unity` — Scène principale du prototype

### Scripts (`Assets/Scripts/`)
- `ShipController.cs` — Contrôle du mouvement du vaisseau
- `BaseStation.cs` — Gestion de la base station
- `CameraFollow.cs` — Suivi de caméra fluide
- `PlayerInputHandler.cs` — Gestion des inputs avec le nouveau Input System
- `GameManager.cs` — Gestion globale du jeu

### Art (`Assets/Art/`)
- **Sprites temporaires à créer dans Unity** :
  - Utilise l'outil **Sprite Editor** ou **Sprites > Shapes** pour créer un triangle (vaisseau) et un cercle (base).
  - Assigne-les dans les SpriteRenderer des GameObjects correspondants.

## 🎯 Fonctionnalités Implémentées

### ✅ Complété
- [x] Mouvement du vaisseau avec WASD/flèches/gamepad
- [x] Rotation automatique du vaisseau dans la direction du mouvement
- [x] Caméra orthographique qui suit le vaisseau
- [x] Base station fixe au centre (0,0)
- [x] Nouveau Input System configuré
- [x] Physique 2D avec Rigidbody2D (gravité désactivée)
- [x] Système de pause avec Escape
- [x] Graphismes temporaires via Unity Shapes

### 🔄 En cours / À améliorer
- [ ] Collisions entre vaisseau et base
- [ ] Interface utilisateur (UI)
- [ ] Système de ressources/énergie
- [ ] Plus d'objets spatiaux
- [ ] Effets visuels et sonores

## 🚀 Comment Tester
1. Ouvrir Unity et charger le projet
2. Ouvrir la scène `Assets/Scenes/Exploration.unity`
3. Vérifier que les scripts sont bien attachés sur les GameObjects
4. Créer et assigner les sprites temporaires (triangle/cercle) dans les SpriteRenderer
5. Appuyer sur Play
6. Utiliser WASD pour déplacer le vaisseau
7. Observer la rotation automatique et le suivi de caméra

## 🎨 Graphismes Temporaires
- **Vaisseau** : Triangle bleu clair pointant vers le haut (à créer dans Unity)
- **Base** : Cercle gris de 2x2 unités (à créer dans Unity)
- **Fond** : Noir pour simuler l'espace
- **Caméra** : Orthographique, suit le vaisseau en douceur

## 🔧 Configuration Technique
- **Unity Version** : 2022.3 LTS ou plus récent
- **Input System** : Nouveau Input System Package
- **Rendering** : Universal Render Pipeline (URP)
- **Physics** : 2D Physics avec Rigidbody2D
- **Camera** : Orthographique, mode 2D

## 📝 Notes de Développement
### Input System
Le projet utilise le nouveau Input System d'Unity avec :
- Action Map "Player"
- Action "Move" (Vector2)
- Bindings pour clavier (WASD, flèches) et gamepad

### Architecture
- **ShipController** : Gère le mouvement et la rotation
- **PlayerInputHandler** : Interface avec le nouveau Input System
- **CameraFollow** : Suivi fluide avec Lerp
- **BaseStation** : Prêt pour futures interactions
- **GameManager** : Singleton pour la gestion globale

### Optimisations Futures
- Pooling d'objets pour les particules
- Culling pour les objets hors écran
- Compression des textures
- Optimisation des scripts avec Object Pooling

## 🐛 Dépannage
### Problèmes Courants
1. **Vaisseau ne bouge pas** : Vérifier que PlayerInput est configuré et que le script ShipController est bien attaché
2. **Caméra ne suit pas** : Vérifier le script CameraFollow et l'assignation de la cible
3. **Erreurs de compilation** : Vérifier que tous les scripts sont dans Assets/Scripts/

### Debug
- Utiliser la Console Unity pour voir les logs
- Vérifier les références dans l'Inspector
- Tester les inputs dans l'Input Debugger

## 📈 Prochaines Étapes
1. **UI/UX** : Ajouter une interface utilisateur
2. **Gameplay** : Système de ressources et d'énergie
3. **Contenu** : Plus d'objets spatiaux et d'exploration
4. **Audio** : Effets sonores et musique
5. **VFX** : Particules et effets visuels
6. **Optimisation** : Performance et mémoire

---
**Développé pour le projet Infinite Space** 🚀 