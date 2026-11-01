package PersonalLibraryDomain {
    import ScalarValues::*;

    part def Book {
        attribute id : String;
        attribute title : String;
        attribute author : String;
        attribute genre : String;
        attribute publicationYear : Integer;
        attribute isbn : String;
        attribute totalPages : Integer;
    }

    part def ReadingProgress {
        attribute currentPage : Integer;
        attribute status : String;
        attribute updatedAt : String;
    }

    // Для каждой книги хранится не более одной записи прогресса.
    // Ограничение: 0 <= currentPage <= totalPages; totalPages > 0.
}
