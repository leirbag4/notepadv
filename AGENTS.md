# Notepadv — Project Log

## Build Command
```powershell
& "$env:USERPROFILE\.dotnet\dotnet.exe" build "C:\projects\notepadv\Notepadv.csproj"
```

## Session 1 — Initial Setup & Language Styles
- Created WinForms project targeting net8.0-windows
- Added Scintilla.NET 5.3.2.9 NuGet package
- Implemented File/Open, File/Save, File/Save As with encoding detection (UTF-8 BOM, UTF-16 LE/BE, UTF-32)
- Implemented Edit/Copy, Edit/Cut, Edit/Paste
- Created dark theme with custom `NotepadvColorTable` and `NotepadvRenderer` (violet menu borders #8A62B9, light gray selection #3E3E40)
- Created `LangStyles/` folder with `ILangStyle.cs`, `LangStyleBase.cs`, `StyleManager.cs`, `LanguageDetector.cs`, and 10 language styles
- Language menu with check mark on active item
- Code folding, brace matching, violet caret, caret line for all styles
- Auto-language detection on paste only
- Drag-and-drop file open
- Git repo initialized and pushed to `https://github.com/leirbag4/notepadv.git`

## Session 2 — Line Number Color (None mode)
- Changed line number foreground in `NoneStyle.cs` to `#555555`

## Session 3 — Language Detection by Extension
- Added `_extLangMap` dictionary mapping file extensions to language names
- Added `ApplyLanguageByExtension()` called from `OpenFile()` (covers both File > Open and drag-drop)
- Unknown/unrecognized extensions reset language to "None"

## Session 4 — Config Persistence (SaveData/Config.cs)
- Created `SaveData/Config.cs` with `Config.Width`, `Config.Height`, `Config.ZoomSize` static accessors
- Serializes to/from `%appdata%\notepadv\config.json` using `System.Text.Json`
- Loaded on form startup, saved on close
- Window size (Width/Height) and Scintilla zoom level are persisted

## Session 5 — View > Reset Zoom
- Added `viewMenu` with `resetZoomMenuItem` between Edit and Language in the menu strip
- `ResetZoomMenuItem_Click` sets `scintilla.Zoom = 0`

## Session 6 — Divider Lines
- Created `NotepadvRenderer` extending `ToolStripProfessionalRenderer`
- Overrides `OnRenderToolStripBorder`:
  - MenuStrip bottom border: 2px line in `#4A365E` (with 2px bottom padding on the menu strip)
  - StatusStrip top border: 1px line in `#30233D`
- Overrides `OnRenderItemCheck`: draws a solid filled circle in `#9326FF` instead of checkmark

## Relevant Files
- `Form1.cs` — main form logic
- `Form1.Designer.cs` — UI layout
- `SaveData/Config.cs` — config persistence
- `LangStyles/` — per-language syntax highlighting
- `AGENTS.md` — this file
