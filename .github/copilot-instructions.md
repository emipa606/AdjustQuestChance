# GitHub Copilot Instruction Guide for Adjust Quest Chance (Continued)

## Mod Overview and Purpose

**Adjust Quest Chance (Continued)** is an update of the original mod by GwinnBleidd. It addresses the issue of repetitive and unbalanced quest generation in RimWorld by allowing players to adjust the frequency of different types of quests. This mod is ideal for players who find themselves inundated with irrelevant quests, such as "take care of my favourite squirrel," especially in challenging scenarios like starting on a sea ice biome with no nearby settlements.

## Key Features and Systems

- **Configurable Quest Weights**: Customize the probabilities of different quest types to better match your preferred play style. Increase travel-related quests or decrease the frequency of minor fetch quests as you see fit.
- **Seamless Integration**: The mod's settings align with the game’s default settings but offer sliders that must be adjusted by the player to take effect.
- **Save Game Compatibility**: Changes apply after reloading a saved game, providing a seamless experience without needing a game restart.

## Coding Patterns and Conventions

- **Modular Design**: The project is organized using distinct C# classes for configuration, game initialization, and save loading. This modular approach ensures clarity and maintainability.
- **Naming Conventions**: Classes and methods follow PascalCase, a common C# convention. For example, methods like `ApplyChances` and `DoSettingsWindowContents`.
- **Error Reporting**: A comprehensive error reporting system is encouraged. Users are advised to use Discord channels and log uploaders for support rather than forum threads.

## XML Integration

- **Config Files**: The mod uses XML files for defining dependencies and module information:
  - `About.xml`: Specifies mod dependencies, such as `brrainz.harmony`.
  - `Manifest.xml`: Provides metadata and versioning information.
  
XML is used minimally in this mod, with most of the functionality handled in C#.

## Harmony Patching

- **Harmony Usage**: The mod heavily relies on Harmony for patching the game's original code. This allows for the alteration of quest generation processes without modifying the core game files.
- **Postfix Methods**: Harmony `Postfix` methods are used in files like `Game_InitNewGame.cs` and `SavedGameLoaderNow_LoadGameFromSaveFileNow.cs` to insert code after original methods execute. This ensures compatibility with other mods and minimizes conflicts.

## Suggestions for Copilot

1. **Code Expansion**: Utilize Copilot to generate additional helper methods or refactor existing methods for better performance and readability.
2. **Enhance Configurations**: Suggest ways to extend the mod's configurability, such as adding new quest categories or more detailed control over quest traits.
3. **Documentation Improvement**: Propose comments and inline documentation to enhance code understanding for future developers.
4. **Error Handling**: Implement comprehensive error handling with logging using Copilot suggestions to improve user support.
5. **Optimization Tips**: Provide Copilot-driven suggestions for optimizing performance, especially in the methods related to quest list compilation and modification.

This document serves as a guide for contributors and users of the Adjust Quest Chance (Continued) mod, offering insights into its systems and development best practices.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

