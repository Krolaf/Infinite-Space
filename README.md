# 🚀 Prototype Infinite Space - Exploration Spatiale 2D

## 📋 Description
Prototype Unity 2D top-down pour un jeu d'exploration spatiale. Le joueur contrôle un vaisseau qui peut se déplacer librement dans un environnement spatial généré dynamiquement autour d'une base station fixe.

## 🎮 Contrôles
- **WASD** ou **Flèches directionnelles** : Déplacer le vaisseau
- **E (Interact)** : Miner une ressource (maintenir pour miner)
- **Escape** : Mettre en pause/reprendre le jeu
- **Gamepad** : Stick gauche pour le mouvement

## 🏗️ Structure du Projet

### Scènes
- `Assets/Scenes/Exploration.unity` — Scène principale du prototype

### Scripts (`Assets/Scripts/`)
- `ChunkManager.cs` — Génération/destruction dynamique des chunks autour du joueur
- `Chunk.cs` — Informations sur chaque chunk (coordonnées, zone)
- `SpaceObjectSpawner.cs` — Génération d’objets (ressources, etc.) dans chaque chunk
- `Resource.cs` — Données et logique de chaque ressource (type, quantité, temps de minage, nom affiché)
- `PlayerInventory.cs` — Gestion de l’inventaire du joueur (deutérium, minerai)
- `PlayerMiner.cs` — Minage interactif (UI, barre, collecte après maintien de E)
- `ShipController.cs` — Contrôle du mouvement du vaisseau
- `BaseStation.cs` — Gestion de la base station
- `CameraFollow.cs` — Suivi de caméra fluide
- `PlayerInputHandler.cs` — Gestion des inputs avec le nouveau Input System
- `GameManager.cs` — Gestion globale du jeu

### Art (`Assets/Art/`)
- **Sprites temporaires à créer dans Unity** :
  - Triangle (vaisseau), cercle (base), cercles colorés (ressources)

## 🎯 Fonctionnalités Implémentées

### ✅ Complété
- [x] Génération procédurale de chunks autour du joueur
- [x] Système de zones (difficulté/variété selon la distance à la base)
- [x] Génération d’objets dans les chunks (ressources : Deutérium, Minerai...)
- [x] Système de minage interactif :
  - Affichage d’un message `[E Maintenir] Miner <nom>` et d’une barre de chargement
  - Maintien de la touche E (Input System, action "Interact") pour miner
  - Temps de minage paramétrable par ressource (ex : Deutérium = 1s, Minerai = 2s)
  - Collecte de la ressource à la fin du minage, ajout à l’inventaire
- [x] Inventaire du joueur (deutérium, minerai)
- [x] UI : barre de minage (Image type Filled) et message (TextMeshProUGUI)
- [x] Nouveau Input System Unity (toutes les interactions passent par "Interact")
- [x] Mouvement du vaisseau, rotation automatique, suivi de caméra
- [x] Base station fixe au centre (0,0)
- [x] Système de pause avec Escape
- [x] Graphismes temporaires via Unity Shapes

### 🔄 En cours / À améliorer
- [ ] Collisions entre vaisseau et base
- [ ] Plus d'objets spatiaux (ennemis, commerçants, anomalies...)
- [ ] Système de consommation de deutérium (fuel) lors des déplacements
- [ ] Affichage du stock de ressources dans le HUD principal
- [ ] Système de retour à la base et d’améliorations (modules, upgrades)
- [ ] Effets visuels et sonores
- [ ] Optimisation et gestion fine des priorités d’interaction

## 🚀 Comment Tester
1. Ouvrir Unity et charger le projet
2. Ouvrir la scène `Assets/Scenes/Exploration.unity`
3. Vérifier que les scripts sont bien attachés sur les GameObjects
4. Créer et assigner les sprites temporaires (triangle/cercle/ressources) dans les SpriteRenderer
5. Appuyer sur Play
6. Utiliser WASD pour déplacer le vaisseau
7. Approcher une ressource, maintenir E pour miner et collecter
8. Observer la génération dynamique des chunks et des ressources

## 🎨 Graphismes Temporaires
- **Vaisseau** : Triangle bleu clair pointant vers le haut (à créer dans Unity)
- **Base** : Cercle gris de 2x2 unités (à créer dans Unity)
- **Ressources** : Cercles colorés (ex : bleu pour Deutérium, gris pour Minerai)
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
- Action "Interact" (Button, bindée sur E)
- Bindings pour clavier (WASD, flèches, E) et gamepad

### Architecture
- **ChunkManager** : Génération/destruction dynamique des chunks
- **SpaceObjectSpawner** : Génération d’objets dans chaque chunk
- **Resource** : Données et logique de chaque ressource (type, quantité, temps de minage, nom affiché)
- **PlayerMiner** : Minage interactif (UI, barre, collecte après maintien de E)
- **PlayerInventory** : Gestion de l’inventaire du joueur
- **ShipController** : Mouvement et rotation du vaisseau
- **CameraFollow** : Suivi fluide
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
3. **Erreur Input System** : Vérifier que toutes les actions sont bien assignées dans l’Inspector
4. **Ressource disparait sans minage** : Vérifier que la collecte automatique est bien désactivée dans PlayerInventory
5. **Erreurs de compilation** : Vérifier que tous les scripts sont dans Assets/Scripts/

### Debug
- Utiliser la Console Unity pour voir les logs
- Vérifier les références dans l'Inspector
- Tester les inputs dans l'Input Debugger

## 📈 Prochaines Étapes
1. **Objets spatiaux** : Ajouter ennemis, commerçants, anomalies
2. **Gameplay** : Système de consommation de deutérium (fuel) lors des déplacements
3. **UI/UX** : Affichage du stock de ressources dans le HUD principal
4. **Progression** : Système de retour à la base et d’améliorations (modules, upgrades)
5. **Audio/VFX** : Effets sonores et visuels lors du minage/collecte
6. **Optimisation** : Performance, gestion des priorités d’interaction

---
**Développé pour le projet Infinite Space** 🚀 