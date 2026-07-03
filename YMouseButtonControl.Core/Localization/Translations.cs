using System.Collections.Generic;

namespace YMouseButtonControl.Core.Localization;

/// <summary>
/// Translation tables keyed by a stable identifier. English (<see cref="En"/>) is the source of
/// truth and defines every key; the other languages may omit keys and fall back to English.
/// </summary>
public static class Translations
{
    public static readonly IReadOnlyDictionary<string, string> En = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Apply",
        ["Btn_Cancel"] = "Cancel",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Close",
        ["Btn_Copy"] = "Copy",
        ["Btn_Add"] = "Add",
        ["Btn_Edit"] = "Edit",
        ["Btn_Remove"] = "Remove",
        ["Btn_Import"] = "Import",
        ["Btn_Export"] = "Export",
        ["Btn_Up"] = "Up",
        ["Btn_Down"] = "Down",
        ["Btn_Refresh"] = "Refresh",

        // Main window
        ["Main_AppWindowProfiles"] = "Application / Window Profiles",
        ["Main_ProfileInformation"] = "Profile Information",
        ["Main_Settings"] = "Settings",
        ["Main_SaveProfile"] = "Save Profile",
        ["Main_LoadProfile"] = "Load Profile",

        // Profile information
        ["Info_Description"] = "Description",
        ["Info_WindowCaption"] = "Window Caption",
        ["Info_Process"] = "Process",
        ["Info_WindowClass"] = "Window Class",
        ["Info_ParentClass"] = "Parent Class",
        ["Info_MatchType"] = "Match Type",

        // Layer view
        ["Layer_Tab1"] = "Layer 1",
        ["Layer_Tab2"] = "Layer 2",
        ["Layer_TabScrolling"] = "Scrolling",
        ["Layer_TabOptions"] = "Options",
        ["Layer_Name"] = "Layer Name",
        ["Layer_1Default"] = "Layer 1 (Default)",
        ["Layer_Swap"] = "Swap",
        ["Layer_Reset"] = "Reset",

        // Mouse button labels
        ["Mb_Left"] = "Left Button",
        ["Mb_Right"] = "Right Button",
        ["Mb_Middle"] = "Middle Button",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Wheel Up",
        ["Mb_WheelDown"] = "Wheel Down",
        ["Mb_WheelLeft"] = "Wheel Left",
        ["Mb_WheelRight"] = "Wheel Right",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Disabled",
        ["Map_NoChange"] = "** No Change (Don't Intercept) **",
        ["Map_SimulatedUndefined"] = "Simulated Keys (undefined)",
        ["Map_RightClick"] = "Right Click",
        ["Map_SimulatedKeysFmt"] = "Simulated Keys: ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "As mouse button is pressed & when released",
        ["Skt_During"] = "During (press on down, release on up)",
        ["Skt_ThreadPressed"] = "In another thread as mouse button is pressed",
        ["Skt_ThreadReleased"] = "In another thread as mouse button is released",
        ["Skt_AsPressed"] = "As mouse button is pressed",
        ["Skt_AsReleased"] = "As mouse button is released",
        ["Skt_Repeat"] = "Repeatedly while the button is down",
        ["Skt_StickyHold"] = "Sticky (held down until button is pressed again)",
        ["Skt_StickyRepeat"] = "Sticky (repeatedly until button is pressed again)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "pressed & released",
        ["SktShort_During"] = "during",
        ["SktShort_ThreadPressed"] = "thread-down",
        ["SktShort_ThreadReleased"] = "thread-up",
        ["SktShort_AsPressed"] = "pressed",
        ["SktShort_AsReleased"] = "released",
        ["SktShort_Repeat"] = "repeat",
        ["SktShort_StickyHold"] = "sticky hold",
        ["SktShort_StickyRepeat"] = "sticky repeat",

        // Process selector dialog
        ["Proc_Title"] = "Choose Application",
        ["Proc_SelectRunning"] = "Select from the list of running applications:",
        ["Proc_FilterWatermark"] = "Process Filter",
        ["Proc_ColProcess"] = "Process",
        ["Proc_ColProcessName"] = "ProcessName",
        ["Proc_ColWindowTitle"] = "Window Title",
        ["Proc_ColFileName"] = "File Name",
        ["Proc_OrBrowse"] = "Or type in/browse to the application executable (.EXE) file",
        ["Proc_Application"] = "Application",
        ["Proc_SpecificWindow"] = "Specific Window",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Simulated Keystrokes - {0}",
        ["Sk_EnterCustomKeys"] = "Enter the custom key(s)",
        ["Sk_MenuModifier"] = "Modifier Keys",
        ["Sk_MenuStandard"] = "Standard Keys",
        ["Sk_MenuDirection"] = "Direction Keys",
        ["Sk_MenuFunction"] = "Function Keys",
        ["Sk_MenuNumeric"] = "Numeric Keypad",
        ["Sk_MenuMedia"] = "Media Keys",
        ["Sk_MenuBrowser"] = "Browser Keys",
        ["Sk_MenuMouse"] = "Mouse Buttons",
        ["Sk_HowToSend"] = "How to send the simulated key strokes:",
        ["Sk_Mode6Tip"] = "Mode 6 (repeat while mouse down) does not work on Linux.",
        ["Sk_BlockInput"] = "Block original mouse input",
        ["Sk_BlockInputTip"] = "Suppress the original mouse click or not.\nWindows and macOS only.",
        ["Sk_AutoRepeatDelay"] = "Auto Repeat Delay",
        ["Sk_AutoRepeatDelayTip"] =
            "The delay in milliseconds before repeating. 33 is the default.\nThe lower the number, the quicker the repeat. The higher the number, the slower the repeat.",
        ["Sk_RandomizeDelay"] = "Randomize auto repeat delay 0%-10%",
        ["Sk_DescriptionDropdown"] = "Description (to show in the button drop-down)",
        ["Sk_CursorPosition"] = "Cursor Position: X,Y",

        // Global settings dialog
        ["Set_Title"] = "Global Settings",
        ["Set_StartMinimized"] = "Start Minimized",
        ["Set_StartMenu"] = "Start Menu",
        ["Set_StartMenuTip"] = "Add YMouseButtonControl to the start menu.\nDisabled for macOS.",
        ["Set_Logging"] = "Logging",
        ["Set_LoggingTip"] =
            "Whether or not logging to file YMouseButtonControl.log is performed. Requires a restart.",
        ["Set_Theme"] = "Theme",
        ["Set_ThemeTip"] =
            "The application theme. Requires a restart.\nDefault: follow the theme of your OS. Doesn't work on Linux.\nLight: light theme.\nDark: dark theme.",
        ["Set_Language"] = "Language",
        ["Set_LanguageTip"] = "The application language. Requires a restart.",
        ["Set_LanguageSystem"] = "System default",

        // Tray icon menu
        ["Tray_Setup"] = "Setup",
        ["Tray_RunAtStartup"] = "Run at startup",
        ["Tray_Exit"] = "Exit",
    };

    public static readonly IReadOnlyDictionary<string, string> Ru = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Применить",
        ["Btn_Cancel"] = "Отмена",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Закрыть",
        ["Btn_Copy"] = "Копировать",
        ["Btn_Add"] = "Добавить",
        ["Btn_Edit"] = "Изменить",
        ["Btn_Remove"] = "Удалить",
        ["Btn_Import"] = "Импорт",
        ["Btn_Export"] = "Экспорт",
        ["Btn_Up"] = "Вверх",
        ["Btn_Down"] = "Вниз",
        ["Btn_Refresh"] = "Обновить",

        // Main window
        ["Main_AppWindowProfiles"] = "Профили приложений / окон",
        ["Main_ProfileInformation"] = "Информация о профиле",
        ["Main_Settings"] = "Настройки",
        ["Main_SaveProfile"] = "Сохранить профиль",
        ["Main_LoadProfile"] = "Загрузить профиль",

        // Profile information
        ["Info_Description"] = "Описание",
        ["Info_WindowCaption"] = "Заголовок окна",
        ["Info_Process"] = "Процесс",
        ["Info_WindowClass"] = "Класс окна",
        ["Info_ParentClass"] = "Родительский класс",
        ["Info_MatchType"] = "Тип совпадения",

        // Layer view
        ["Layer_Tab1"] = "Слой 1",
        ["Layer_Tab2"] = "Слой 2",
        ["Layer_TabScrolling"] = "Прокрутка",
        ["Layer_TabOptions"] = "Параметры",
        ["Layer_Name"] = "Имя слоя",
        ["Layer_1Default"] = "Слой 1 (По умолчанию)",
        ["Layer_Swap"] = "Поменять",
        ["Layer_Reset"] = "Сбросить",

        // Mouse button labels
        ["Mb_Left"] = "Левая кнопка",
        ["Mb_Right"] = "Правая кнопка",
        ["Mb_Middle"] = "Средняя кнопка",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Колесо вверх",
        ["Mb_WheelDown"] = "Колесо вниз",
        ["Mb_WheelLeft"] = "Колесо влево",
        ["Mb_WheelRight"] = "Колесо вправо",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Отключено",
        ["Map_NoChange"] = "** Без изменений (не перехватывать) **",
        ["Map_SimulatedUndefined"] = "Симулируемые клавиши (не определено)",
        ["Map_RightClick"] = "Правый клик",
        ["Map_SimulatedKeysFmt"] = "Симулируемые клавиши: ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "При нажатии и отпускании кнопки мыши",
        ["Skt_During"] = "В течение (нажать при нажатии, отпустить при отпускании)",
        ["Skt_ThreadPressed"] = "В отдельном потоке при нажатии кнопки мыши",
        ["Skt_ThreadReleased"] = "В отдельном потоке при отпускании кнопки мыши",
        ["Skt_AsPressed"] = "При нажатии кнопки мыши",
        ["Skt_AsReleased"] = "При отпускании кнопки мыши",
        ["Skt_Repeat"] = "Повторять, пока кнопка удерживается",
        ["Skt_StickyHold"] = "Залипание (удерживается до повторного нажатия кнопки)",
        ["Skt_StickyRepeat"] = "Залипание (повторяется до повторного нажатия кнопки)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "нажать и отпустить",
        ["SktShort_During"] = "в течение",
        ["SktShort_ThreadPressed"] = "поток-нажатие",
        ["SktShort_ThreadReleased"] = "поток-отпускание",
        ["SktShort_AsPressed"] = "нажато",
        ["SktShort_AsReleased"] = "отпущено",
        ["SktShort_Repeat"] = "повтор",
        ["SktShort_StickyHold"] = "залипание-удержание",
        ["SktShort_StickyRepeat"] = "залипание-повтор",

        // Process selector dialog
        ["Proc_Title"] = "Выбор приложения",
        ["Proc_SelectRunning"] = "Выберите из списка запущенных приложений:",
        ["Proc_FilterWatermark"] = "Фильтр процессов",
        ["Proc_ColProcess"] = "Процесс",
        ["Proc_ColProcessName"] = "Имя процесса",
        ["Proc_ColWindowTitle"] = "Заголовок окна",
        ["Proc_ColFileName"] = "Имя файла",
        ["Proc_OrBrowse"] = "Или введите / укажите путь к исполняемому файлу приложения (.EXE)",
        ["Proc_Application"] = "Приложение",
        ["Proc_SpecificWindow"] = "Конкретное окно",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Симулируемые нажатия клавиш — {0}",
        ["Sk_EnterCustomKeys"] = "Введите пользовательскую клавишу (или клавиши)",
        ["Sk_MenuModifier"] = "Клавиши-модификаторы",
        ["Sk_MenuStandard"] = "Стандартные клавиши",
        ["Sk_MenuDirection"] = "Клавиши направления",
        ["Sk_MenuFunction"] = "Функциональные клавиши",
        ["Sk_MenuNumeric"] = "Цифровая клавиатура",
        ["Sk_MenuMedia"] = "Мультимедийные клавиши",
        ["Sk_MenuBrowser"] = "Клавиши браузера",
        ["Sk_MenuMouse"] = "Кнопки мыши",
        ["Sk_HowToSend"] = "Способ отправки симулируемых нажатий клавиш:",
        ["Sk_Mode6Tip"] = "Режим 6 (повтор при удержании мыши) не работает в Linux.",
        ["Sk_BlockInput"] = "Блокировать исходный ввод мыши",
        ["Sk_BlockInputTip"] = "Подавлять или нет исходный щелчок мыши.\nТолько Windows и macOS.",
        ["Sk_AutoRepeatDelay"] = "Задержка автоповтора",
        ["Sk_AutoRepeatDelayTip"] =
            "Задержка в миллисекундах перед повтором. По умолчанию 33.\nЧем меньше значение, тем быстрее повтор. Чем больше значение, тем медленнее повтор.",
        ["Sk_RandomizeDelay"] = "Случайная задержка автоповтора 0%-10%",
        ["Sk_DescriptionDropdown"] = "Описание (для отображения в выпадающем списке кнопки)",
        ["Sk_CursorPosition"] = "Положение курсора: X,Y",

        // Global settings dialog
        ["Set_Title"] = "Глобальные настройки",
        ["Set_StartMinimized"] = "Запускать свёрнутым",
        ["Set_StartMenu"] = "Меню Пуск",
        ["Set_StartMenuTip"] = "Добавить YMouseButtonControl в меню Пуск.\nОтключено для macOS.",
        ["Set_Logging"] = "Ведение журнала",
        ["Set_LoggingTip"] =
            "Вести или нет журнал в файл YMouseButtonControl.log. Требует перезапуска.",
        ["Set_Theme"] = "Тема",
        ["Set_ThemeTip"] =
            "Тема приложения. Требует перезапуска.\nПо умолчанию: следовать теме ОС. Не работает в Linux.\nСветлая: светлая тема.\nТёмная: тёмная тема.",
        ["Set_Language"] = "Язык",
        ["Set_LanguageTip"] = "Язык приложения. Требует перезапуска.",
        ["Set_LanguageSystem"] = "Системный язык по умолчанию",

        // Tray icon menu
        ["Tray_Setup"] = "Настройка",
        ["Tray_RunAtStartup"] = "Запускать при входе в систему",
        ["Tray_Exit"] = "Выход",
    };

    public static readonly IReadOnlyDictionary<string, string> De = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Übernehmen",
        ["Btn_Cancel"] = "Abbrechen",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Schließen",
        ["Btn_Copy"] = "Kopieren",
        ["Btn_Add"] = "Hinzufügen",
        ["Btn_Edit"] = "Bearbeiten",
        ["Btn_Remove"] = "Entfernen",
        ["Btn_Import"] = "Importieren",
        ["Btn_Export"] = "Exportieren",
        ["Btn_Up"] = "Nach oben",
        ["Btn_Down"] = "Nach unten",
        ["Btn_Refresh"] = "Aktualisieren",

        // Main window
        ["Main_AppWindowProfiles"] = "Anwendungs-/Fensterprofile",
        ["Main_ProfileInformation"] = "Profilinformationen",
        ["Main_Settings"] = "Einstellungen",
        ["Main_SaveProfile"] = "Profil speichern",
        ["Main_LoadProfile"] = "Profil laden",

        // Profile information
        ["Info_Description"] = "Beschreibung",
        ["Info_WindowCaption"] = "Fenstertitel",
        ["Info_Process"] = "Prozess",
        ["Info_WindowClass"] = "Fensterklasse",
        ["Info_ParentClass"] = "Übergeordnete Klasse",
        ["Info_MatchType"] = "Übereinstimmungstyp",

        // Layer view
        ["Layer_Tab1"] = "Ebene 1",
        ["Layer_Tab2"] = "Ebene 2",
        ["Layer_TabScrolling"] = "Scrollen",
        ["Layer_TabOptions"] = "Optionen",
        ["Layer_Name"] = "Ebenenname",
        ["Layer_1Default"] = "Ebene 1 (Standard)",
        ["Layer_Swap"] = "Tauschen",
        ["Layer_Reset"] = "Zurücksetzen",

        // Mouse button labels
        ["Mb_Left"] = "Linke Taste",
        ["Mb_Right"] = "Rechte Taste",
        ["Mb_Middle"] = "Mittlere Taste",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Rad nach oben",
        ["Mb_WheelDown"] = "Rad nach unten",
        ["Mb_WheelLeft"] = "Rad nach links",
        ["Mb_WheelRight"] = "Rad nach rechts",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Deaktiviert",
        ["Map_NoChange"] = "** Keine Änderung (nicht abfangen) **",
        ["Map_SimulatedUndefined"] = "Simulierte Tasten (undefiniert)",
        ["Map_RightClick"] = "Rechtsklick",
        ["Map_SimulatedKeysFmt"] = "Simulierte Tasten: ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "Beim Drücken und Loslassen der Maustaste",
        ["Skt_During"] = "Während (drücken beim Runter, loslassen beim Hoch)",
        ["Skt_ThreadPressed"] = "In einem anderen Thread beim Drücken der Maustaste",
        ["Skt_ThreadReleased"] = "In einem anderen Thread beim Loslassen der Maustaste",
        ["Skt_AsPressed"] = "Beim Drücken der Maustaste",
        ["Skt_AsReleased"] = "Beim Loslassen der Maustaste",
        ["Skt_Repeat"] = "Wiederholen, solange die Taste gedrückt ist",
        ["Skt_StickyHold"] = "Einrasten (gehalten bis erneutes Drücken der Taste)",
        ["Skt_StickyRepeat"] = "Einrasten (wiederholen bis erneutes Drücken der Taste)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "gedrückt & losgelassen",
        ["SktShort_During"] = "während",
        ["SktShort_ThreadPressed"] = "Thread-Runter",
        ["SktShort_ThreadReleased"] = "Thread-Hoch",
        ["SktShort_AsPressed"] = "gedrückt",
        ["SktShort_AsReleased"] = "losgelassen",
        ["SktShort_Repeat"] = "wiederholen",
        ["SktShort_StickyHold"] = "eingerastet halten",
        ["SktShort_StickyRepeat"] = "eingerastet wiederholen",

        // Process selector dialog
        ["Proc_Title"] = "Anwendung auswählen",
        ["Proc_SelectRunning"] = "Aus der Liste der laufenden Anwendungen auswählen:",
        ["Proc_FilterWatermark"] = "Prozessfilter",
        ["Proc_ColProcess"] = "Prozess",
        ["Proc_ColProcessName"] = "Prozessname",
        ["Proc_ColWindowTitle"] = "Fenstertitel",
        ["Proc_ColFileName"] = "Dateiname",
        ["Proc_OrBrowse"] = "Oder geben Sie den Pfad zur ausführbaren Datei (.EXE) ein",
        ["Proc_Application"] = "Anwendung",
        ["Proc_SpecificWindow"] = "Bestimmtes Fenster",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Simulierte Tastatureingaben – {0}",
        ["Sk_EnterCustomKeys"] = "Benutzerdefinierte Taste(n) eingeben",
        ["Sk_MenuModifier"] = "Modifikatortasten",
        ["Sk_MenuStandard"] = "Standardtasten",
        ["Sk_MenuDirection"] = "Richtungstasten",
        ["Sk_MenuFunction"] = "Funktionstasten",
        ["Sk_MenuNumeric"] = "Nummerntastatur",
        ["Sk_MenuMedia"] = "Medientasten",
        ["Sk_MenuBrowser"] = "Browsertasten",
        ["Sk_MenuMouse"] = "Maustasten",
        ["Sk_HowToSend"] = "Art der simulierten Tastatureingaben:",
        ["Sk_Mode6Tip"] =
            "Modus 6 (Wiederholen bei gedrückter Maustaste) funktioniert nicht unter Linux.",
        ["Sk_BlockInput"] = "Originale Mauseingabe blockieren",
        ["Sk_BlockInputTip"] =
            "Den originalen Mausklick unterdrücken oder nicht.\nNur Windows und macOS.",
        ["Sk_AutoRepeatDelay"] = "Automatische Wiederholungsverzögerung",
        ["Sk_AutoRepeatDelayTip"] =
            "Die Verzögerung in Millisekunden vor dem Wiederholen. Standard ist 33.\nJe kleiner die Zahl, desto schneller die Wiederholung. Je größer die Zahl, desto langsamer.",
        ["Sk_RandomizeDelay"] = "Automatische Wiederholungsverzögerung zufällig variieren 0%-10%",
        ["Sk_DescriptionDropdown"] = "Beschreibung (in der Schaltflächen-Dropdown anzeigen)",
        ["Sk_CursorPosition"] = "Cursorposition: X,Y",

        // Global settings dialog
        ["Set_Title"] = "Globale Einstellungen",
        ["Set_StartMinimized"] = "Minimiert starten",
        ["Set_StartMenu"] = "Startmenü",
        ["Set_StartMenuTip"] =
            "YMouseButtonControl zum Startmenü hinzufügen.\nFür macOS deaktiviert.",
        ["Set_Logging"] = "Protokollierung",
        ["Set_LoggingTip"] =
            "Ob die Protokollierung in die Datei YMouseButtonControl.log erfolgt. Erfordert einen Neustart.",
        ["Set_Theme"] = "Design",
        ["Set_ThemeTip"] =
            "Das Anwendungsdesign. Erfordert einen Neustart.\nStandard: Betriebssystem-Design übernehmen. Funktioniert nicht unter Linux.\nHell: helles Design.\nDunkel: dunkles Design.",
        ["Set_Language"] = "Sprache",
        ["Set_LanguageTip"] = "Die Anwendungssprache. Erfordert einen Neustart.",
        ["Set_LanguageSystem"] = "Systemstandard",

        // Tray icon menu
        ["Tray_Setup"] = "Einrichten",
        ["Tray_RunAtStartup"] = "Beim Systemstart ausführen",
        ["Tray_Exit"] = "Beenden",
    };

    public static readonly IReadOnlyDictionary<string, string> Es = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Aplicar",
        ["Btn_Cancel"] = "Cancelar",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Cerrar",
        ["Btn_Copy"] = "Copiar",
        ["Btn_Add"] = "Agregar",
        ["Btn_Edit"] = "Editar",
        ["Btn_Remove"] = "Eliminar",
        ["Btn_Import"] = "Importar",
        ["Btn_Export"] = "Exportar",
        ["Btn_Up"] = "Arriba",
        ["Btn_Down"] = "Abajo",
        ["Btn_Refresh"] = "Actualizar",

        // Main window
        ["Main_AppWindowProfiles"] = "Perfiles de aplicación / ventana",
        ["Main_ProfileInformation"] = "Información del perfil",
        ["Main_Settings"] = "Configuración",
        ["Main_SaveProfile"] = "Guardar perfil",
        ["Main_LoadProfile"] = "Cargar perfil",

        // Profile information
        ["Info_Description"] = "Descripción",
        ["Info_WindowCaption"] = "Título de ventana",
        ["Info_Process"] = "Proceso",
        ["Info_WindowClass"] = "Clase de ventana",
        ["Info_ParentClass"] = "Clase principal",
        ["Info_MatchType"] = "Tipo de coincidencia",

        // Layer view
        ["Layer_Tab1"] = "Capa 1",
        ["Layer_Tab2"] = "Capa 2",
        ["Layer_TabScrolling"] = "Desplazamiento",
        ["Layer_TabOptions"] = "Opciones",
        ["Layer_Name"] = "Nombre de capa",
        ["Layer_1Default"] = "Capa 1 (Predeterminado)",
        ["Layer_Swap"] = "Intercambiar",
        ["Layer_Reset"] = "Restablecer",

        // Mouse button labels
        ["Mb_Left"] = "Botón izquierdo",
        ["Mb_Right"] = "Botón derecho",
        ["Mb_Middle"] = "Botón central",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Rueda arriba",
        ["Mb_WheelDown"] = "Rueda abajo",
        ["Mb_WheelLeft"] = "Rueda izquierda",
        ["Mb_WheelRight"] = "Rueda derecha",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Desactivado",
        ["Map_NoChange"] = "** Sin cambio (no interceptar) **",
        ["Map_SimulatedUndefined"] = "Teclas simuladas (sin definir)",
        ["Map_RightClick"] = "Clic derecho",
        ["Map_SimulatedKeysFmt"] = "Teclas simuladas: ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "Al presionar y soltar el botón del ratón",
        ["Skt_During"] = "Durante (presionar al bajar, soltar al subir)",
        ["Skt_ThreadPressed"] = "En otro hilo al presionar el botón del ratón",
        ["Skt_ThreadReleased"] = "En otro hilo al soltar el botón del ratón",
        ["Skt_AsPressed"] = "Al presionar el botón del ratón",
        ["Skt_AsReleased"] = "Al soltar el botón del ratón",
        ["Skt_Repeat"] = "Repetidamente mientras se mantiene el botón",
        ["Skt_StickyHold"] = "Fijo (mantenido hasta presionar el botón de nuevo)",
        ["Skt_StickyRepeat"] = "Fijo (repetir hasta presionar el botón de nuevo)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "presionado y soltado",
        ["SktShort_During"] = "durante",
        ["SktShort_ThreadPressed"] = "hilo-abajo",
        ["SktShort_ThreadReleased"] = "hilo-arriba",
        ["SktShort_AsPressed"] = "presionado",
        ["SktShort_AsReleased"] = "soltado",
        ["SktShort_Repeat"] = "repetir",
        ["SktShort_StickyHold"] = "fijo mantenido",
        ["SktShort_StickyRepeat"] = "fijo repetir",

        // Process selector dialog
        ["Proc_Title"] = "Elegir aplicación",
        ["Proc_SelectRunning"] = "Seleccione de la lista de aplicaciones en ejecución:",
        ["Proc_FilterWatermark"] = "Filtro de procesos",
        ["Proc_ColProcess"] = "Proceso",
        ["Proc_ColProcessName"] = "Nombre de proceso",
        ["Proc_ColWindowTitle"] = "Título de ventana",
        ["Proc_ColFileName"] = "Nombre de archivo",
        ["Proc_OrBrowse"] = "O escriba / busque el archivo ejecutable de la aplicación (.EXE)",
        ["Proc_Application"] = "Aplicación",
        ["Proc_SpecificWindow"] = "Ventana específica",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Teclas simuladas - {0}",
        ["Sk_EnterCustomKeys"] = "Introduzca la(s) tecla(s) personalizada(s)",
        ["Sk_MenuModifier"] = "Teclas modificadoras",
        ["Sk_MenuStandard"] = "Teclas estándar",
        ["Sk_MenuDirection"] = "Teclas de dirección",
        ["Sk_MenuFunction"] = "Teclas de función",
        ["Sk_MenuNumeric"] = "Teclado numérico",
        ["Sk_MenuMedia"] = "Teclas multimedia",
        ["Sk_MenuBrowser"] = "Teclas del navegador",
        ["Sk_MenuMouse"] = "Botones del ratón",
        ["Sk_HowToSend"] = "Cómo enviar las pulsaciones de teclas simuladas:",
        ["Sk_Mode6Tip"] = "El modo 6 (repetir mientras se mantiene el ratón) no funciona en Linux.",
        ["Sk_BlockInput"] = "Bloquear entrada original del ratón",
        ["Sk_BlockInputTip"] = "Suprimir o no el clic original del ratón.\nSolo Windows y macOS.",
        ["Sk_AutoRepeatDelay"] = "Retardo de repetición automática",
        ["Sk_AutoRepeatDelayTip"] =
            "El retardo en milisegundos antes de repetir. 33 es el valor predeterminado.\nCuanto menor sea el número, más rápida la repetición. Cuanto mayor sea el número, más lenta la repetición.",
        ["Sk_RandomizeDelay"] = "Aleatorizar retardo de repetición automática 0%-10%",
        ["Sk_DescriptionDropdown"] = "Descripción (para mostrar en el menú desplegable del botón)",
        ["Sk_CursorPosition"] = "Posición del cursor: X,Y",

        // Global settings dialog
        ["Set_Title"] = "Configuración global",
        ["Set_StartMinimized"] = "Iniciar minimizado",
        ["Set_StartMenu"] = "Menú de inicio",
        ["Set_StartMenuTip"] =
            "Agregar YMouseButtonControl al menú de inicio.\nDesactivado para macOS.",
        ["Set_Logging"] = "Registro",
        ["Set_LoggingTip"] =
            "Si se realiza o no el registro en el archivo YMouseButtonControl.log. Requiere reinicio.",
        ["Set_Theme"] = "Tema",
        ["Set_ThemeTip"] =
            "El tema de la aplicación. Requiere reinicio.\nPredeterminado: seguir el tema del SO. No funciona en Linux.\nClaro: tema claro.\nOscuro: tema oscuro.",
        ["Set_Language"] = "Idioma",
        ["Set_LanguageTip"] = "El idioma de la aplicación. Requiere reinicio.",
        ["Set_LanguageSystem"] = "Predeterminado del sistema",

        // Tray icon menu
        ["Tray_Setup"] = "Configurar",
        ["Tray_RunAtStartup"] = "Ejecutar al inicio",
        ["Tray_Exit"] = "Salir",
    };

    public static readonly IReadOnlyDictionary<string, string> Fr = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Appliquer",
        ["Btn_Cancel"] = "Annuler",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Fermer",
        ["Btn_Copy"] = "Copier",
        ["Btn_Add"] = "Ajouter",
        ["Btn_Edit"] = "Modifier",
        ["Btn_Remove"] = "Supprimer",
        ["Btn_Import"] = "Importer",
        ["Btn_Export"] = "Exporter",
        ["Btn_Up"] = "Haut",
        ["Btn_Down"] = "Bas",
        ["Btn_Refresh"] = "Actualiser",

        // Main window
        ["Main_AppWindowProfiles"] = "Profils d'application / fenêtre",
        ["Main_ProfileInformation"] = "Informations sur le profil",
        ["Main_Settings"] = "Paramètres",
        ["Main_SaveProfile"] = "Enregistrer le profil",
        ["Main_LoadProfile"] = "Charger le profil",

        // Profile information
        ["Info_Description"] = "Description",
        ["Info_WindowCaption"] = "Titre de la fenêtre",
        ["Info_Process"] = "Processus",
        ["Info_WindowClass"] = "Classe de fenêtre",
        ["Info_ParentClass"] = "Classe parente",
        ["Info_MatchType"] = "Type de correspondance",

        // Layer view
        ["Layer_Tab1"] = "Couche 1",
        ["Layer_Tab2"] = "Couche 2",
        ["Layer_TabScrolling"] = "Défilement",
        ["Layer_TabOptions"] = "Options",
        ["Layer_Name"] = "Nom de la couche",
        ["Layer_1Default"] = "Couche 1 (Par défaut)",
        ["Layer_Swap"] = "Permuter",
        ["Layer_Reset"] = "Réinitialiser",

        // Mouse button labels
        ["Mb_Left"] = "Bouton gauche",
        ["Mb_Right"] = "Bouton droit",
        ["Mb_Middle"] = "Bouton central",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Molette haut",
        ["Mb_WheelDown"] = "Molette bas",
        ["Mb_WheelLeft"] = "Molette gauche",
        ["Mb_WheelRight"] = "Molette droite",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Désactivé",
        ["Map_NoChange"] = "** Aucun changement (ne pas intercepter) **",
        ["Map_SimulatedUndefined"] = "Touches simulées (non définies)",
        ["Map_RightClick"] = "Clic droit",
        ["Map_SimulatedKeysFmt"] = "Touches simulées : ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "Lors de l'appui et du relâchement du bouton de la souris",
        ["Skt_During"] = "Pendant (appuyer à la descente, relâcher à la montée)",
        ["Skt_ThreadPressed"] = "Dans un autre fil lors de l'appui sur le bouton de la souris",
        ["Skt_ThreadReleased"] = "Dans un autre fil lors du relâchement du bouton de la souris",
        ["Skt_AsPressed"] = "Lors de l'appui sur le bouton de la souris",
        ["Skt_AsReleased"] = "Lors du relâchement du bouton de la souris",
        ["Skt_Repeat"] = "En répétition tant que le bouton est maintenu",
        ["Skt_StickyHold"] = "Verrouillé (maintenu jusqu'à nouvel appui sur le bouton)",
        ["Skt_StickyRepeat"] = "Verrouillé (en répétition jusqu'à nouvel appui sur le bouton)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "appuyé & relâché",
        ["SktShort_During"] = "pendant",
        ["SktShort_ThreadPressed"] = "fil-descente",
        ["SktShort_ThreadReleased"] = "fil-montée",
        ["SktShort_AsPressed"] = "appuyé",
        ["SktShort_AsReleased"] = "relâché",
        ["SktShort_Repeat"] = "répéter",
        ["SktShort_StickyHold"] = "verrouillé maintenu",
        ["SktShort_StickyRepeat"] = "verrouillé répété",

        // Process selector dialog
        ["Proc_Title"] = "Choisir une application",
        ["Proc_SelectRunning"] = "Sélectionner dans la liste des applications en cours :",
        ["Proc_FilterWatermark"] = "Filtre de processus",
        ["Proc_ColProcess"] = "Processus",
        ["Proc_ColProcessName"] = "Nom du processus",
        ["Proc_ColWindowTitle"] = "Titre de la fenêtre",
        ["Proc_ColFileName"] = "Nom du fichier",
        ["Proc_OrBrowse"] =
            "Ou saisissez / naviguez vers le fichier exécutable de l'application (.EXE)",
        ["Proc_Application"] = "Application",
        ["Proc_SpecificWindow"] = "Fenêtre spécifique",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Touches simulées - {0}",
        ["Sk_EnterCustomKeys"] = "Saisir la ou les touche(s) personnalisée(s)",
        ["Sk_MenuModifier"] = "Touches de modification",
        ["Sk_MenuStandard"] = "Touches standard",
        ["Sk_MenuDirection"] = "Touches directionnelles",
        ["Sk_MenuFunction"] = "Touches de fonction",
        ["Sk_MenuNumeric"] = "Pavé numérique",
        ["Sk_MenuMedia"] = "Touches multimédia",
        ["Sk_MenuBrowser"] = "Touches du navigateur",
        ["Sk_MenuMouse"] = "Boutons de la souris",
        ["Sk_HowToSend"] = "Comment envoyer les frappes simulées :",
        ["Sk_Mode6Tip"] =
            "Le mode 6 (répéter pendant que la souris est maintenue) ne fonctionne pas sous Linux.",
        ["Sk_BlockInput"] = "Bloquer l'entrée originale de la souris",
        ["Sk_BlockInputTip"] =
            "Supprimer ou non le clic d'origine de la souris.\nWindows et macOS uniquement.",
        ["Sk_AutoRepeatDelay"] = "Délai de répétition automatique",
        ["Sk_AutoRepeatDelayTip"] =
            "Le délai en millisecondes avant la répétition. 33 est la valeur par défaut.\nPlus le nombre est petit, plus la répétition est rapide. Plus le nombre est grand, plus elle est lente.",
        ["Sk_RandomizeDelay"] = "Randomiser le délai de répétition automatique 0%-10%",
        ["Sk_DescriptionDropdown"] = "Description (à afficher dans la liste déroulante du bouton)",
        ["Sk_CursorPosition"] = "Position du curseur : X,Y",

        // Global settings dialog
        ["Set_Title"] = "Paramètres globaux",
        ["Set_StartMinimized"] = "Démarrer réduit",
        ["Set_StartMenu"] = "Menu Démarrer",
        ["Set_StartMenuTip"] =
            "Ajouter YMouseButtonControl au menu Démarrer.\nDésactivé pour macOS.",
        ["Set_Logging"] = "Journalisation",
        ["Set_LoggingTip"] =
            "Si la journalisation dans le fichier YMouseButtonControl.log est effectuée ou non. Nécessite un redémarrage.",
        ["Set_Theme"] = "Thème",
        ["Set_ThemeTip"] =
            "Le thème de l'application. Nécessite un redémarrage.\nPar défaut : suivre le thème du système d'exploitation. Ne fonctionne pas sous Linux.\nClair : thème clair.\nSombre : thème sombre.",
        ["Set_Language"] = "Langue",
        ["Set_LanguageTip"] = "La langue de l'application. Nécessite un redémarrage.",
        ["Set_LanguageSystem"] = "Langue système par défaut",

        // Tray icon menu
        ["Tray_Setup"] = "Configuration",
        ["Tray_RunAtStartup"] = "Lancer au démarrage",
        ["Tray_Exit"] = "Quitter",
    };

    public static readonly IReadOnlyDictionary<string, string> Uk = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Застосувати",
        ["Btn_Cancel"] = "Скасувати",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Закрити",
        ["Btn_Copy"] = "Копіювати",
        ["Btn_Add"] = "Додати",
        ["Btn_Edit"] = "Змінити",
        ["Btn_Remove"] = "Видалити",
        ["Btn_Import"] = "Імпорт",
        ["Btn_Export"] = "Експорт",
        ["Btn_Up"] = "Вгору",
        ["Btn_Down"] = "Вниз",
        ["Btn_Refresh"] = "Оновити",

        // Main window
        ["Main_AppWindowProfiles"] = "Профілі застосунків / вікон",
        ["Main_ProfileInformation"] = "Інформація про профіль",
        ["Main_Settings"] = "Налаштування",
        ["Main_SaveProfile"] = "Зберегти профіль",
        ["Main_LoadProfile"] = "Завантажити профіль",

        // Profile information
        ["Info_Description"] = "Опис",
        ["Info_WindowCaption"] = "Заголовок вікна",
        ["Info_Process"] = "Процес",
        ["Info_WindowClass"] = "Клас вікна",
        ["Info_ParentClass"] = "Батьківський клас",
        ["Info_MatchType"] = "Тип збігу",

        // Layer view
        ["Layer_Tab1"] = "Шар 1",
        ["Layer_Tab2"] = "Шар 2",
        ["Layer_TabScrolling"] = "Прокручування",
        ["Layer_TabOptions"] = "Параметри",
        ["Layer_Name"] = "Назва шару",
        ["Layer_1Default"] = "Шар 1 (Типовий)",
        ["Layer_Swap"] = "Поміняти",
        ["Layer_Reset"] = "Скинути",

        // Mouse button labels
        ["Mb_Left"] = "Ліва кнопка",
        ["Mb_Right"] = "Права кнопка",
        ["Mb_Middle"] = "Середня кнопка",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Коліщатко вгору",
        ["Mb_WheelDown"] = "Коліщатко вниз",
        ["Mb_WheelLeft"] = "Коліщатко вліво",
        ["Mb_WheelRight"] = "Коліщатко вправо",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Вимкнено",
        ["Map_NoChange"] = "** Без змін (не перехоплювати) **",
        ["Map_SimulatedUndefined"] = "Симульовані клавіші (не визначено)",
        ["Map_RightClick"] = "Правий клік",
        ["Map_SimulatedKeysFmt"] = "Симульовані клавіші: ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "Під час натискання та відпускання кнопки миші",
        ["Skt_During"] = "Протягом (натиснути при натисканні, відпустити при відпусканні)",
        ["Skt_ThreadPressed"] = "В окремому потоці при натисканні кнопки миші",
        ["Skt_ThreadReleased"] = "В окремому потоці при відпусканні кнопки миші",
        ["Skt_AsPressed"] = "Під час натискання кнопки миші",
        ["Skt_AsReleased"] = "Під час відпускання кнопки миші",
        ["Skt_Repeat"] = "Повторювати, поки кнопка утримується",
        ["Skt_StickyHold"] = "Залипання (утримується до повторного натискання кнопки)",
        ["Skt_StickyRepeat"] = "Залипання (повторюється до повторного натискання кнопки)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "натиснуто й відпущено",
        ["SktShort_During"] = "протягом",
        ["SktShort_ThreadPressed"] = "потік-натискання",
        ["SktShort_ThreadReleased"] = "потік-відпускання",
        ["SktShort_AsPressed"] = "натиснуто",
        ["SktShort_AsReleased"] = "відпущено",
        ["SktShort_Repeat"] = "повтор",
        ["SktShort_StickyHold"] = "залипання-утримання",
        ["SktShort_StickyRepeat"] = "залипання-повтор",

        // Process selector dialog
        ["Proc_Title"] = "Вибір застосунку",
        ["Proc_SelectRunning"] = "Виберіть зі списку запущених застосунків:",
        ["Proc_FilterWatermark"] = "Фільтр процесів",
        ["Proc_ColProcess"] = "Процес",
        ["Proc_ColProcessName"] = "Назва процесу",
        ["Proc_ColWindowTitle"] = "Заголовок вікна",
        ["Proc_ColFileName"] = "Назва файлу",
        ["Proc_OrBrowse"] = "Або введіть / вкажіть шлях до виконуваного файлу застосунку (.EXE)",
        ["Proc_Application"] = "Застосунок",
        ["Proc_SpecificWindow"] = "Конкретне вікно",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Симульовані натискання клавіш — {0}",
        ["Sk_EnterCustomKeys"] = "Введіть власну клавішу (або клавіші)",
        ["Sk_MenuModifier"] = "Клавіші-модифікатори",
        ["Sk_MenuStandard"] = "Стандартні клавіші",
        ["Sk_MenuDirection"] = "Клавіші напрямку",
        ["Sk_MenuFunction"] = "Функціональні клавіші",
        ["Sk_MenuNumeric"] = "Цифрова клавіатура",
        ["Sk_MenuMedia"] = "Мультимедійні клавіші",
        ["Sk_MenuBrowser"] = "Клавіші браузера",
        ["Sk_MenuMouse"] = "Кнопки миші",
        ["Sk_HowToSend"] = "Спосіб надсилання симульованих натискань клавіш:",
        ["Sk_Mode6Tip"] = "Режим 6 (повтор при утриманні миші) не працює в Linux.",
        ["Sk_BlockInput"] = "Блокувати початкове введення миші",
        ["Sk_BlockInputTip"] = "Пригнічувати чи ні початковий клік миші.\nЛише Windows і macOS.",
        ["Sk_AutoRepeatDelay"] = "Затримка автоповтору",
        ["Sk_AutoRepeatDelayTip"] =
            "Затримка в мілісекундах перед повтором. Типово 33.\nЩо менше значення, то швидший повтор. Що більше значення, то повільніший повтор.",
        ["Sk_RandomizeDelay"] = "Випадкова затримка автоповтору 0%-10%",
        ["Sk_DescriptionDropdown"] = "Опис (для показу у випадному списку кнопки)",
        ["Sk_CursorPosition"] = "Положення курсора: X,Y",

        // Global settings dialog
        ["Set_Title"] = "Глобальні налаштування",
        ["Set_StartMinimized"] = "Запускати згорнутим",
        ["Set_StartMenu"] = "Меню Пуск",
        ["Set_StartMenuTip"] = "Додати YMouseButtonControl до меню Пуск.\nВимкнено для macOS.",
        ["Set_Logging"] = "Ведення журналу",
        ["Set_LoggingTip"] =
            "Чи вести журнал у файл YMouseButtonControl.log. Потребує перезапуску.",
        ["Set_Theme"] = "Тема",
        ["Set_ThemeTip"] =
            "Тема застосунку. Потребує перезапуску.\nТипово: слідувати темі ОС. Не працює в Linux.\nСвітла: світла тема.\nТемна: темна тема.",
        ["Set_Language"] = "Мова",
        ["Set_LanguageTip"] = "Мова застосунку. Потребує перезапуску.",
        ["Set_LanguageSystem"] = "Системна мова за замовчуванням",

        // Tray icon menu
        ["Tray_Setup"] = "Налаштування",
        ["Tray_RunAtStartup"] = "Запускати під час входу в систему",
        ["Tray_Exit"] = "Вихід",
    };

    public static readonly IReadOnlyDictionary<string, string> Pt = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "Aplicar",
        ["Btn_Cancel"] = "Cancelar",
        ["Btn_Ok"] = "OK",
        ["Btn_Close"] = "Fechar",
        ["Btn_Copy"] = "Copiar",
        ["Btn_Add"] = "Adicionar",
        ["Btn_Edit"] = "Editar",
        ["Btn_Remove"] = "Remover",
        ["Btn_Import"] = "Importar",
        ["Btn_Export"] = "Exportar",
        ["Btn_Up"] = "Acima",
        ["Btn_Down"] = "Abaixo",
        ["Btn_Refresh"] = "Atualizar",

        // Main window
        ["Main_AppWindowProfiles"] = "Perfis de aplicativo / janela",
        ["Main_ProfileInformation"] = "Informações do perfil",
        ["Main_Settings"] = "Configurações",
        ["Main_SaveProfile"] = "Salvar perfil",
        ["Main_LoadProfile"] = "Carregar perfil",

        // Profile information
        ["Info_Description"] = "Descrição",
        ["Info_WindowCaption"] = "Título da janela",
        ["Info_Process"] = "Processo",
        ["Info_WindowClass"] = "Classe da janela",
        ["Info_ParentClass"] = "Classe pai",
        ["Info_MatchType"] = "Tipo de correspondência",

        // Layer view
        ["Layer_Tab1"] = "Camada 1",
        ["Layer_Tab2"] = "Camada 2",
        ["Layer_TabScrolling"] = "Rolagem",
        ["Layer_TabOptions"] = "Opções",
        ["Layer_Name"] = "Nome da camada",
        ["Layer_1Default"] = "Camada 1 (Padrão)",
        ["Layer_Swap"] = "Trocar",
        ["Layer_Reset"] = "Redefinir",

        // Mouse button labels
        ["Mb_Left"] = "Botão esquerdo",
        ["Mb_Right"] = "Botão direito",
        ["Mb_Middle"] = "Botão do meio",
        ["Mb_Button4"] = "Mouse Button 4",
        ["Mb_Button5"] = "Mouse Button 5",
        ["Mb_WheelUp"] = "Roda para cima",
        ["Mb_WheelDown"] = "Roda para baixo",
        ["Mb_WheelLeft"] = "Roda para a esquerda",
        ["Mb_WheelRight"] = "Roda para a direita",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "Desativado",
        ["Map_NoChange"] = "** Sem alteração (não interceptar) **",
        ["Map_SimulatedUndefined"] = "Teclas simuladas (indefinido)",
        ["Map_RightClick"] = "Clique direito",
        ["Map_SimulatedKeysFmt"] = "Teclas simuladas: ({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "Ao pressionar e soltar o botão do mouse",
        ["Skt_During"] = "Durante (pressionar ao descer, soltar ao subir)",
        ["Skt_ThreadPressed"] = "Em outra thread ao pressionar o botão do mouse",
        ["Skt_ThreadReleased"] = "Em outra thread ao soltar o botão do mouse",
        ["Skt_AsPressed"] = "Ao pressionar o botão do mouse",
        ["Skt_AsReleased"] = "Ao soltar o botão do mouse",
        ["Skt_Repeat"] = "Repetidamente enquanto o botão estiver pressionado",
        ["Skt_StickyHold"] = "Fixo (mantido até pressionar o botão novamente)",
        ["Skt_StickyRepeat"] = "Fixo (repetindo até pressionar o botão novamente)",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "pressionado e solto",
        ["SktShort_During"] = "durante",
        ["SktShort_ThreadPressed"] = "thread-descer",
        ["SktShort_ThreadReleased"] = "thread-subir",
        ["SktShort_AsPressed"] = "pressionado",
        ["SktShort_AsReleased"] = "solto",
        ["SktShort_Repeat"] = "repetir",
        ["SktShort_StickyHold"] = "fixo mantido",
        ["SktShort_StickyRepeat"] = "fixo repetido",

        // Process selector dialog
        ["Proc_Title"] = "Escolher aplicativo",
        ["Proc_SelectRunning"] = "Selecione na lista de aplicativos em execução:",
        ["Proc_FilterWatermark"] = "Filtro de processos",
        ["Proc_ColProcess"] = "Processo",
        ["Proc_ColProcessName"] = "Nome do processo",
        ["Proc_ColWindowTitle"] = "Título da janela",
        ["Proc_ColFileName"] = "Nome do arquivo",
        ["Proc_OrBrowse"] = "Ou digite / procure o arquivo executável do aplicativo (.EXE)",
        ["Proc_Application"] = "Aplicativo",
        ["Proc_SpecificWindow"] = "Janela específica",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "Teclas simuladas - {0}",
        ["Sk_EnterCustomKeys"] = "Digite a(s) tecla(s) personalizada(s)",
        ["Sk_MenuModifier"] = "Teclas modificadoras",
        ["Sk_MenuStandard"] = "Teclas padrão",
        ["Sk_MenuDirection"] = "Teclas de direção",
        ["Sk_MenuFunction"] = "Teclas de função",
        ["Sk_MenuNumeric"] = "Teclado numérico",
        ["Sk_MenuMedia"] = "Teclas de mídia",
        ["Sk_MenuBrowser"] = "Teclas do navegador",
        ["Sk_MenuMouse"] = "Botões do mouse",
        ["Sk_HowToSend"] = "Como enviar as teclas simuladas:",
        ["Sk_Mode6Tip"] =
            "O modo 6 (repetir enquanto o mouse estiver pressionado) não funciona no Linux.",
        ["Sk_BlockInput"] = "Bloquear entrada original do mouse",
        ["Sk_BlockInputTip"] =
            "Suprimir ou não o clique original do mouse.\nSomente Windows e macOS.",
        ["Sk_AutoRepeatDelay"] = "Atraso de repetição automática",
        ["Sk_AutoRepeatDelayTip"] =
            "O atraso em milissegundos antes de repetir. 33 é o padrão.\nQuanto menor o número, mais rápida a repetição. Quanto maior o número, mais lenta a repetição.",
        ["Sk_RandomizeDelay"] = "Aleatorizar atraso de repetição automática 0%-10%",
        ["Sk_DescriptionDropdown"] = "Descrição (para exibir na lista suspensa do botão)",
        ["Sk_CursorPosition"] = "Posição do cursor: X,Y",

        // Global settings dialog
        ["Set_Title"] = "Configurações globais",
        ["Set_StartMinimized"] = "Iniciar minimizado",
        ["Set_StartMenu"] = "Menu Iniciar",
        ["Set_StartMenuTip"] =
            "Adicionar YMouseButtonControl ao menu Iniciar.\nDesativado para macOS.",
        ["Set_Logging"] = "Registro em log",
        ["Set_LoggingTip"] =
            "Se o registro no arquivo YMouseButtonControl.log é realizado ou não. Requer reinicialização.",
        ["Set_Theme"] = "Tema",
        ["Set_ThemeTip"] =
            "O tema do aplicativo. Requer reinicialização.\nPadrão: seguir o tema do SO. Não funciona no Linux.\nClaro: tema claro.\nEscuro: tema escuro.",
        ["Set_Language"] = "Idioma",
        ["Set_LanguageTip"] = "O idioma do aplicativo. Requer reinicialização.",
        ["Set_LanguageSystem"] = "Padrão do sistema",

        // Tray icon menu
        ["Tray_Setup"] = "Configurar",
        ["Tray_RunAtStartup"] = "Executar na inicialização",
        ["Tray_Exit"] = "Sair",
    };

    public static readonly IReadOnlyDictionary<string, string> Zh = new Dictionary<string, string>
    {
        // Shared / buttons
        ["Btn_Apply"] = "应用",
        ["Btn_Cancel"] = "取消",
        ["Btn_Ok"] = "确定",
        ["Btn_Close"] = "关闭",
        ["Btn_Copy"] = "复制",
        ["Btn_Add"] = "添加",
        ["Btn_Edit"] = "编辑",
        ["Btn_Remove"] = "删除",
        ["Btn_Import"] = "导入",
        ["Btn_Export"] = "导出",
        ["Btn_Up"] = "上移",
        ["Btn_Down"] = "下移",
        ["Btn_Refresh"] = "刷新",

        // Main window
        ["Main_AppWindowProfiles"] = "应用程序 / 窗口配置文件",
        ["Main_ProfileInformation"] = "配置文件信息",
        ["Main_Settings"] = "设置",
        ["Main_SaveProfile"] = "保存配置文件",
        ["Main_LoadProfile"] = "加载配置文件",

        // Profile information
        ["Info_Description"] = "描述",
        ["Info_WindowCaption"] = "窗口标题",
        ["Info_Process"] = "进程",
        ["Info_WindowClass"] = "窗口类",
        ["Info_ParentClass"] = "父类",
        ["Info_MatchType"] = "匹配类型",

        // Layer view
        ["Layer_Tab1"] = "层 1",
        ["Layer_Tab2"] = "层 2",
        ["Layer_TabScrolling"] = "滚动",
        ["Layer_TabOptions"] = "选项",
        ["Layer_Name"] = "层名称",
        ["Layer_1Default"] = "层 1（默认）",
        ["Layer_Swap"] = "交换",
        ["Layer_Reset"] = "重置",

        // Mouse button labels
        ["Mb_Left"] = "左键",
        ["Mb_Right"] = "右键",
        ["Mb_Middle"] = "中键",
        ["Mb_Button4"] = "鼠标按键 4",
        ["Mb_Button5"] = "鼠标按键 5",
        ["Mb_WheelUp"] = "滚轮向上",
        ["Mb_WheelDown"] = "滚轮向下",
        ["Mb_WheelLeft"] = "滚轮向左",
        ["Mb_WheelRight"] = "滚轮向右",

        // Button-mapping dropdown entries
        ["Map_Disabled"] = "已禁用",
        ["Map_NoChange"] = "** 不更改（不拦截）**",
        ["Map_SimulatedUndefined"] = "模拟按键（未定义）",
        ["Map_RightClick"] = "右键单击",
        ["Map_SimulatedKeysFmt"] = "模拟按键：({0})",

        // Simulated keystroke action types (long descriptions)
        ["Skt_AsPressedReleased"] = "按下并释放鼠标按键时",
        ["Skt_During"] = "期间（按下时按下，释放时释放）",
        ["Skt_ThreadPressed"] = "按下鼠标按键时在另一线程中",
        ["Skt_ThreadReleased"] = "释放鼠标按键时在另一线程中",
        ["Skt_AsPressed"] = "按下鼠标按键时",
        ["Skt_AsReleased"] = "释放鼠标按键时",
        ["Skt_Repeat"] = "按住按键期间重复",
        ["Skt_StickyHold"] = "粘滞（按住直到再次按下按键）",
        ["Skt_StickyRepeat"] = "粘滞（重复直到再次按下按键）",

        // Simulated keystroke action types (short descriptions)
        ["SktShort_AsPressedReleased"] = "按下并释放",
        ["SktShort_During"] = "期间",
        ["SktShort_ThreadPressed"] = "线程-按下",
        ["SktShort_ThreadReleased"] = "线程-释放",
        ["SktShort_AsPressed"] = "按下",
        ["SktShort_AsReleased"] = "释放",
        ["SktShort_Repeat"] = "重复",
        ["SktShort_StickyHold"] = "粘滞按住",
        ["SktShort_StickyRepeat"] = "粘滞重复",

        // Process selector dialog
        ["Proc_Title"] = "选择应用程序",
        ["Proc_SelectRunning"] = "从正在运行的应用程序列表中选择：",
        ["Proc_FilterWatermark"] = "进程筛选",
        ["Proc_ColProcess"] = "进程",
        ["Proc_ColProcessName"] = "进程名称",
        ["Proc_ColWindowTitle"] = "窗口标题",
        ["Proc_ColFileName"] = "文件名",
        ["Proc_OrBrowse"] = "或输入 / 浏览应用程序可执行文件 (.EXE)",
        ["Proc_Application"] = "应用程序",
        ["Proc_SpecificWindow"] = "特定窗口",

        // Simulated keystrokes dialog
        ["Sk_TitleFmt"] = "模拟按键 - {0}",
        ["Sk_EnterCustomKeys"] = "输入自定义按键",
        ["Sk_MenuModifier"] = "修饰键",
        ["Sk_MenuStandard"] = "标准键",
        ["Sk_MenuDirection"] = "方向键",
        ["Sk_MenuFunction"] = "功能键",
        ["Sk_MenuNumeric"] = "数字小键盘",
        ["Sk_MenuMedia"] = "媒体键",
        ["Sk_MenuBrowser"] = "浏览器键",
        ["Sk_MenuMouse"] = "鼠标按键",
        ["Sk_HowToSend"] = "如何发送模拟按键：",
        ["Sk_Mode6Tip"] = "模式 6（按住鼠标时重复）在 Linux 上不起作用。",
        ["Sk_BlockInput"] = "阻止原始鼠标输入",
        ["Sk_BlockInputTip"] = "是否抑制原始鼠标点击。\n仅限 Windows 和 macOS。",
        ["Sk_AutoRepeatDelay"] = "自动重复延迟",
        ["Sk_AutoRepeatDelayTip"] =
            "重复前的延迟（毫秒）。默认为 33。\n数值越小，重复越快；数值越大，重复越慢。",
        ["Sk_RandomizeDelay"] = "随机化自动重复延迟 0%-10%",
        ["Sk_DescriptionDropdown"] = "描述（显示在按键下拉列表中）",
        ["Sk_CursorPosition"] = "光标位置：X,Y",

        // Global settings dialog
        ["Set_Title"] = "全局设置",
        ["Set_StartMinimized"] = "启动时最小化",
        ["Set_StartMenu"] = "开始菜单",
        ["Set_StartMenuTip"] = "将 YMouseButtonControl 添加到开始菜单。\n在 macOS 上禁用。",
        ["Set_Logging"] = "日志记录",
        ["Set_LoggingTip"] = "是否将日志记录到 YMouseButtonControl.log 文件。需要重启。",
        ["Set_Theme"] = "主题",
        ["Set_ThemeTip"] =
            "应用程序主题。需要重启。\n默认：跟随操作系统主题。在 Linux 上不起作用。\n浅色：浅色主题。\n深色：深色主题。",
        ["Set_Language"] = "语言",
        ["Set_LanguageTip"] = "应用程序语言。需要重启。",
        ["Set_LanguageSystem"] = "系统默认",

        // Tray icon menu
        ["Tray_Setup"] = "设置",
        ["Tray_RunAtStartup"] = "开机启动",
        ["Tray_Exit"] = "退出",
    };
}
