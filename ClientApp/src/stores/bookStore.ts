import { defineStore } from "pinia";
import { Ref, computed, ref } from "vue";
import IBook from "../modules/Interfaces/IBook";

const useBookStore = defineStore("books", () => {
  const books: Ref<IBook[]> = ref([]);
  const lastId: Ref<number> = ref(0);

  const getBooks = computed(() => books.value);
  const initBooksStore = computed(async () => {
    const { data, hId } = await fetchBooks();
    books.value = data;
    lastId.value = hId;
  });

  function addBook(book: IBook) {
    if (book.title.length > 0 && book.author.length > 0) {
      book.bookId = ++lastId.value;
      books.value.push(book);
    } else {
      return;
    }
  }

  function removeBook(bookId: number) {
    books.value = books.value.filter((book: IBook) => book.bookId !== bookId);
  }

  function updateBook(book: IBook) {
    books.value = books.value.map((oldBook: IBook) =>
      oldBook.bookId === book.bookId ? book : oldBook,
    );
  }

  async function fetchBooks() {
    const response = await fetch("/api/Book");
    const data = (await response.json()) as IBook[];

    if (data.length <= 0) {
      return { data: [], hId: 0 };
    }

    data.sort((a, b) => a.bookId - b.bookId);

    return { data: data, hId: data[data.length - 1].bookId };
  }

  async function syncChanges() {
    const oldData = (await fetchBooks()).data;
    const newBooks = books.value.filter(
      (book: IBook) => !isBookInArray(book.bookId, oldData),
    );
    const deletedBooks = oldData.filter(
      (book: IBook) => !isBookInArray(book.bookId, books.value),
    );

    newBooks.forEach(async (book) => {
      await fetch("api/Book/newBook", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(book),
      });
    });

    deletedBooks.forEach(async (book) => {
      await fetch(`api/Book/deleteBook/${book.bookId}`, {
        method: "DELETE",
      });
    });
  }

  const isBookInArray = (bookId: number, arr: IBook[]): boolean => {
    return arr.some((book: IBook) => book.bookId === bookId);
  };

  return {
    getBooks,
    initBooksStore,
    addBook,
    removeBook,
    updateBook,
    fetchBooks,
    syncChanges,
  };
});

export default useBookStore;
