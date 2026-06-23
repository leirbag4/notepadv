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

## Session 6 — Divider Lines & Checkmark
- Created `NotepadvRenderer` extending `ToolStripProfessionalRenderer`
- Overrides `OnRenderToolStripBorder`:
  - MenuStrip bottom border: 2px line in `#4A365E` (with 2px bottom padding on the menu strip)
  - StatusStrip top border: 1px line in `#30233D`
- Overrides `OnRenderItemCheck`: draws a solid filled circle in `#9326FF` instead of checkmark
- Added `File > About` menu item

## Session 7 — Custom Dialogs & Overlay
- Created `UI/Style/SimpleOverlay.cs` — semi-transparent black overlay (50% opacity) for modal dialogs
- Created `UI/Controls/DarkForm.cs` — base form class with `ShowMe()` wrapping `ShowDialog()` + overlay, custom border painting, Escape to close
- Created `UI/VampGraphics/VampirioGraphics.cs` — `FillRect` helper for border painting
- Created custom controls (`ButtonAdv`, `LabelAdv`, `PictureBoxAdv`, `GroupBoxAdv`, `TextBoxAdv`) with dark theme styling
- Adapted `MsgBox.cs` — replaces native `MessageBox` with custom dark dialog; supports `DialogButtons`, `DialogIcon`, custom button text
- Adapted `InputMsgBox.cs` — input dialog with textbox, ok/cancel, Enter key support
- Created `AboutUI.cs` — About dialog with version, links (opens in browser), close button
- Replaced all `MessageBox.Show()` calls in `Form1.cs` with `MsgBox.Show()`
- Added `Config.Version` property

## Relevant Files
- `Form1.cs` — main form logic
- `Form1.Designer.cs` — UI layout
- `SaveData/Config.cs` — config persistence
- `LangStyles/` — per-language syntax highlighting
- `UI/Style/SimpleOverlay.cs` — overlay form
- `UI/Controls/DarkForm.cs` — base modal dialog form
- `UI/Controls/ButtonAdv.cs`, `LabelAdv.cs`, `PictureBoxAdv.cs`, `GroupBoxAdv.cs`, `TextBoxAdv.cs` — custom controls
- `UI/MsgBox.cs` + `.Designer.cs` — custom message box
- `UI/InputMsgBox.cs` + `.Designer.cs` — custom input dialog
- `UI/AboutUI.cs` + `.Designer.cs` — About dialog
- `Res/Dialogs/` — dialog icon images
- `AGENTS.md` — this file

## Session 8 — DarkTitleBar, FindUI, GoToUI, Command-Line Args, App Icon
- `DarkTitleBarHelper.cs` — DWM immersive dark mode on all forms via `DwmSetWindowAttribute`
- `UI/FindUI.cs` — find/replace overlay (Ctrl+F / Ctrl+H) with ScintillaNET native search APIs, search highlighting (indicator 8), Replace All, history, match case/whole word/regex; wraps around with `SetSel(0, 0)`
- `UI/GoToUI.cs` — borderless modal dialog centered on Scintilla, violet 2px border painted in OnPaint, numeric-only KeyPress filter, overlay via SimpleOverlay
- `Program.cs` passes command-line file path to Form1 constructor
- Application icon set via `<ApplicationIcon>` in .csproj + `Form1.Icon = Properties.Resources.app_icon`
- All images embedded via `Properties/Resources.resx` (ResXFileRef), not loaded from disk at runtime
- File > About moved to Help > About
- Default "None" checked in language menu

## Session 9 — ComboBoxAdv, VampirioEditor, ContextMenu, ScrollBarAdv Integration
- `UI/Controls/ComboBoxAdv.cs` — custom dark ComboBox with WndProc custom painting from VampirioCode
- `VampirioEditor.cs` copied from VampirioCode — wraps Scintilla with GetScrollInfo P/Invoke, scroll events, context menu, brace highlighting, smart indent via OnInsertCheck, Ctrl+X/C copy whole line if no selection
- `VampEditor/UI/ContextMenu.cs` — generic `ContextMenu<T>` with dark renderer, ItemPressed and Opening events
- `UI/Controls/ContextMenuRenderer.cs` — ToolStripProfessionalRenderer with dark colors, custom separator and border
- `UI/Controls/ScrollBarAdv.cs` — exact copy from VampirioCode (double-buffered, custom thumb/track/button, drag support, auto-repeat timer, arrow polygons)
- `UI/Controls/ScrollBarAdvance/` — 7 support files (ScrollEvent, ScrollBarOrientation, ScrollBarButton, ElementState, ColorState, ScrollBarElement, ScrollBarUtils)
- Form1.Designer.cs changed `scintilla` type from `ScintillaNET.Scintilla` to `Notepadv.VampEditor.VampirioEditor`
- Scrollbar integration: `CreateCustomScrollBars()`, `RefreshScrollBarsVisibility()`, event wiring
- Output exe name changed to `notepadv.exe` via `<AssemblyName>notepadv</AssemblyName>`
- Scrollbars brought to front after ShowFindUI to remain on top of FindUI

## Session 10 — Scrollbar Bugfixes & Context Menu Refinements
- `GetWindowLong` + `WS_HSCROLL`/`WS_VSCROLL` added for immediate scrollbar visibility detection (replacing `Lines.Count > LinesOnScreen`)
- `SizeChanged` handler forces scroll events + `RefreshScrollBarsVisibility` — fixes scrollbar appearing with stale GetScrollInfo values
- `g.Clear(trackColors.NormalColor)` in ScrollBarAdv.OnPaint — fixes background color mismatch from thumb padding gaps
- Context menu: removed "Open output file" item; removed `OpenBinDirLocation`/`OpenOutputFilename` enums
- Added "Open file location" — opens Windows Explorer with `/select` via `_currentFilePath`
- Disabled (grayed out) when no file open via `HasFilePath` property + `OnContextOpening`
- `HasFilePath` property added to VampirioEditor

## Session 11 — New File, Undo/Redo, File > New: Ctrl+N
- File > New (Ctrl+N) — prompts save if modified, clears text, resets file path/encoding/language to "None"
- Edit > Undo (Ctrl+Z) and Edit > Redo (Ctrl+Shift+Z) with horizontal separator
- In Progress: Undo grouping by word boundaries — Scintilla's default undo coalesces all typing into one action due to OnInsertCheck modifying Enter text. Plan: toggle `SCI_SETUNDOCOLLECTION` after space/tab/enter to create clean undo action boundaries (Sublime Text / VS Code behavior).

## Next Steps (Session 11+)
1. Implement word-boundary undo grouping in VampirioEditor:
   - Override `OnKeyDown` to toggle undo collection after break keys (space, tab, enter)
   - Consecutive Enters grouped as one undo action
   - Arrow keys, mouse click, paste, backspace/delete as additional break points
