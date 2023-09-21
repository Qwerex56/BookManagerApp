<script setup lang="ts">
import useBookStore from "./stores/bookStore";
import IBook from "./modules/Interfaces/IBook";
import { onMounted, ref } from "vue";

const bookStore = useBookStore();

const book = ref<IBook>({
  bookId: 0,
  title: "",
  author: "",
  year: 0,
});

onMounted(async () => {
  await bookStore.initBooksStore;
});

const update = async () => {
  await fetch("api/Book/newBook/", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      title: book.value.title,
      author: book.value.author,
      year: book.value.year,
    }),
  }).catch((err) => alert(err.message));
};
</script>

<template>
  <button @click="update">Update</button>
  <ul class="flex flex-col gap-0.5 w-4/5">
    <div
      class="grid grid-cols-4 grid-rows-1 bg-slate-200 content-center text-center"
    >
      <p>Title</p>
      <p>Author</p>
      <p>Release Year</p>
      <p>Actions</p>
    </div>
    <li
      v-for="item in bookStore.getBooks"
      class="group-[bookList]: w-full odd:bg-slate-300 even:bg-slate-200 only:rounded-sm first-of-type:rounded-t-sm last-of-type:rounded-b-sm shadow-sm hover:bg-slate-500 focus:bg-slate-500"
    >
      <div
        class="grid grid-cols-4 grid-rows-1 content-center text-center p-0.5"
      >
        <p>{{ item.title }}</p>
        <p>{{ item.author }}</p>
        <p>{{ item.year }}</p>
        <div class="flex flex-row">
          <button
            class="bg-red-300 hover:bg-red-400 active:bg-red-500 w-full rounded-sm mr-1"
            @click="bookStore.removeBook(item.bookId)"
          >
            Delete
          </button>
          <button
            class="bg-orange-300 hover:bg-orange-400 active:bg-orange-500 w-full rounded-sm"
          >
            Edit
          </button>
        </div>
      </div>
    </li>
    <div class="grid grid-cols-4 gap-0.5 grid-rows-1 content-center p-0.5">
      <input
        placeholder="Title"
        v-model="book.title"
        type="text"
        name="BTitle"
        id=""
        class="w-full bg-blue-200 outline-none focus:bg-blue-300 rounded-sm"
      />
      <input
        placeholder="Author"
        v-model="book.author"
        type="text"
        name="BAuthor"
        id=""
        class="w-full bg-blue-200 outline-none focus:bg-blue-300 rounded-sm"
      />
      <input
        placeholder="ReleaseYears"
        v-model="book.year"
        type="number"
        name="BYear"
        id=""
        class="w-full bg-blue-200 outline-none focus:bg-blue-300 rounded-sm"
      />
      <button
        @click="
          bookStore.addBook({
            bookId: 0,
            author: book.author,
            title: book.title,
            year: book.year,
          })
        "
        class="bg-green-300 hover:bg-green-400 active:bg-green-500 rounded-sm"
      >
        Create Book
      </button>
    </div>
  </ul>
</template>
