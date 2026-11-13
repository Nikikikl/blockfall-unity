# BlockFall

BlockFall is a first learning project: an original 2D falling-block game built with Unity 6.6 (Universal 2D / URP), with a Web release planned for itch.io.

## Development principles

- Keep implementations simple, readable, and minimal. Apply the project's `$ponytail` principles when implementing and reviewing code.
- Prefer built-in Unity and C# features over third-party dependencies. Avoid premature abstractions, unnecessary frameworks, and speculative features.
- Maintain compatibility with Unity 6.6 and Web builds.

## Incremental workflow

- Implement only the requested task in small, independently testable changes. Start the next development stage only when asked.
- Explain what changed and why in plain language. Help the developer understand the C# and Unity concepts involved.

## Testing and verification

- Check the modified code and relevant project files. Give exact steps and expected results for testing each change in the Unity Editor.
- Claim that Unity compilation, Play Mode, or a Web build succeeded only after verifying it. Report what was not verified and any unresolved issues.

## Git safety

- Preserve Unity `.meta` files and their GUID references. Do not modify or commit generated directories such as `Library/`, `Temp/`, `Logs/`, or `Obj/`.
- Never run destructive Git commands. Commit, push, create branches, or rewrite history only with explicit permission.
- When asked to commit, give each completed and verified milestone its own commit. Push only when requested.

## Project boundaries

- Work only inside the BlockFall repository unless explicitly authorized to work elsewhere. Do not modify university projects or other repositories.
- Do not change global Codex settings or skills. Do not install executable hooks or additional tools without permission.
