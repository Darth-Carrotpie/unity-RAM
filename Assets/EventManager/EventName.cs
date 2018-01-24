public enum EventName {
    None,

    StructureSelected,
    StructureDeselected,
    ZoneSelected,
    CommandAssignedToStructure,
    CommandImpactChange,

    TurnEvent,
    AddBooker,

    VilniusNorthUpdateEvent,
    VilniusSouthUpdateEvent,
    SuvalkaiUpdateEvent,
    KaunasWestUpdateEvent,
    KaunasEastUpdateEvent,
    GlobalUpdateEvent,

    NeighborhoodVilniusNorth,
    NeighborhoodVilniusSouth,
    NeighborhoodKaunasEast,
    NeighborhoodKaunasWest,
    NeighborhoodSuvalkai,

    BorderKaunas,
    BorderVilnius,
    BorderSuvalkaiVilnius,
    BorderSuvalkaiKaunasWest,
    BorderSuvalkaiKaunasEast,
    BorderKaunasVilniusNorth,
    BorderKaunasVilniusSouth,

    SuperVictory,
    NormalVictory,
    Defeat,

    GameSpeedEvent,
    PauseGameEvent,
    UnpauseGameEvent,

    BookerSelected,
    BookerDeselected,
    BookerAssignedToStructure,

    BookerStory,
    StructureStory,
    GendarmeActivityStory,

    ShowInfoDetails,
    LanguageChanged,
    InsufficientFunds,
    NoSmugglingPoint,

    BookerDeassignedFromStructure,
    RoadBuildingEvent
}