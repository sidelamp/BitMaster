# BitMaster

Тестовое desktop-приложение для учёта автопарка: машины, водители и экипажи (связка «машина + водитель»).
Windows Forms, .NET Framework 4.7.2, база данных — SQLite.

## Возможности

- Три вкладки: **Экипажи**, **Водители**, **Машины** — с добавлением, редактированием и удалением записей.
- Экипажи загружаются при старте, водители и машины — лениво, при первом открытии вкладки.
- Редактирование — в отдельных окнах (двойной клик по строке или кнопка «Изменить»), построенных на общем базовом классе `EntityEditForm`.
- Проверки данных: уникальность гос. номера и номера прав, нельзя удалить машину/водителя, закреплённых за экипажем, у машины и водителя может быть только один активный экипаж.
- Фоновая очистка: раз в 30 секунд неактивные экипажи удаляются из БД в фоновом потоке (`BackgroundWorker`), таблица обновляется на глазах.
- Закрытие окон редактирования по `Esc`; при несохранённых изменениях — вопрос «Есть изменения, сохранить?».
- При первом запуске база создаётся и заполняется тестовыми данными (по 5 записей в каждую таблицу).

## Структура проекта

```
BitMaster/
├── src/
│   ├── Data/
│   │   ├── Database.cs      # подключение к SQLite, схема, сид, CRUD
│   │   └── Models.cs        # классы Car, Driver, Crew
│   ├── Forms/
│   │   ├── EntityEditForm.cs# базовая форма редактирования (Сохранить/Удалить/Esc)
│   │   ├── MainForm.cs      # главное окно: вкладки, гриды, фоновая очистка
│   │   ├── Car/CarEdit.cs   # редактирование машины
│   │   ├── Driver/…         # редактирование водителя
│   │   └── Crew/…           # редактирование экипажа
│   └── Helpers/
│       └── ImageHelper.cs   # масштабирование иконок
├── Resources/               # иконки (png)
├── packages.config          # зависимости NuGet
└── BitMaster.csproj
```

База данных — файл `bitmaster.db` рядом с `.exe`. Чтобы пересоздать тестовые данные — просто удалите файл.

## Требования

- Windows с .NET Framework 4.7.2 или новее (входит в Windows 10/11).
- Visual Studio **не обязательна** — см. сборку ниже.

## Сборка без Visual Studio

### 1. Восстановить пакеты NuGet

Папка `packages/` в репозиторий не входит. Если её нет (свежий клон) — скачайте [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe) и выполните:

```bat
nuget restore BitMaster.csproj -PackagesDirectory packages
```

Если проект уже хотя бы раз собирался в Visual Studio — пакеты на месте, этот шаг можно пропустить.

### 2. Скомпилировать через MSBuild

MSBuild входит в состав .NET Framework, отдельно ничего ставить не нужно.
Собирать нужно файл проекта `.csproj` (MSBuild из .NET Framework не понимает формат решения `.slnx`).

```bat
:: Debug
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe BitMaster.csproj /p:Configuration=Debug

:: Release
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe BitMaster.csproj /t:Rebuild /p:Configuration=Release
```

Готовый exe появится в `bin\Debug\` или `bin\Release\`.

### Альтернатива: Build Tools for Visual Studio

Если установлены [Build Tools for VS 2022](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2022), можно собирать решение целиком:

```bat
nuget restore BitMaster.slnx
MSBuild.exe BitMaster.slnx /p:Configuration=Release
```

## Запуск

```bat
bin\Release\BitMaster.exe
```

Или просто двойной клик по `BitMaster.exe`. При первом запуске рядом появится `bitmaster.db` с тестовыми данными.
