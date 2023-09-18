<script setup lang="ts">
import { onMounted, ref } from "vue";

interface IBookdata {
  bookId: number;
  title: string;
  author: string;
  year: number;
}

const myBook = {} as IBookdata;

const getBooks = async () => {
  const response = await fetch("api/Book");
  const data = (await response.json()) as IBookdata[];

  return data;
};

const bookData = ref<IBookdata[]>([]);

const foo = async () => {
  await fetch(`api/Book/newBook`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(myBook),
  });
};

onMounted(async () => {
  bookData.value = await getBooks();
});

const fetchBookData = async () => (bookData.value = await getBooks());
</script>

<template>
  <button @click="fetchBookData">Update</button>
  <ul>
    <li v-for="item in bookData" class="flex w-full">
      <div class="h-4 gap-4 w-full flex flex-row justify-around">
        <p>{{ item.title }}</p>
        <p>{{ item.author }}</p>
        <p>{{ item.year }}</p>
      </div>
    </li>
  </ul>
  <button
    @click="foo()"
    class="p-4 bg-slate-400 hover:bg-slate-600 border border-slate-700"
  >
    Create Book
  </button>
  <div>
    <input
      placeholder="Title"
      v-model="myBook.title"
      type="text"
      name="BTitle"
      id=""
    />
    <input
      placeholder="Author"
      v-model="myBook.author"
      type="text"
      name="BAuthor"
      id=""
    />
    <input
      placeholder="ReleaseYears"
      v-model="myBook.year"
      type="text"
      name="BYear"
      id=""
    />
  </div>
</template>
