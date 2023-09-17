<script setup lang="ts">
import { onMounted, ref } from 'vue';

interface IBookdata {
  bookId: number;
  title: string;
  author: string;
  year: number;
}

const myBook = {} as IBookdata;

const getBooks = async () => {
  const response = await fetch('api/Book');
  const data = await response.json() as IBookdata[];
  
  return data;
}

const bookData = ref<IBookdata[]>([]);

const addBook = async (book: IBookdata) => {
  await fetch(`api/Book?title=${book.title}&author=${book.author}&year=${book.year}`, {method: 'POST'});
  bookData.value = await getBooks();
}

const removeBook = async (bookTitle: string) => {
  await fetch(`api/Book?title=${bookTitle}`, {method: 'DELETE'});
  bookData.value = await getBooks();
}

onMounted(async () => {
  bookData.value = await getBooks();
});
</script>

<template>
  <ul>
    <li v-for="item in bookData"> 
      <div>
        <p>{{ item.title }}</p>
        <p>{{ item.author }}</p>
        <p>{{ item.year }}</p>
      </div>
      <button @click="removeBook(item.title)">
        Delete Book
      </button>
    </li>
  </ul>
  <div>
    <input placeholder="Title" v-model="myBook.title" type="text" name="BTitle" id="">
    <input placeholder="Author" v-model="myBook.author" type="text" name="BAuthor" id="">
    <input placeholder="ReleaseYears" v-model="myBook.year" type="text" name="BYear" id="">
    <button @click="addBook(myBook)">
      Add Book
    </button>
  </div>
</template>
