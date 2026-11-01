package PersonalLibraryQualityRequirements {
    import ScalarValues::*;

    part def PersonalLibrary;

    requirement def QualityRequirement {
        attribute metric : String;
        subject system : PersonalLibrary;
    }

    requirement <'REQ-PERF-001'> searchResponse : QualityRequirement {
        doc /* Поиск по каталогу до 5000 записей выполняется не более чем за 2 секунды. */
        attribute :>> metric = "95% of searches <= 2 s for 5000 records";
    }

    requirement <'REQ-REL-002'> localDataPersistence : QualityRequirement {
        doc /* Подтверждённые записи доступны после перезапуска приложения. */
        attribute :>> metric = "All confirmed records persist across restart";
    }
}
