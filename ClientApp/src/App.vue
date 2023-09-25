<script setup lang="ts">
import useBookStore from "./stores/bookStore";
import { onMounted, onUnmounted } from "vue";
import ListItem from "./components/ListItem.vue";
import ListItemAdder from "./components/ListItemAdder.vue";
import ListItemBook from "./components/ListItemBook.vue";

const bookStore = useBookStore();

onMounted(async () => {
  await bookStore.initBooksStore;
});

onUnmounted(async () => {
  console.log("unmounted");
  await bookStore.syncChanges();
});
</script>

<template>
  <ul class="flex flex-col gap-0.5 w-4/5">
    <ListItem>
      <p>Title</p>
      <p>Author</p>
      <p>Release Year</p>
      <p>Actions</p>
    </ListItem>
    <li
      v-for="item in bookStore.getBooks"
      class="group-[bookList]: w-full odd:bg-slate-300 even:bg-slate-200 only:rounded-sm first-of-type:rounded-t-sm last-of-type:rounded-b-sm shadow-sm hover:bg-slate-500 focus:bg-slate-500"
    >
      <ListItemBook :book="item"></ListItemBook>
    </li>
    <ListItemAdder></ListItemAdder>
  </ul>
  <button @click="bookStore.syncChanges()">sync Changes</button>
</template>
