package PersonalLibraryRequirements {
    doc /* Требования к настольному приложению BookShelf.
        Учебный вариант 0.2: каталог и прогресс чтения. */
    import ScalarValues::*;

    part def Reader;
    part def PersonalLibrary {
        part catalogModule;
        part searchModule;
        part progressModule;
        part localStorage;
    }

    requirement def FunctionalRequirement {
        attribute priority : String; // Must | Should | Could
        subject system : PersonalLibrary;
    }
    requirement def QualityRequirement {
        attribute metric : String;
        subject system : PersonalLibrary;
    }

    requirement bookShelfSpec {
        doc /* Каталог, поиск, сортировка и учёт прогресса. */
        requirement catalog {
            requirement <'REQ-FUNC-001'> addBook : FunctionalRequirement {
                doc /* Добавление записи книги. */
                attribute :>> priority = "Must";
            }
            requirement <'REQ-FUNC-002'> editBook : FunctionalRequirement {
                doc /* Изменение сведений о книге. */
                attribute :>> priority = "Must";
            }
        }
        requirement searchAndSort {
            requirement <'REQ-FUNC-006'> searchBooks : FunctionalRequirement {
                doc /* Поиск по названию и автору. */
                attribute :>> priority = "Must";
            }
            requirement <'REQ-FUNC-010'> sortBooks : FunctionalRequirement {
                doc /* Сортировка по выбранному полю. */
                attribute :>> priority = "Must";
            }
        }
        requirement readingProgress {
            requirement <'REQ-FUNC-014'> updateProgress : FunctionalRequirement {
                doc /* Текущая страница и расчёт процента. */
                attribute :>> priority = "Must";
            }
        }
    }
}
