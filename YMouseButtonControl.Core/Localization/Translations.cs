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
        ["Sk_Mode6Tip"] = "Modus 6 (Wiederholen bei gedrückter Maustaste) funktioniert nicht unter Linux.",
        ["Sk_BlockInput"] = "Originale Mauseingabe blockieren",
        ["Sk_BlockInputTip"] = "Den originalen Mausklick unterdrücken oder nicht.\nNur Windows und macOS.",
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
        ["Set_StartMenuTip"] = "YMouseButtonControl zum Startmenü hinzufügen.\nFür macOS deaktiviert.",
        ["Set_Logging"] = "Protokollierung",
        ["Set_LoggingTip"] =
            "Ob die Protokollierung in die Datei YMouseButtonControl.log erfolgt. Erfordert einen Neustart.",
        ["Set_Theme"] = "Design",
        ["Set_ThemeTip"] =
            "Das Anwendungsdesign. Erfordert einen Neustart.\nStandard: Betriebssystem-Design übernehmen. Funktioniert nicht unter Linux.\nHell: helles Design.\nDunkel: dunkles Design.",
        ["Set_Language"] = "Sprache",
        ["Set_LanguageTip"] = "Die Anwendungssprache. Erfordert einen Neustart.",
        ["Set_LanguageSystem"] = "Systemstandard",
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
        ["Set_StartMenuTip"] = "Agregar YMouseButtonControl al menú de inicio.\nDesactivado para macOS.",
        ["Set_Logging"] = "Registro",
        ["Set_LoggingTip"] =
            "Si se realiza o no el registro en el archivo YMouseButtonControl.log. Requiere reinicio.",
        ["Set_Theme"] = "Tema",
        ["Set_ThemeTip"] =
            "El tema de la aplicación. Requiere reinicio.\nPredeterminado: seguir el tema del SO. No funciona en Linux.\nClaro: tema claro.\nOscuro: tema oscuro.",
        ["Set_Language"] = "Idioma",
        ["Set_LanguageTip"] = "El idioma de la aplicación. Requiere reinicio.",
        ["Set_LanguageSystem"] = "Predeterminado del sistema",
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
        ["Proc_OrBrowse"] = "Ou saisissez / naviguez vers le fichier exécutable de l'application (.EXE)",
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
        ["Sk_Mode6Tip"] = "Le mode 6 (répéter pendant que la souris est maintenue) ne fonctionne pas sous Linux.",
        ["Sk_BlockInput"] = "Bloquer l'entrée originale de la souris",
        ["Sk_BlockInputTip"] = "Supprimer ou non le clic d'origine de la souris.\nWindows et macOS uniquement.",
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
        ["Set_StartMenuTip"] = "Ajouter YMouseButtonControl au menu Démarrer.\nDésactivé pour macOS.",
        ["Set_Logging"] = "Journalisation",
        ["Set_LoggingTip"] =
            "Si la journalisation dans le fichier YMouseButtonControl.log est effectuée ou non. Nécessite un redémarrage.",
        ["Set_Theme"] = "Thème",
        ["Set_ThemeTip"] =
            "Le thème de l'application. Nécessite un redémarrage.\nPar défaut : suivre le thème du système d'exploitation. Ne fonctionne pas sous Linux.\nClair : thème clair.\nSombre : thème sombre.",
        ["Set_Language"] = "Langue",
        ["Set_LanguageTip"] = "La langue de l'application. Nécessite un redémarrage.",
        ["Set_LanguageSystem"] = "Langue système par défaut",
    };
}
