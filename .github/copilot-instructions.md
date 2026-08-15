# GitHub Copilot Instructions for Adjust Quest Chance (Continued)

## Mod Overview and Purpose

**Mod Name**: Adjust Quest Chance (Continued)  
**Author**: Originally by GwinnBleidd, continued by the current maintainer.  
**Description**: This mod empowers players to customize their RimWorld experience by adjusting quest probabilities. It caters to players who prefer certain types of quests, whether you'd rather embark on epic map quests or simply care for adorable (yet persistent) little animals. Control the game flow and quest engagement using adjustable weights to suit your strategic interests.

## Key Features and Systems

- **Quest Weight Adjustment**: Modify the probabilities of various quest types to enhance or reduce their occurrence.
- **Configurable Settings**: All quest probability settings are configurable via the mod's settings menu.
- **Dynamic Application**: Changes to quest weights apply upon loading a saved game without needing a full game restart.
- **Seamless Integration**: Uses Harmony to patch RimWorld's existing systems for smooth operation.

## Coding Patterns and Conventions

- **Naming Conventions**: Class and method names should be descriptive of their functionality. For example, `AdjustQuestChance.cs` contains methods directly related to altering quest probabilities.
- **Modularization**: Break functionality into logical sections, such as initialization (`init`), application of settings (`ApplyChances`), and UI management (`DoSettingsWindowContents`).
- **Documentation**: Use XML comments to describe classes and methods. Ensure each method's purpose is clear, especially for those modifying game behavior.
- **Error Handling**: Implement thoughtful error checking, especially when settings or dependencies may alter game behavior.

## XML Integration

- **About.xml**: Required for defining mod metadata such as `packageId` and dependencies (e.g., `brrainz.harmony`).
- **Manifest.xml**: Ensures mod loading order and dependencies are clearly defined. Keep this current with all external libraries used.
- **Mod Settings Handling**: Define XML-based user interface settings to allow for real-time interaction with mod configurations.

## Harmony Patching

- **Purpose**: Harmony patches are used to modify or extend functionalities of the base game without altering original source code.
- **Usage**: Implement Harmony patches in a non-destructive manner, usually with `Postfix` methods to ensure original functionality remains intact.
- **Files and Methods**:
  - `SavedGameLoaderNow_LoadGameFromSaveFileNow.cs`: Contains `Postfix` for saving game loading adjustments.
  - `Game_InitNewGame.cs`: Another `Postfix` example for initializing new game settings.
- **Setup**: Ensure proper initialization of Harmony instance in `AdjustQuestChance.cs` with comprehensive patching across necessary game methods.

## Suggestions for Copilot

To maximize GitHub Copilot's effectiveness, consider the following when working on the `Adjust Quest Chance (Continued)` mod:

- **Contextual Awareness**: Include thorough code comments to ensure Copilot suggestions are contextually relevant.
- **Consistent Naming**: Use consistent naming conventions across classes and methods to help Copilot recognize patterns.
- **Method Stubs**: Create method stubs and document the intended input/output for Copilot to generate more accurate and beneficial code.
- **Logical Segments**: Break code tasks into smaller, logical segments that Copilot can assist with.
- **Comment-Driven Development**: Utilize "TODO" and similar comment tags to guide Copilot towards generating code for unfinished plans or ideas.

By leveraging these guidelines, Copilot can effectively aid in maintaining and improving the `Adjust Quest Chance (Continued)` mod's codebase. Enjoy creating a more tailored and enjoyable gaming experience for your mod's users!

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

