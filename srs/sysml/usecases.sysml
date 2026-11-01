package PersonalLibraryUseCases {
    part def Reader;

    part def PersonalLibrary {
        part catalog;
        part search;
        part readingProgress;
    }

    // Цели читателя: просматривать каталог; добавлять и изменять книгу;
    // искать, фильтровать и сортировать записи; сохранять место чтения.
}
