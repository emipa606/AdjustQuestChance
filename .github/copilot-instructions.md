# GitHub Copilot Instructions for Adjust Quest Chance (Continued) Mod

## Mod Overview and Purpose

**Mod Name:** Adjust Quest Chance (Continued)

**Description:** 
This mod enhances the gameplay experience of RimWorld by allowing players to adjust the probability of receiving specific types of quests. Whether stranded on sea ice without the means to travel or simply tired of low-value quests, this mod empowers players to customize quest distribution to suit their playstyle. All quest weights are adjustable through mod settings, ensuring a tailored experience while maintaining game balance rules such as pawn and quest limits.

**Notice:** 
- Default mod settings mirror the game's defaults. Players must modify the settings to change quest probabilities.
- A game save reload is required for changes to take effect; however, a game restart is not necessary.

## Key Features and Systems

- **Configurable Quest Weights:** Adjust the chance of receiving various quest types through a user-friendly settings interface.
- **Enhanced Game Control:** Maintains game rules while still providing players the flexibility to choose their quest preferences.
- **Sea Ice and Resource-Limited Support:** Special attention towards settings that help players stuck in challenging biomes or scenarios.

## Coding Patterns and Conventions

The mod follows industry-standard C# coding practices, focusing on readability and maintainability:

- **Class and Method Naming:** Classes and methods use PascalCase, and private methods or variables use camelCase.
- **Internal Accessibility:** Many classes are marked as `internal`, emphasizing encapsulation and limiting exposure to only necessary components.
- **File Organization:** Logical separation of concerns with each class in its respective file, adhering to the single responsibility principle.

## XML Integration

- **ModSettings:** Utilizes XML files to facilitate seamless integration with RimWorld’s mod settings, ensuring that changes to quest probabilities are properly stored and retrieved.

## Harmony Patching

Harmony is used within the project to apply non-intrusive patches to the game:

- **Dynamic Patching:** Hooks into relevant location points such as game initialization and loaded game states to apply and synchronize settings.
- **Compatibility:** Efforts are made to ensure harmony patches are compatible with other mods by respecting method detouring best practices.

## Suggestions for Copilot

- **Suggest Common Patterns:** When implementing code that interacts with the RimWorld API, suggest patterns used in `ModSettings` and `DrawWindow` methods.
- **Recommend Code Completion:** Assist with completing Harmony patches, ensuring accurate method signatures and correct detouring practices.
- **Provide XML snippets:** When working with settings, provide XML snippets that adhere to the mod settings schema.
- **Optimize Code Blocks:** Offer suggestions to optimize existing code, such as improving performance for adjustable settings rendering.

These guidelines will help ensure that contributions and code suggestions align with the project's existing structure and goals, making it easier for developers to enhance the mod's functionality effectively.
