package PersonalLibraryFunctionalRequirements {
    import ScalarValues::*;

    part def PersonalLibrary;

    requirement def FunctionalRequirement {
        attribute priority : String;
        subject system : PersonalLibrary;
    }

    requirement catalogAndSearch {
        requirement <'REQ-FUNC-001'> addBook : FunctionalRequirement {
            doc /* Добавление записи книги с обязательными полями. */
            attribute :>> priority = "Must";
        }
        requirement <'REQ-FUNC-006'> searchBooks : FunctionalRequirement {
            doc /* Поиск по названию или автору. */
            attribute :>> priority = "Must";
        }
        requirement <'REQ-FUNC-010'> sortBooks : FunctionalRequirement {
            doc /* Сортировка каталога по выбранному полю. */
            attribute :>> priority = "Must";
        }
    }

    requirement readingProgress {
        requirement <'REQ-FUNC-014'> updateProgress : FunctionalRequirement {
            doc /* Сохранение текущей страницы книги. */
            attribute :>> priority = "Must";
        }
    }
}
