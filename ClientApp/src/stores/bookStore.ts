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

  async function fetchBooks() {
    const response = await fetch("/api/Book");
    const data = (await response.json()) as IBook[];
    data.sort((a, b) => a.bookId - b.bookId);

    return { data: data, hId: data[data.length - 1].bookId };
  }

  return {
    getBooks,
    initBooksStore,
    addBook,
    removeBook,
    fetchBooks,
  };
});

export default useBookStore;
